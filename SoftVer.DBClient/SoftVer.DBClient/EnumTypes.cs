using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftVer.DBClient
{
    public enum DatabaseType
    {
        Access,
        SQLServer,
        Oracle
    }

    public enum ParameterType
    {
        Integer,
        Char,
        Varchar
    }

    public enum ExecuteType
    {
        Reader,
        ReaderAsync,
        NonQuery,
        NonQueryAsync,
        Scalar,
        Table                        
    }


}
