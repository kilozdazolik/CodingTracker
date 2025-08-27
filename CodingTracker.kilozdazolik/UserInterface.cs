using CodingTracker.kilozdazolik.Controllers;
using Spectre.Console;
using CodingTracker.kilozdazolik.Enums;

namespace CodingTracker.kilozdazolik;

public class UserInterface
{
    private static TrackerController _tracker = new();
    private static Helper _helper = new();
    internal static void MainMenu()
    {
        while (true) {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuAction>()
                    .Title("What do you want to do [green]next[/]?")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to choose an option)[/]")
                    .AddChoices(Enum.GetValues<MenuAction>()));
        
            switch (choice)
            {
                case MenuAction.StartSession:
                    _helper.ShowWithPause(_tracker.StartSession);
                    break;
                case MenuAction.AddSession:
                    _helper.ShowWithPause(_tracker.AddSession);
                    break;
                case MenuAction.ViewSessions:
                    ViewOptions();
                    break;
                case MenuAction.DeleteSessions:
                    _helper.ShowWithPause(_tracker.DeleteSession);
                    break;
                case MenuAction.EditSessions:
                    _helper.ShowWithPause(_tracker.EditSession);
                    break;
                
                case MenuAction.Quit:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    private static void ViewOptions()
    {
        var filterChoice = AnsiConsole.Prompt(
            new SelectionPrompt<ViewAction>()
                .Title("What do you want to do [green]next[/]?")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to choose an option)[/]")
                .AddChoices(Enum.GetValues<ViewAction>()));

        switch (filterChoice)
        {
            case ViewAction.AllSession:
                _helper.ShowWithPause(_tracker.ViewAllSessions);
                break;
            case ViewAction.AscendingOrder:
                _helper.ShowWithPause(() => _tracker.ViewSessionsByDate(true));
                break;
            case ViewAction.DescendingOrder:
                _helper.ShowWithPause(() => _tracker.ViewSessionsByDate(false));
                break;
        }
    }
}