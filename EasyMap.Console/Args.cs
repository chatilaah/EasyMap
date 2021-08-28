/// <summary>
/// Copyright (c) 2021 Ahmad N. Chatila.
/// 
/// Author:
///     Ahmad N. Chatila
///     
/// Date Created:
///     05 May 2021
///     
/// </summary>
using System.Collections.Generic;
using System.IO;

namespace EasyMap.Console
{
    internal class Args
    {
        /// <summary>
        /// REQURIED: The file should be a 2007 Excel sheet (.xlsx) with the necessary template.
        /// 
        /// Please refer to the bundled Excel sheet template within this project.
        /// </summary>
        public string ConfigFile { get; set; }

        public string SourceFile { get; set; }

        /// <summary>
        /// If specified, the target connection string will be ignored.
        /// </summary>
        public string DestinationFile { get; set; }

        #region Constructor(s)

        public Args(string[] args)
        {
            if (args.Length < 2)
            {
                return;
            }

            ConfigFile = args[0];
            ErrorDetails[ArgsField.CfgFile] = File.Exists(ConfigFile) ? ArgsError.None : ArgsError.FileNotFound;

            SourceFile = args[1];
            ErrorDetails[ArgsField.SrcFile] = File.Exists(SourceFile) ? ArgsError.None : ArgsError.FileNotFound;

            if (args.Length == 3)
            {
                DestinationFile = args[2];
                ErrorDetails[ArgsField.DstFile] = File.Exists(DestinationFile) ? ArgsError.None : ArgsError.FileNotFound;
            }
        }

        #endregion

        public bool IsValid => ErrorDetails[ArgsField.SrcFile] == ArgsError.None && ErrorDetails[ArgsField.CfgFile] == ArgsError.None;

        public readonly Dictionary<ArgsField, ArgsError> ErrorDetails = new()
        {
            { ArgsField.CfgFile, ArgsError.FileNotSpecified },
            { ArgsField.SrcFile, ArgsError.FileNotSpecified },
            { ArgsField.DstFile, ArgsError.FileNotSpecified }
        };
    }
}
