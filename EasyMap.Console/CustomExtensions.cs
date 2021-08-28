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
namespace EasyMap.Console
{
    internal static class CustomExtensions
    {
        /// <summary>
        /// Converts the ArgsField value to a human-readable string.
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static string ToString(this ArgsField field)
        {
            switch (field)
            {
                case ArgsField.CfgFile:
                    return "Config File";
                case ArgsField.DstFile:
                    return "Destination File";
                case ArgsField.SrcFile:
                    return "Source File";
            }

            return string.Empty;
        }

        /// <summary>
        /// Converts the ArgsError value to a human-readable error string.
        /// </summary>
        /// <param name="error"></param>
        /// <param name="withErrorCode"></param>
        /// <returns></returns>
        public static string ToString(this ArgsError error, bool withErrorCode = false)
        {
            var str = "No error.";

            switch (error)
            {
                case ArgsError.FileNotFound:
                    str = "File not found.";
                    break;
                case ArgsError.FileNotSpecified:
                    str = "File not specified.";
                    break;
                case ArgsError.None: break;
            }

            if (withErrorCode)
                str = $"{((int)error)} {str}";

            return str;
        }
    }
}
