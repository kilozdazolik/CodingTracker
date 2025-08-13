using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace CodingTracker.kilozdazolik.Data;

internal static class Database
{
    private static readonly IConfiguration _config;

    static Database()
    {
        _config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();
    }
    
    public static string ConnectionString(string name)
    {
        return _config.GetConnectionString(name);
    }

    public static void CreateDatabase()
    {
        using (IDbConnection db = new SqliteConnection(ConnectionString("DefaultConnection")))
        {
            string createTable = @"
            CREATE TABLE IF NOT EXISTS CodingTracker(
            ID INTEGER PRIMARY KEY,
            StartTime TEXT NOT NULL,
            EndTime TEXT NOT NULL,
            Duration TEXT
        )";

            db.Execute(createTable);
        }
    }
}