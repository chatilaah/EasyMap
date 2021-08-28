/// <summary>
/// Copyright (c) 2021 Ahmad N. Chatila.
/// 
/// Author:
///     Ahmad N. Chatila
///     
/// Date Created:
///     3 July 2021
///     
/// </summary>
namespace EasyMap
{
    public enum FileFormat
    {
        /// <summary>
        /// The file format is unknown.
        /// </summary>
        Undefined,

        /// <summary>
        /// The file format is a modern Excel sheet.
        /// </summary>
        Xlsx,

        /// <summary>
        /// The file format is an old (97-2003) Excel sheet.
        /// </summary>
        Xls,

        /// <summary>
        /// The file format is a Comma-separated value sheet (MS-DOS/Macintosh)
        /// </summary>
        Csv
    }
}