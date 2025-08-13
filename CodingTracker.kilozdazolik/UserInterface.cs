using CodingTracker.kilozdazolik.Controllers;
using Spectre.Console;
using CodingTracker.kilozdazolik.Enums;

namespace CodingTracker.kilozdazolik;

public class UserInterface
{
    private static TrackerController _tracker = new();
    internal static void MainMenu()
    {
        while (true) {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuAction>()
                    .Title("What do you want to do [green]next[/]?")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to choose an option)[/]")
                    .AddChoices(Enum.GetValues<MenuAction>()));
        
            Console.Clear();
        
            switch (choice)
            {
                case MenuAction.StartSession:
                    _tracker.StartSession();
                    break;
                case MenuAction.AddSession:
                    _tracker.AddSession();
                    break;
                case MenuAction.ViewSessions:
                    _tracker.ViewAllSessions();
                    break;
                case MenuAction.DeleteSessions:
                    _tracker.DeleteSession();
                    break;
                case MenuAction.EditSessions:
                    _tracker.EditSession();
                    break;
            }
        }
    }
}