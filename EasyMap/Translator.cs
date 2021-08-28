/// <summary>
/// Copyright (c) 2021 Ahmad N. Chatila.
/// 
/// Author:
///     Ahmad N. Chatila
///     
/// Date Created:
///     28 July 2021
///     
/// </summary>
using EasyMap.Gui.Utils;
using System;
using System.Diagnostics;
using System.IO;

namespace EasyMap
{
    public class Translator
    {
        private readonly ConfigModel _config;
        private readonly DataSourceInfo _dsInfo;
        private TranslatorLastError _lastError = TranslatorLastError.None;
        private string _buffer = string.Empty;

        public string Buffer
        {
            get { return _buffer; }
            private set { _buffer = value; }
        }

        public TranslatorLastError LastError
        {
            get { return _lastError; }
            private set { _lastError = value; }
        }

        #region Constructor(s)

        public Translator(DataSourceInfo dsInfo, ConfigModel config)
        {
            Debug.Assert(config.IsValid, "Config is invalid!");
            _config = config;

            _dsInfo = dsInfo ?? throw new Exception("DataSource Info is null.");
        }

        #endregion

        public bool PrepareBuffer()
        {
            var sheet = _dsInfo.File.Sheet[0];
            int srcRowCount = sheet.Rows[0].ItemArray.Length;

            if (srcRowCount != _config.TranslateFields.Count)
            {
                LastError = TranslatorLastError.RowsDontMatch;
                return false;
            }

            Buffer = string.Empty;

            for (int i = 0; i < srcRowCount; i++)
            {
                var len = sheet.Rows[i].ItemArray.Length;

                for (int j = 0; j < len; j++)
                {
                    var current = sheet.Rows[i].ItemArray[j].ToString();

                    Buffer += (i == 0) ?
                        $"{_config.TranslateFields[current].Replacement}" :
                        $"{current}";

                    if (j < len - 1)
                    {
                        Buffer += ",";
                    }
                }

                Buffer += Environment.NewLine;
            }

            return true;
        }

        public bool SaveToFile(string filename)
        {
            if (string.IsNullOrEmpty(Buffer))
            {
                if (PrepareBuffer() == false)
                {
                    return false;
                }
            }

            File.WriteAllText(filename, Buffer);
            return true;
        }

        public void UploadToSql(string connectionString)
        {
            System.Console.Write("Allocating necessary object...");
            var s = new MssqlHelper(); System.Console.Write("ok.\n");

            System.Console.Write("Connecting to the SQL server...");
            if (!s.Connect(connectionString))
            {
                System.Console.Write("fail.\n");
                throw new Exception(s.LastError);
            }
            System.Console.Write("ok.\n");


            int index = -1;

            foreach (var line in Buffer.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                index += 1;

                if (index == 0)
                    continue;

                var sql = string.Format(_config.InsertQuery, line);

                System.Console.Write($"{sql}\n");
                s.Insert(sql);
            }
        }
    }
}