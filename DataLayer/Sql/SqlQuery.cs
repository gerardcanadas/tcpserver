using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Sql
{
    public class SqlQuery
    {
        public class Select : SqlQuery
        {
            public List<string> Fields { get; set; }
            public string From { get; set; }

            public List<WhereStatement> Where { get; set; }
            public string OrderBy { get; set; }

            public Select()
            {
            }

            public Select(Select SelectStament)
            {
                this.Fields = SelectStament.Fields;
                this.From = SelectStament.From;
                this.Where = SelectStament.Where;
                this.OrderBy = SelectStament.OrderBy;
            }
        }

        public class Insert : SqlQuery
        {
            public string Into { get; set; }
            public Dictionary<string, string> Fields { get; set; }

            public Insert()
            {

            }

            public Insert(Insert InsertStatement)
            {
                this.Into = InsertStatement.Into;
                this.Fields = InsertStatement.Fields;
            }
        }

        public class Update : SqlQuery
        {
            public string Table { get; set; }
            public string Set { get; set; }
            public WhereStatement Where { get; set; }

            public Update()
            {
            }

            public Update(Update UpdateStatement)
            {
                this.Table = UpdateStatement.Table;
                this.Set = UpdateStatement.Set;
                this.Where = UpdateStatement.Where;
            }
        }

        public SqlQuery()
        {
        }


        public SqlQuery(Select SelectStatement)
        {
            //SqlQuery.
        }
    }


    public class WhereStatement : SqlQuery
    {
        public string WhereField { get; set; }
        public string WhereCondition { get; set; }
        public string WhereOperator { get; set; }
        public string WhereSeparator { get; set; }
        public WhereStatement()
        {

        }
    }
}
