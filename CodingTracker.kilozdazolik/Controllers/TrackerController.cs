using System.Diagnostics;
using System.Globalization;
using CodingTracker.kilozdazolik.Services;
using Spectre.Console;
using CodingTracker.kilozdazolik.Models;
namespace CodingTracker.kilozdazolik.Controllers;

public class TrackerController
{
    private TrackerService _trackerService = new();

    public void StartSession()
    {
        DateTime now = DateTime.Now;
        Stopwatch sw = new Stopwatch();
        
        AnsiConsole.MarkupLine("Press the Enter key to begin:");
        Console.ReadLine();
        sw.Start();

        while (sw.IsRunning)
        {
            Console.Clear();
            Console.WriteLine(sw.Elapsed);
            Thread.Sleep(1000);
        }
        
        AnsiConsole.MarkupLine("Press the Enter key to stop:");
        Console.ReadLine();
        sw.Stop();

        Console.WriteLine($"Elapsed time: {sw.Elapsed}");
        
    }
    public void AddSession()
    {
        AnsiConsole.MarkupLine("Add a new coding session");
        var startDate = AnsiConsole.Prompt(
            new TextPrompt<DateTime>("Please write the starting date in this format: (dd-mm-yyyy HH:mm)"));
        var endDate = AnsiConsole.Prompt(
            new TextPrompt<DateTime>("Please write the ending date in this format: (dd-mm-yyyy HH:mm)"));

        _trackerService.InsertSession(startDate, endDate);
        
        AnsiConsole.MarkupLine("Session succesfuly added!");
    }

    public void ViewAllSessions()
    {
        List<Tracker> allSessions = _trackerService.GetAllSession();

        if (allSessions.Any())
        {
            var table = new Table();
            table.Border(TableBorder.Rounded);
            
            table.AddColumn("[yellow]ID[/]");
            table.AddColumn("[yellow]Starting date[/]");
            table.AddColumn("[yellow]Ending date[/]");
            table.AddColumn("[yellow]Duration[/]");

            foreach (var session in allSessions)
            {
                table.AddRow(
                    session.Id.ToString(),
                    $"[blue]{session.StartTime.ToString("dd-MM-yyyy HH:mm", CultureInfo.GetCultureInfo("en-US"))}[/]",
                    $"[cyan]{session.EndTime.ToString("dd-MM-yyyy HH:mm", CultureInfo.GetCultureInfo("en-US"))}[/]",
                    $"[green]{session.Duration}[/]"
                );
            }
            
            AnsiConsole.Write(table);
        }
        else
        {
            AnsiConsole.MarkupLine("I could not find any session.");
        }
        
        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }
}