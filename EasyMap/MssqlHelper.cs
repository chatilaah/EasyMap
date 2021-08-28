/// <summary>
/// Copyright (c) 2021 Ahmad N. Chatila.
/// 
/// Author:
///     Ahmad N. Chatila
///     
/// Date Created:
///     04 June 2021
///     
/// </summary>
using System;
using System.Data.SqlClient;

namespace EasyMap.Gui.Utils
{
    public class MssqlHelper
    {
        #region Properties

        private string _lastError;

        public string LastError { get { return _lastError; } private set { _lastError = value; } }

        SqlConnection _cnn;

        #endregion

        public bool Connect(string connectionString)
        {
            if (_cnn != null)
            {
                if (_cnn.State == System.Data.ConnectionState.Open)
                {
                    LastError = "Connection is already open.";
                    return false;
                }

                if (_cnn.State == System.Data.ConnectionState.Connecting)
                {
                    LastError = "Connection is in progress.";
                    return false;
                }

                _cnn.Dispose();
            }

            _cnn = new SqlConnection(connectionString);

            try
            {
                LastError = string.Empty;

                _cnn.Open();

                return true;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
            }

            return false;
        }

        /// <summary>
        /// Disconnects from any established connection to the server.
        /// </summary>
        public void Disconnect()
        {
            if (_cnn == null) return;
            if (_cnn.State != System.Data.ConnectionState.Open) return;
            _cnn.Close();
        }

        public void Insert(string sql)
        {
            InternalCheckBeforeExecCmd();

            using SqlCommand command = new SqlCommand(sql, _cnn);

            SqlDataAdapter adapter = new SqlDataAdapter
            {
                InsertCommand = new SqlCommand(sql, _cnn)
            };

            adapter.InsertCommand.ExecuteNonQuery();
        }

        public void Update(string sql)
        {
            InternalCheckBeforeExecCmd();

            using SqlCommand command = new SqlCommand(sql, _cnn);

            SqlDataAdapter adapter = new SqlDataAdapter
            {
                UpdateCommand = new SqlCommand(sql, _cnn)
            };

            adapter.UpdateCommand.ExecuteNonQuery();
        }

        public void Delete(string sql)
        {
            InternalCheckBeforeExecCmd();

            using SqlCommand command = new SqlCommand(sql, _cnn);

            SqlDataAdapter adapter = new SqlDataAdapter
            {
                DeleteCommand = new SqlCommand(sql, _cnn)
            };

            adapter.DeleteCommand.ExecuteNonQuery();
        }

        #region Internal Methods

        private void InternalCheckBeforeExecCmd()
        {
            if (_cnn == null)
            {
                throw new Exception("Object not allocted into memory.");
            }

            if (_cnn.State != System.Data.ConnectionState.Open)
            {
                throw new Exception("Not connected to a database.");
            }
        }

        #endregion
    }
}
