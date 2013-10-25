using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataDefinition
{
    public class enumerators
    {
        public enum ConnectionType
        {
            OLEDB,
            ODBC,
            SQLSSERVER
        }

        public enum SQLDataType
        {
            DOUBLE,
            INT,
            DATETIME,
            VARCHAR,
            FULLTEXT,
            CHAR,
            XML,
            BOOL,
            BINARY
        }

        public enum SQLQueryType
        {
            UPDATE,
            INSERT,
            DELETE
        }
    }
}
