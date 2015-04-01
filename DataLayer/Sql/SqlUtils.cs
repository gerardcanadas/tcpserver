using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Sql
{
    public abstract class SqlUtils
    {
        public static SqlQuery ParseQuery(SqlQuery query, SqlEnums.SqlQueryType type)
        {
            switch (type)
            {
                case SqlEnums.SqlQueryType.Insert:
                    return new SqlQuery.Insert((SqlQuery.Insert)query);

                case SqlEnums.SqlQueryType.Select:
                    return new SqlQuery.Select((SqlQuery.Select)query);

                //case SqlQueryType.Update:
                //    break;

                default:
                    return new SqlQuery();
            }
        }

        public static string BuildSqlQuery(SqlQuery query, SqlEnums.SqlQueryType type)
        {
            switch (type)
            {
                case SqlEnums.SqlQueryType.Insert:
                    return BuildInsertQuery((SqlQuery.Insert)query);

                case SqlEnums.SqlQueryType.Select:
                    return BuildSelectQuery((SqlQuery.Select)query);

                case SqlEnums.SqlQueryType.Update:
                    return BuildUpdateQuery((SqlQuery.Update)query);

                default:
                    return "";
            }
        }

        private static string BuildSelectQuery(SqlQuery.Select SelectStatement)
        {
            StringBuilder QueryBuilder = new StringBuilder();

            QueryBuilder.AppendLine("SELECT ");
            for (int i = 0; i < SelectStatement.Fields.Count; i++)
            {
                if (i == SelectStatement.Fields.Count - 1)
                {
                    QueryBuilder.Append(SelectStatement.Fields[i]);
                }
                else
                {
                    QueryBuilder.Append(", " + SelectStatement.Fields[i]);
                }
            }

            QueryBuilder.AppendLine("FROM " + SelectStatement.From);

            if (SelectStatement.Where != null && SelectStatement.Where.Count > 0) 
            {
                QueryBuilder.AppendLine("WHERE ");
                foreach (WhereStatement WhereRow in SelectStatement.Where)
                {
                    if (WhereRow.WhereSeparator != null)
                    {
                        QueryBuilder.AppendLine(WhereRow.WhereSeparator + " ");
                    }
                    QueryBuilder.Append(WhereRow.WhereField + " ");
                    QueryBuilder.Append(WhereRow.WhereOperator + " ");
                    QueryBuilder.Append("'" + WhereRow.WhereCondition + "'");
                }
            }

            if (!string.IsNullOrEmpty(SelectStatement.OrderBy))
            {
                QueryBuilder.AppendLine("ORDER BY " + SelectStatement.OrderBy);
            }

            return QueryBuilder.ToString();
        }

        private static string BuildInsertQuery(SqlQuery.Insert InsertStatement)
        {
            return "";
        }

        private static string BuildUpdateQuery(SqlQuery.Update UpdateStatement)
        {
            return "";
        }

    }
}
