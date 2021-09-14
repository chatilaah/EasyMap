/// <summary>
/// Copyright (c) 2021 Ahmad N. Chatila.
/// 
/// Author:
///     Ahmad N. Chatila
///     
/// Date Created:
///     23 July 2021
///     
/// </summary>
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EasyMap
{
    public class DataSourceInfo : IDisposable
    {
        public readonly EMFile File;

        private readonly ConfigModel _config;

        #region Constructor(s)

        public DataSourceInfo(string sourceFileName, ConfigModel config)
        {
            Debug.Assert(config != null);

            _config = config;

            if (sourceFileName.ToLower().EndsWith(FileFormatConstants.XlsxFileFormat) ||
                sourceFileName.ToLower().EndsWith(FileFormatConstants.XlsFileFormat))
            {
                File = new ExcelFile(sourceFileName);
            }
            else if (sourceFileName.ToLower().EndsWith(FileFormatConstants.CsvFileFormat))
            {
                File = new CsvFile(sourceFileName);
            }
            else
            {
                throw new FormatException($"The specified file \"{sourceFileName}\" appears to be unhandled by the application. Alternatively, use Excel files or Comma-separated value files.");
            }
        }

        #endregion

        public List<string> MatchingFields
        {
            get
            {
                var avail = new List<string>();

                if (File.RowAt(0) == null)
                {
                    return avail;
                }

                for (int i = 0; i < File.RowAt(0).Length; i++)
                {
                    var curr_i = File.RowAt(0)[i];

                    if (curr_i == null)
                    {
                        continue;
                    }

                    foreach (var j in _config.TranslateFields)
                    {
                        if (curr_i.Equals(j.Key))
                        {
                            avail.Add(curr_i.ToString());
                        }
                    }
                }

                return avail;
            }
        }

        public void Dispose()
        {
            File?.Dispose();
        }
    }
}
