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
namespace EasyMap
{
    public enum ConfigField
    {
        /// <summary>
        /// MSSQL: server name.
        /// </summary>
        ServerName,

        /// <summary>
        /// MSSQL: username.
        /// </summary>
        Username,

        /// <summary>
        /// MSSQL: password.
        /// </summary>
        Password,

        /// <summary>
        /// MSSQL: table name. 
        /// </summary>
        Table,

        /// <summary>
        /// SQL: Insert query.
        /// </summary>
        InsertQuery,

        /// <summary>
        /// SQL: Delete query.
        /// </summary>
        DeleteQuery,

        /// <summary>
        /// SQL: Update query.
        /// </summary>
        UpdateQuery,

        /// <summary>
        /// MSSQL: connection string.
        /// </summary>
        ConnectionString
    }
}
