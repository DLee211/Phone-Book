using Spectre.Console;

namespace Phone_Book;

public static class UserInterface
{
    static internal void MainMenu()
    {
        var isAppRunning = true;
        while (isAppRunning)
        {
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<>())
        }
    }
}