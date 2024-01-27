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
                new SelectionPrompt<Enums.MainMenuOptions>()
                    .Title("Phone Book Main Menu")
                    .AddChoices(
                        Enums.MainMenuOptions.AddContacts,
                        Enums.MainMenuOptions.ViewContacts,
                        Enums.MainMenuOptions.SearchContacts,
                        Enums.MainMenuOptions.UpdateContacts,
                        Enums.MainMenuOptions.DeleteContacts,
                        Enums.MainMenuOptions.Quit
                    ));

            switch (option)
            {
                case Enums.MainMenuOptions.AddContacts:
                    ContactService.InsertContact();
                    break;
                
                case Enums.MainMenuOptions.ViewContacts:
                    break;
                
                case Enums.MainMenuOptions.SearchContacts:
                    break;
                
                case Enums.MainMenuOptions.UpdateContacts:
                    break;
                
                case Enums.MainMenuOptions.DeleteContacts:
                    break;
                
                case Enums.MainMenuOptions.Quit:
                    Console.WriteLine("Goodbye!");
                    isAppRunning = false;
                    break;
            }
        }
    }
}