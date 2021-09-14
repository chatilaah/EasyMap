using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace EasyMap
{
    public class CsvFile : EMFile
    {
        private StreamReader stream;

        private List<string[]> _rows;

        public override int RowCount
            => _rows[0 /* HACK: Not the best way to measure the length... Oh well! */].Length;

        public override int ColumnCount
            => 0;

        #region Constructor(s)

        public CsvFile(string filename) : base(filename)
        {
            Debug.Assert(!string.IsNullOrEmpty(filename), $"The csv file was not specfied!");
            Debug.Assert(File.Exists(filename), $"The source file \"{filename}\" doesn't exist!");

            // Required when running under .NET Core!
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Format = FileFormat.Csv;

            stream = new StreamReader(filename);

            _rows = new List<string[]>();

            foreach (var line in ReadLines(stream))
            {
                _rows.Add(line.Split(','));
            }
        }

        #endregion

        public override object[] ColumnAt(int index)
        {
            return base.ColumnAt(index);
        }

        public override object[] RowAt(int index)
        {
            return _rows[index];
        }

        /// <summary>
        /// Reads lines via StreamReader
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static IEnumerable<string> ReadLines(StreamReader stream)
        {
            StringBuilder sb = new();

            int symbol = stream.Peek();
            while (symbol != -1)
            {
                symbol = stream.Read();
                if (symbol == 13 && stream.Peek() == 10)
                {
                    stream.Read();

                    string line = sb.ToString();
                    sb.Clear();

                    yield return line;
                }
                else
                    sb.Append((char)symbol);
            }

            yield return sb.ToString();
        }

        public override void Dispose()
        {
            stream.Dispose();
        }
    }
}