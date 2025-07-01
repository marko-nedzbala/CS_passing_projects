using System.Data;
using System.Data.Common;
using System.Data.Odbc;
#if PC
using System.Data.OleDb;
#endif
using Microsoft.Data.SqlClient;


Setup(DataProviderEnum.SqlServer);

#if PC
Setup(DataProviderEnum.OleDb);
#endif

Setup(DataProviderEnum.Odbc);
Setup(DataProviderEnum.None);


















void Setup(DataProviderEnum provider)
{
    IDbConnection myConnection = GetConnection(provider);
    Console.WriteLine($"Your connection is a {myConnection?.GetType().Name ?? "unrecgnized type"}");

}

IDbConnection GetConnection(DataProviderEnum dataProvider)
{
    return dataProvider switch
    {
        DataProviderEnum.SqlServer => new SqlConnection(),
#if PC
        DataProviderEnum.OleDb => new OleDbConnection(),
#endif 
        DataProviderEnum.Odbc => new OleDbConnection(),
        _ => null,
    };
}



enum DataProviderEnum
{
    SqlServer,
#if PC
    OleDb,
#endif
    Odbc,
    None
}


























