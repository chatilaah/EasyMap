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

        public bool PerformMap()
        {
            var sheet = _dsInfo.File.Sheet[0];

            int srcRowCount = sheet.Rows[0].ItemArray.Length;

            if (srcRowCount != _config.TranslateFields.Count)
            {
                LastError = TranslatorLastError.RowsDontMatch;

                return false;
            }

            // ==============================================================================
            //
            // Prepare the new header
            //

            string[] header = new string[srcRowCount];

            for (int i = 0; i < srcRowCount; i++)
            {
                var current = sheet.Rows[0].ItemArray[i].ToString();
                var replacement = _config.TranslateFields[current].Replacement;

                header[i] = replacement;
            }

            // ==============================================================================
            //
            // Setup the buffer.
            //

            _buffer = string.Empty;

            for (int i = 0; i < srcRowCount; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < header.Length; j++)
                    {
                        _buffer += $"{header[j]},";
                    }
                }
                else
                {
                    for (int j = 0; j < sheet.Rows[i].ItemArray.Length; j++)
                    {
                        var current = sheet.Rows[i].ItemArray[j].ToString();

                        _buffer += $"{current},";
                    }
                }

                _buffer = _buffer.Remove(_buffer.Length - 1);
                _buffer += "\n";
            }


            return true;
        }

        public void SaveToFile(string filename)
        {
            File.WriteAllText(filename, Buffer);
        }
    }
}
