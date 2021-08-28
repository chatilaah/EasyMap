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
namespace EasyMap.Console
{
    internal enum ArgsError
    {
        /// <summary>
        /// No error.
        /// </summary>
        None,

        /// <summary>
        /// File cannot be located on disk or a network resource.
        /// </summary>
        FileNotFound,

        /// <summary>
        /// File was not specified.
        /// </summary>
        FileNotSpecified
    }
}
