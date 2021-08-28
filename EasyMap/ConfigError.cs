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
    public enum ConfigError
    {
        /// <summary>
        /// No error.
        /// </summary>
        None,

        /// <summary>
        /// The required value was not specified.
        /// </summary>
        RequiredValueNotSpecified,

        /// <summary>
        /// The value was not specified.
        /// </summary>
        ValueNotSpecified,

        /// <summary>
        /// Automatically generates the value.
        /// </summary>
        Autogenerate,
        
        /// <summary>
        /// The specfied variable appears to be undefined
        /// Usually, predefined variables precede with the '$' sign.
        /// </summary>
        UndefinedVariable
    }
}
