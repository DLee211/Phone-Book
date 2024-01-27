using Phone_Book.Models;
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
                    ContactService.ViewContact();
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

    public static void ShowContactsTable(List<Contact> contacts)
    {
        var table = new Table();

        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Email");
        table.AddColumn("PhoneNumber");
        
        foreach (var contact in contacts)
        {
            table.AddRow(
                contact.Id.ToString(),
                contact.Name,
                contact.Email,
                contact.PhoneNumber
            );
        }
        
        AnsiConsole.Write(table);
        
        Console.WriteLine("Enter any key to continue:");
        Console.ReadLine();
    }
}