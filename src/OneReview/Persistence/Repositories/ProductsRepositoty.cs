using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using OneReview.Domain;
using OneReview.Persistence.Database;
using System.Data;
using System.Xml.Linq;

namespace OneReview.Persistence.Repositories;

public class ProductsRepositoty(IDbConnectionFactory dbConnectionFactory)
{
    private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;

    public async Task CreateAsync(Product product)
    {
        using IDbConnection connection = await _dbConnectionFactory.CreateConnectionAsync();


        string query = """
        INSERT INTO products(id, name, category, sub_category)
        VALUES (@Id, @Name, @Category, @SubCategory)
        """;

        var result = await connection.ExecuteAsync(query, product);

        // result.Throw().IfNegativeOrZero(); //from package throw

        if (result < 1)
        {
            throw new InvalidOperationException("Product not insterted");
        }
    }

    internal async Task<Product?> GetByIdAsync(Guid productId)
    {
        using IDbConnection connection = await _dbConnectionFactory.CreateConnectionAsync();


        string query = """
        SELECT id, name, category, sub_category AS Subcategory
        FROM products
        WHERE id = @Id
        """;

        var product = await connection.QueryFirstOrDefaultAsync<Product>(query, new { Id = productId });

        return product;
       
    }
}

//CREATE TABLE

//    IF NOT EXISTS products(
//    id UUID PRIMARY KEY,
//    name TEXT NOT NULL,
//    category TEXT NOT NULL,
//    sub_category TEXT NOT NULL
//    );
