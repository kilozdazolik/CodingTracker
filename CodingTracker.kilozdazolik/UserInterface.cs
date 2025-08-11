using Spectre.Console;
using CodingTracker.kilozdazolik.Enums;

namespace CodingTracker.kilozdazolik;

public class UserInterface
{
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
                
            }
        }
    }
}