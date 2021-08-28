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
using ExcelDataReader;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace EasyMap
{
    public class ExcelFile : IDisposable
    {
        public readonly string Filename;

        public readonly FileFormat Format = FileFormat.Undefined;

        public DataTableCollection Sheet => reader.AsDataSet().Tables;

        private readonly FileStream stream;
        private readonly IExcelDataReader reader;

        #region Constructor(s)

        public ExcelFile(string filename)
        {
            Filename = filename;

            Debug.Assert(!string.IsNullOrEmpty(filename), $"The excel file was not specfied!");
            Debug.Assert(File.Exists(filename), $"The source file \"{filename}\" doesn't exist!");

            if (filename.ToLower().EndsWith(FileFormatConstants.XlsxFileFormat))
            {
                Format = FileFormat.Xlsx;
            }
            else if (filename.ToLower().EndsWith(FileFormatConstants.XlsFileFormat))
            {
                Format = FileFormat.Xls;
            }
            else if (filename.ToLower().EndsWith(FileFormatConstants.CsvFileFormat))
            {
                Format = FileFormat.Csv;
            }

            Debug.Assert(Format != FileFormat.Undefined, "File format is not compatible with this class.");

            // Required when running under .NET Core!
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            stream = File.Open(filename, FileMode.Open, FileAccess.Read);
            reader = ExcelReaderFactory.CreateReader(stream);
        }

        #endregion

        public void Dispose()
        {
            stream.Dispose();
            reader.Dispose();
        }
    }
}