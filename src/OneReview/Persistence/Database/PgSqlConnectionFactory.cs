using Npgsql;
using System.Data;

namespace OneReview.Persistence.Database;

public class PgSqlConnectionFactory (string connectionString): IDbConnectionFactory
{
    private readonly string _connectionString = connectionString;

    public async Task<IDbConnection> CreateConnectionAsync()
    {
        var connection = new NpgsqlConnection(_connectionString);

        await connection.OpenAsync();

        return connection;
    }
}
