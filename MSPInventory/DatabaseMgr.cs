using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Configuration;

namespace MSPInventory
{
    public class DatabaseMgr
    {
        private SqlConnection   m_dbConnection;
        private SqlCommand      m_dbCommand = new SqlCommand();

        /// <summary>
        /// database handler constructor
        /// </summary>
        public DatabaseMgr(string strServer)
        {
            // create database connection
            string strConnect = string.Format("Server={0};Database=MSPInventory_New;Uid=sa;Pwd=123", strServer);
            m_dbConnection = new SqlConnection(strConnect);
        }

        /// <summary>
        /// opens database connection
        /// </summary>
        public bool Open()
        {
            // check connection state
            if (IsOpen()) return true;
            try
            {
                // open database
                m_dbConnection.Open();
                m_dbCommand.Connection = m_dbConnection;

                // verify connection state
                if (m_dbConnection.State == System.Data.ConnectionState.Open)
                    return true;
            }
            catch (Exception ex)
            {
                // log error
                LogError(ex.Message, "Open");
            }
            return false;
        }

        /// <summary>
        /// closes the database connection
        /// </summary>
        public bool Close()
        {
            try
            {
                // close database
                m_dbConnection.Close();

                // verify connection state
                if (m_dbConnection.State == System.Data.ConnectionState.Closed)
                    return true;
            }
            catch (Exception ex)
            {
                // log error
                LogError(ex.Message, "Close");
            }
            return false;
        }

        /// <summary>
        /// checks the connection state
        /// </summary>
        public bool IsOpen()
        {
            // verify connection state
            return (m_dbConnection.State == System.Data.ConnectionState.Open);
        }
                
        /// <summary>
        /// reads an object data from the database
        /// </summary>
        public object ExecuteScalar(string strSQL)
        {
            // get SQL command
            m_dbCommand.CommandText = strSQL;
            object objData = null;

            // check connection state
            if (!IsOpen()) Open();
            try
            {
                // get data
                objData = m_dbCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                // log error
                LogError(ex.Message, strSQL);
            }
            return objData;
        }
                
        /// <summary>
        /// reads a set of data from the database
        /// </summary>
        public SqlDataReader ExecuteReader(string strSQL)
        {
            // get SQL command
            m_dbCommand.CommandText = strSQL;
            SqlDataReader dbReader = null;

            // check connection state
            if (!IsOpen()) Open();
            try
            {
                // execute SQL command
                dbReader = m_dbCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                // log error
                LogError(ex.Message, strSQL);
            }
            return dbReader;
        }

        /// <summary>
        /// executes a non-query SQL statement
        /// </summary>
        public int ExecuteNonQuery(string strSQL)
        {
            // get SQL command
            m_dbCommand.CommandText = strSQL;
            int nRet = 0;

            // check connection state
            if (!IsOpen()) Open();
            try
            {
                // execute SQL command
                nRet = m_dbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // log error
                LogError(ex.Message, strSQL);
            }
            return nRet;
        }

        /// <summary>
        /// logs sql error to external file
        /// </summary>
        private void LogError(string strError, string strSQL)
        {
#if DEBUG
            StreamWriter fWriter = new StreamWriter("C:\\mspinventory_log.txt", true);
            if (null != fWriter)
            {
                // add error to log
                fWriter.WriteLine(String.Format("\"{0}\"", strSQL));
                fWriter.WriteLine(String.Format("{0}: {1}", DateTime.Now.ToString(), strError));
                fWriter.Flush();
                fWriter.Close();
            }
#endif
        }
    }
}
