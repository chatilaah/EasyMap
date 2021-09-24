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
using System;
namespace EasyMap
{
    public class DataTypeModel
    {
        /// <summary>
        /// The data type of the field.
        /// </summary>
        public readonly DataType DataType;

        /// <summary>
        /// The maximum allocatable size for the field.
        /// </summary>
        public readonly int Size;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawValue"></param>
        public DataTypeModel(string rawValue)
        {
            rawValue = rawValue.ToLower();

            int i1 = rawValue.IndexOf('(');
            int i2 = rawValue.IndexOf(')');

            var dtStr = i1 != -1 ? rawValue.Substring(0, i1) : rawValue;
            DataType = new DataTypeDefs().DataTypes[dtStr];

            if (!DataType.ShouldHaveSize())
            {
                Size = -1;
            }

            if (i1 != -1 && i2 == -1)
            {
                throw new System.Exception($"Data type for '{rawValue}' is missing the enclosing character ')'");
            }
            else if (i1 == -1 && i2 != -1)
            {
                throw new System.Exception($"Data type for '{rawValue}' is missing the trailing character '('");
            }

            if (i2 - i1 > 0)
            {
                Size = Convert.ToInt32(rawValue.Substring(i1 + 1, rawValue.Length - i2 - 1));
            }
            else
            {
                throw new System.Exception("Size format not defined properly.");
            }
        }
    }
}