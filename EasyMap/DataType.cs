/// <summary>
/// Copyright (c) 2021 Ahmad N. Chatila.
/// 
/// Author:
///     Ahmad N. Chatila
///     
/// Date Created:
///     24 Sept 2021
///     
/// </summary>
using System.Collections.Generic;
namespace EasyMap
{
    public enum DataType
    {
        VarCharMax,
        VarChar,
        Integer,
        Int,
        Bit,
        NVarChar,
        Char,
        Float,
        Decimal,
        Real,
        Xml
    }

    public class DataTypeDefs
    {
        public readonly Dictionary<string, DataType> DataTypes = new()
        {
            { "varchar(max)", DataType.VarCharMax },
            { "varchar", DataType.VarChar },
            { "integer", DataType.Integer },
            { "int", DataType.Int },
            { "bit", DataType.Bit },
            { "nvarchar", DataType.NVarChar },
            { "char", DataType.Char },
            { "float", DataType.Float },
            { "decimal", DataType.Decimal },
            { "real", DataType.Real },
            { "xml", DataType.Xml },
        };
    }
}