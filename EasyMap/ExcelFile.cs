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
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace EasyMap
{
    public class ExcelFile : EMFile
    {
        private DataTableCollection Sheet => reader.AsDataSet().Tables;

        private FileStream stream;

        private readonly IExcelDataReader reader;

        public override int RowCount
            => Sheet[0 /* Always at Zero */].Rows.Count;

        public override int ColumnCount
            => Sheet[0 /* Always at Zero */].Columns.Count;

        #region Constructor(s)

        public ExcelFile(string filename) : base(filename)
        {
            Debug.Assert(!string.IsNullOrEmpty(filename), $"The excel file was not specfied!");
            Debug.Assert(File.Exists(filename), $"The source file \"{filename}\" doesn't exist!");

            // Required when running under .NET Core!
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            stream = File.Open(filename, FileMode.Open, FileAccess.Read);
            reader = ExcelReaderFactory.CreateReader(stream);

            Format = FileFormat.Xls | FileFormat.Xlsx;
        }

        #endregion

        public override object[] ColumnAt(int index)
        {
            return base.ColumnAt(index);
        }

        public override object[] RowAt(int index)
        {
            return Sheet[0 /* Always at Zero */].Rows[index].ItemArray;
        }

        public override void Dispose()
        {
            stream.Dispose();
            reader.Dispose();
        }
    }
}