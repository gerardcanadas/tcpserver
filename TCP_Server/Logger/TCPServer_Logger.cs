using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Tables;
using DataLayer.Sql;
using DataLayer.Enums;

namespace TCP_Server.Logger
{
    public class TCPServer_Logger
    {
        private Entity Entity;

        public TCPServer_Logger()
        {
        }

        public TCPServer_Logger(Entity Entity = null)
        {
            this.Entity = Entity;
        }

        public static void WriteLog(LogType LogType)
        {
            switch (LogType)
            {
                case LogType.BytesReceived:
                    SqlQuery.Select select = new SqlQuery.Select();
                    List<string> listFields = new List<string>();
                    listFields.Add("*");
                    select.Fields = listFields; 
                    select.From = LogTables.TCPServer_Logs;
                    string query = "insert into tcpserver_logs values ('SecondLogTest', 'This is the second log test', GETDATE(), 'gerard')";
                    //SqlConnector.GetInstance.ExecuteQuery(query, SqlEnums.SqlQueryType.Insert);
                    break;

                case LogType.BytesSent:

                    break;

                default:
                    break;
            }
        }

        public static void ReadLog(int LogID)
        {
            SqlQuery.Select select = new SqlQuery.Select();
            List<string> listFields = new List<string>();
            listFields.Add("*");
            select.Fields = listFields;
            select.From = LogTables.TCPServer_Logs;
            List<WhereStatement> listWhere = new List<WhereStatement>();
            WhereStatement tWhere1 = new WhereStatement();
            tWhere1.WhereField = "id";
            tWhere1.WhereCondition = "1";
            tWhere1.WhereOperator = SqlEnums.SqlQueryOperator.Equal;
            listWhere.Add(tWhere1);
            select.Where = listWhere;
            SqlConnector.GetInstance.ExecuteQuery(select, SqlEnums.SqlQueryType.Select);
            //SqlConnector.GetInstance.ExecuteQuery()
        }
    }

    public enum LogType
    {
        BytesSent,
        BytesReceived
    }
}
