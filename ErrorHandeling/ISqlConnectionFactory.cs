using System.Data;
using Microsoft.Data.SqlClient;
using NEventStore.Persistence.Sql;

namespace ErrorHandeling;

public class SqlConnectionFactory: IConnectionFactory
{
    private readonly string _connectionString;
    private SqlConnection _sqlConnection;
    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
        _sqlConnection = new SqlConnection(_connectionString);
    }
    public IDbConnection Open()
    {
        _sqlConnection.Open();
        return _sqlConnection;
    }

    public Type GetDbProviderFactoryType()
    {
        return typeof(SqlConnectionFactory);
    }
}