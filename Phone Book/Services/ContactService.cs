using Phone_Book.Models;
using Spectre.Console;

namespace Phone_Book;

public class ContactService
{
    public static void InsertContact()
    {
        var contact = new Contact();

        contact.Name = AnsiConsole.Ask<string>("Contact Name:");
        contact.Email = AnsiConsole.Ask<string>("Contact Email:");
        contact.PhoneNumber = AnsiConsole.Ask<string>("Contact PhoneNumber:");
        ContactController.AddContact(contact);
    }

    public static void ViewContact()
    {
        var contacts = ContactController.GetContacts();
        UserInterface.ShowContactsTable(contacts);
        
        Console.WriteLine("Enter any key to continue:");
        Console.ReadLine();
    }

    public static void RemoveContact()
    {
        var contact = new Contact();
        contact.Id = AnsiConsole.Ask<int>("Which Id do you want to delete?");
        ContactController.DeleteContact(contact);
    }
}