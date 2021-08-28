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
namespace EasyMap
{
    internal static class CustomExtensions
    {
        /// <summary>
        /// Converts the ConfigField value to a human-readable string.
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static string ToString(this ConfigField field)
        {
            switch (field)
            {
                case ConfigField.ConnectionString:
                    return "Connection String";
                case ConfigField.DeleteQuery:
                    return "Delete Query";
                case ConfigField.InsertQuery:
                    return "Insert Query";
                case ConfigField.UpdateQuery:
                    return "Update Query";
                case ConfigField.ServerName:
                    return "Server Name";
                case ConfigField.Password:
                    return "Password";
                case ConfigField.Table:
                    return "Table";
                case ConfigField.Username:
                    return "Username";
            }

            return string.Empty;
        }

        /// <summary>
        /// Converts the ConfigError value to a human-readable error string.
        /// </summary>
        /// <param name="error"></param>
        /// <param name="withErrorCode"></param>
        /// <returns></returns>
        public static string ToString(this ConfigError error, bool withErrorCode = false)
        {
            var str = "No error.";

            switch (error)
            {
                case ConfigError.Autogenerate:
                    str = "Auto-generate";
                    break;
                case ConfigError.RequiredValueNotSpecified:
                    str = "Required value not specified";
                    break;
                case ConfigError.UndefinedVariable:
                    str = "Undefined variable";
                    break;
                case ConfigError.ValueNotSpecified:
                    str = "Value not specified";
                    break;

                case ConfigError.None: break;
            }

            if (withErrorCode)
                str = $"{((int)error)} {str}";

            return str;
        }
    }
}
