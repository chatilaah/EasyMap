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
using System.Data;
using System.Diagnostics;

namespace EasyMap
{
    public class DataSourceInfo : IDisposable
    {
        public readonly ExcelFile File;

        private readonly ConfigModel _config;

        private DataTableCollection Sheet => File.Sheet;

        #region Constructor(s)

        public DataSourceInfo(string sourceFileName, ConfigModel config)
        {
            Debug.Assert(config != null);

            _config = config;
            File = new ExcelFile(sourceFileName);
        }

        #endregion

        public List<string> MatchingFields
        {
            get
            {
                var avail = new List<string>();

                if (Sheet[0].Rows[0] == null)
                {
                    return avail;
                }

                for (int i = 0; i < Sheet[0].Rows[0].ItemArray.Length; i++)
                {
                    var curr_i = Sheet[0].Rows[0].ItemArray[i];

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
