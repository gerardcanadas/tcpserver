using DataLayer.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Enums;

namespace DataLayer
{
    public class SqlConnector
    {
        // TODO: Secure connectionString
        private string ConnectionString = @"Server=Gerard-PC\SQLEXPRESS;Database=gerard_logger;User Id=sa;Password=hellomoto10;";
        private SqlConnection SQLConnection;
        private Guid ClientConnectionId;

        private static Object Locker = new Object();
        private static SqlConnector _Instance = null;

        // Private constructor to avoid instance creation
        private SqlConnector()
        {
            this.SQLConnection = new SqlConnection(this.ConnectionString);
            this.ClientConnectionId = this.SQLConnection.ClientConnectionId;
        }

        // Singleton instance Get
        public static SqlConnector GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (Locker)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new SqlConnector();
                        }
                    }

                }
                return _Instance;
            }
        }

        private void OpenConnection()
        {
            this.SQLConnection.Open();
        }

        private void CloseConnection()
        {
            this.SQLConnection.Close();
        }

        public SqlEnums.SqlQueryStatus ExecuteQuery(SqlQuery query, SqlEnums.SqlQueryType type)
        {
            try
            {
                string strQuery = SqlUtils.BuildSqlQuery(query, type);
                SqlCommand sqlCommand = new SqlCommand(strQuery, SQLConnection);
                sqlCommand.CommandType = CommandType.Text;
                OpenConnection();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}", reader.GetString(1), reader.GetString(2));
                    }
                }

                CloseConnection();
                Console.ReadLine();
                return SqlEnums.SqlQueryStatus.Success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
