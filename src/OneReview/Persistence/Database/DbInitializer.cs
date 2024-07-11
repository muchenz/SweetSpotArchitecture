using DbUp;
using System.Reflection;

namespace OneReview.Persistence.Database;

public static class DbInitializer
{
    public static void  Initialize(string connectionString)
    {
        EnsureDatabase.For.PostgresqlDatabase(connectionString);

        var upgrader = DeployChanges.To
            .PostgresqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .WithTransaction()
            .LogToConsole()
            .Build();

        if (upgrader.IsUpgradeRequired()) // from Nick Chapsas 'The Easiest Way To Run Database Migrations'
        {
            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                throw new InvalidOperationException("Failed set db");
            }
        }
        }
    }
