using Spectre.Console;
namespace CodingTracker.kilozdazolik;

public class Helper
{
    public bool ConfirmMessage(string message, string element)
    {
        var confirm = AnsiConsole.Confirm($"Are you sure you want to {message} [red]{element}[/]?");

        return confirm;
    }
}