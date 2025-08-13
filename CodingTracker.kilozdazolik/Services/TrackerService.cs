using System.Data;
using Microsoft.Data.Sqlite;
using CodingTracker.kilozdazolik.Data;
using CodingTracker.kilozdazolik.Models;
using Dapper;

namespace CodingTracker.kilozdazolik.Services;

public class TrackerService
{
    private static string cs = Database.ConnectionString("DefaultConnection");
    
    public void InsertSession(DateTime startDate, DateTime endDate)
    {
        try
        {
            using (IDbConnection conn = new SqliteConnection(cs))
            {
                var sql =
                    "INSERT INTO CodingTracker (StartTime, EndTime, Duration) VALUES (@StartTime, @EndTime, @Duration)";

                Tracker tracker = new()
                {
                    StartTime = startDate,
                    EndTime = endDate,
                };

                conn.Execute(sql, tracker);
            }
        }
        catch (SqliteException ex)
        {
            Console.WriteLine($"Unexpected error happened: {ex.Message}");
        }
    }
    
    public List<Tracker> GetAllSession()
    {
        try
        {
            using (IDbConnection conn = new SqliteConnection(cs))
            {
                var sql =
                    "SELECT * FROM CodingTracker";
                var sessions = conn.Query<Tracker>(sql).ToList();
                return sessions;
            }
        }
        catch (SqliteException ex)
        {
            Console.WriteLine($"Unexpected error happened: {ex.Message}");
            return new List<Tracker>();
        }
    }
    
    public void DeleteSession(Tracker tracker)
    {
        try
        {
            using (IDbConnection conn = new SqliteConnection(cs))
            {
                conn.Execute("DELETE FROM CodingTracker WHERE ID = @Id", tracker);
            }
        }
        catch (SqliteException ex)
        {
            Console.WriteLine($"Unexpected error happened: {ex.Message}");
            throw;
        }
    }

    public void UpdateSession(Tracker tracker)
    {
        try
        {
            using (IDbConnection conn = new SqliteConnection(cs))
            {
                conn.Execute("UPDATE CodingTracker SET StartTime = @StartTime, EndTime = @EndTime WHERE ID = @Id", tracker);
            }
        }
        catch (SqliteException ex)
        {
            Console.WriteLine($"Unexpected error happened: {ex.Message}");
            throw;
        }
    }
    
    
}