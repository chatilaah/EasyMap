using System;
using System.IO;

namespace EasyMap
{
    public class EMFile : IDisposable
    {
        private FileFormat _format = FileFormat.Undefined;

        public FileFormat Format
        {
            get
            {
                return _format;
            }

            protected set
            {
                _format = value;
            }
        }

        public readonly string Filename;

        public virtual int RowCount
            => 0;

        public virtual int ColumnCount
            => 0;

        public virtual object[] RowAt(int index)
        {
            throw new NotImplementedException();
        }

        public virtual object[] ColumnAt(int index)
        {
            throw new NotImplementedException();
        }

        #region Constructor(s)

        public EMFile(string filename)
        {
            Filename = filename;
        }

        #endregion

        public virtual void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}