/// <summary>
/// Copyright (c) 2021 Ahmad N. Chatila.
/// 
/// Author:
///     Ahmad N. Chatila
///     
/// Date Created:
///     23 June 2021
///     
/// </summary>
using ExcelDataReader;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace EasyMap
{
    public class ConfigModel
    {
        public readonly string Filename;

        public Dictionary<string, TranslateItem> TranslateFields { get; set; }

        public string ServerName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Table { get; set; }

        public string InsertQuery
        {
            get
            {
                if (!string.IsNullOrEmpty(_userInsertQuery))
                {
                    return _userInsertQuery;
                }

                return string.Format("insert into {0} ({1}) values ({2})", Table, CsvFields, "{0}");
            }

            set
            {
                _userInsertQuery = value;
            }
        }

        public string DeleteQuery
        {
            get
            {
                if (!string.IsNullOrEmpty(_userDeleteQuery))
                {
                    return _userDeleteQuery;
                }

                return string.Format("delete from {0}", Table);
            }

            set
            {
                _userDeleteQuery = value;
            }
        }

        public string UpdateQuery
        {
            get
            {
                if (!string.IsNullOrEmpty(_userUpdateQuery))
                {
                    return _userUpdateQuery;
                }

                return string.Format("update {0} set ({1})", Table, CsvFieldsWithStringFormat);
            }

            set
            {
                _userUpdateQuery = value;
            }
        }

        public string ConnectionString { get; set; }


        private string _userInsertQuery;
        private string _userUpdateQuery;
        private string _userDeleteQuery;

        private string CsvFields
        {
            get
            {
                var query = "";

                foreach (var i in TranslateFields)
                {
                    query += i.Value.Replacement + ",";
                }

                return query[0..^1]; /* Remove trailing comma. */
            }
        }

        private string CsvFieldsWithStringFormat
        {
            get
            {
                var query = "";

                int index = 0;
                foreach (var i in TranslateFields)
                {
                    query += i.Value.Replacement + "={" + index + "},";
                    index += 1;
                }

                return query[0..^1]; /* Remove trailing comma. */
            }
        }

        /// <summary>
        /// Important: Keep as-is for EasyMap protocol.
        /// </summary>
        readonly string[] _formatHeaders =
        {
            "source",
            "destination",
            "comments",
            "settingname",
            "settingvalue",
            "comments"
        };

        /// <summary>
        /// Important: Keep as-is for EasyMap protocol.
        /// </summary>
        readonly string[] _formatSettings =
        {
            "servername",
            "username",
            "password",
            "table",
            "insertquery",
            "updatequery",
            "deletequery",
            "connectionstring"
        };

        /// <summary>
        /// Important: Keep as-is for EasyMap protocol.
        /// </summary>
        const int SourceIndex = 0;
        const int DestinationIndex = 1;
        const int DataTypeIndex = 2;
        const int Comments1Index = 3;
        const int SettingNameIndex = 4;
        const int SettingValueIndex = 5;
        const int Comments2Index = 6;


        #region Constructor(s)

        public ConfigModel(string filePath)
        {
            Filename = filePath;

            // The config file is always an Excel file!
            // Hence, no point of unifying the type of the instance.
            using var emFile = new ExcelFile(filePath);

            // ==============================================================================
            //
            // Check the header fist and throw an exception if an error occurs.
            //
            //
            for (int i = 0; i < emFile.RowAt(0).Length; i++)
            {
                if (!_formatHeaders[i].Equals(emFile.RowAt(0)[i].ToString().ToLower()))
                {
                    throw new System.Exception("Headers don't match!");
                }
            }

            // ==============================================================================
            //
            // Begin storing config data
            //
            //
            for (int i = 1; i < emFile.RowCount; i++)
            {
                var settingName = emFile.RowAt(i)[SettingNameIndex].ToString().ToLower();
                var settingValue = emFile.RowAt(i)[SettingValueIndex].ToString();

                if (settingName.Equals(_formatSettings[0] /* ServerName */))
                {
                    ErrorDetails[ConfigField.ServerName] = ConfigError.None;
                    ServerName = settingValue;
                }
                else if (settingName.Equals(_formatSettings[1] /* Username */))
                {
                    ErrorDetails[ConfigField.Username] = ConfigError.None;
                    Username = settingValue;
                }
                else if (settingName.Equals(_formatSettings[2] /* Password */))
                {
                    ErrorDetails[ConfigField.Password] = ConfigError.None;
                    Password = settingValue;
                }
                else if (settingName.Equals(_formatSettings[3] /* Table */))
                {
                    ErrorDetails[ConfigField.Table] = ConfigError.None;
                    Table = settingValue;
                }
                else if (settingName.Equals(_formatSettings[4] /* InsertQuery */))
                {
                    ErrorDetails[ConfigField.InsertQuery] = ConfigError.None;
                    InsertQuery = settingValue;
                }
                else if (settingName.Equals(_formatSettings[5] /* UpdateQuery */))
                {
                    ErrorDetails[ConfigField.UpdateQuery] = ConfigError.None;
                    UpdateQuery = settingValue;
                }
                else if (settingName.Equals(_formatSettings[6] /* DeleteQuery */))
                {
                    ErrorDetails[ConfigField.DeleteQuery] = ConfigError.None;
                    DeleteQuery = settingValue;
                }
                else if (settingName.Equals(_formatSettings[7] /* ConnectionString */))
                {
                    ErrorDetails[ConfigField.ConnectionString] = ConfigError.None;
                    ConnectionString = settingValue;
                }
            }

            // ==============================================================================
            //
            // Begin storing translation data.
            //
            //
            TranslateFields = new();
            for (int i = 1; i < emFile.RowCount; i++)
            {
                var r = emFile.RowAt(i);

                var srcFieldName = r[SourceIndex].ToString();

                if (string.IsNullOrEmpty(srcFieldName))
                {
                    continue;
                }

                var dstFieldName = r[DestinationIndex].ToString();

                if (string.IsNullOrEmpty(dstFieldName))
                {
                    continue;
                }

                var dataTypeName = row.ItemArray[DataTypeIndex].ToString();

                if (string.IsNullOrEmpty(dataTypeName))
                {
                    continue;
                }

                TranslateFields.Add(srcFieldName, new TranslateItem
                {
                    Replacement = dstFieldName,
                    DataTypeInfo = new DataTypeModel(dataTypeName),
                    Comment = row.ItemArray[Comments1Index].ToString()
                });
            }

            var x = UpdateQuery;


            Debug.Assert(TranslateFields.Count > 0, $"Please fill the Source and Destination values in the file \"{filePath}\"");
        }

        #endregion

        public bool IsValid =>
            ErrorDetails[ConfigField.Table] == ConfigError.None &&
            ErrorDetails[ConfigField.ServerName] == ConfigError.None &&
            ErrorDetails[ConfigField.Username] == ConfigError.None &&
            ErrorDetails[ConfigField.Password] == ConfigError.None;

        public readonly Dictionary<ConfigField, ConfigError> ErrorDetails = new()
        {
            { ConfigField.ServerName, ConfigError.RequiredValueNotSpecified },
            { ConfigField.Table, ConfigError.RequiredValueNotSpecified },
            { ConfigField.Username, ConfigError.RequiredValueNotSpecified },
            { ConfigField.Password, ConfigError.RequiredValueNotSpecified },
            { ConfigField.DeleteQuery, ConfigError.Autogenerate },
            { ConfigField.UpdateQuery, ConfigError.Autogenerate },
            { ConfigField.InsertQuery, ConfigError.Autogenerate },
            { ConfigField.ConnectionString, ConfigError.RequiredValueNotSpecified }
        };
    }
}