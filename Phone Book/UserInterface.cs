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
            Console.Clear();
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

            List<Contact>? contacts;
            switch (option)
            {
                case Enums.MainMenuOptions.AddContacts:
                    Console.Clear();
                    ContactService.InsertContact();
                    break;
                
                case Enums.MainMenuOptions.ViewContacts:
                    Console.Clear();
                    ContactService.ViewContact();
                    break;
                
                case Enums.MainMenuOptions.SearchContacts:
                    Console.Clear();
                    SearchMenu();
                    break;
                
                case Enums.MainMenuOptions.UpdateContacts:
                    Console.Clear();
                    contacts = ContactController.GetContacts();
                    ShowContactsTable(contacts);
                    ContactService.UpdateContacts();
                    break;
                
                case Enums.MainMenuOptions.DeleteContacts:
                    Console.Clear();
                    contacts = ContactController.GetContacts();
                    ShowContactsTable(contacts);
                    ContactService.RemoveContact();
                    break;
                
                case Enums.MainMenuOptions.Quit:
                    Console.Clear();
                    Console.WriteLine("Goodbye!");
                    isAppRunning = false;
                    break;
            }
        }
    }

    static internal void SearchMenu()
    {
        var isSearchMenuRunning = true;
        while (isSearchMenuRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.ContactMenuOptions>()
                    .Title("Contact Search Menu")
                    .AddChoices(
                        Enums.ContactMenuOptions.SearchContactName,
                        Enums.ContactMenuOptions.SearchContactEmail,
                        Enums.ContactMenuOptions.SearchContactPhoneNumber,
                        Enums.ContactMenuOptions.Quit
                    ));
            
            switch (option)
            {
                case Enums.ContactMenuOptions.SearchContactName:
                    Console.Clear();
                    ContactService.GetName();
                    break;
                
                case Enums.ContactMenuOptions.SearchContactEmail:
                    Console.Clear();
                    ContactService.GetEmail();
                    break;
                
                case Enums.ContactMenuOptions.SearchContactPhoneNumber:
                    Console.Clear();
                    ContactService.GetPhoneNumber();
                    break;
                
                case Enums.ContactMenuOptions.Quit:
                    Console.Clear();
                    isSearchMenuRunning = false;
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
    }

    public static void ShowContact(Contact contact)
    {
        var panel = new Panel($@"Name:{contact.Name} Email:{contact.Email} Phone Number:{contact.PhoneNumber}");
        panel.Header = new PanelHeader($"{contact.Name}");
        panel.Padding = new Padding(2, 2, 2, 2);
        
        AnsiConsole.Write(panel);
        
        Console.WriteLine("Enter any key to continue");
        Console.ReadLine();
    }
}