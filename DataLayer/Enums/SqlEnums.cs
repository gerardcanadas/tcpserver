using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Enums
{
    public abstract class SqlEnums
    {
        public enum SqlQueryStatus
        {
            Success,
            Error
        }

        public enum SqlQueryType
        {
            Insert,
            Update,
            Select
        }

        public sealed class SqlQueryOperator
        {
            public static readonly string And = "AND";
            public static readonly string Or = "OR";
            public static readonly string Equal = "=";
            public static string Contains(string str)
            {
                return "LIKE %" + str + "%";
            }
            public static readonly string Like = "LIKE";
        }
    }

}
