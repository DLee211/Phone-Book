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
        Validation.ValidateEmail(contact);
        contact.PhoneNumber = AnsiConsole.Ask<string>("Contact PhoneNumber:");
        Validation.ValidatePhoneNumber(contact);
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

    public static void UpdateContacts()
    {
        var contact = GetContactInput();
        
        contact.Name = AnsiConsole.Confirm("Update name?")
            ? AnsiConsole.Ask<string>("Contact's new name:")
            : contact.Name;

        if (AnsiConsole.Confirm("Update email?"))
        {
            string newEmail;
            do
            {
                newEmail = AnsiConsole.Ask<string>("Contact's new email:");
                if (!Validation.IsValidEmail(newEmail))
                {
                    AnsiConsole.MarkupLine("[red]Invalid email format. Please enter a valid email address.[/]");
                }
            } while (!Validation.IsValidEmail(newEmail));
            contact.Email = newEmail;
        }
        
        if (AnsiConsole.Confirm("Update phone number?"))
        {
            string newPhoneNumber;
            do
            {
                newPhoneNumber = AnsiConsole.Ask<string>("Contact's new phone number:");
                if (!Validation.IsValidPhoneNumber(newPhoneNumber))
                {
                    AnsiConsole.MarkupLine("[red]Invalid phone number format. Please enter a valid phone number.[/]");
                }
            } while (!Validation.IsValidPhoneNumber(newPhoneNumber));
            contact.PhoneNumber = newPhoneNumber;
        }

        ContactController.UpdateContact(contact);

    }

    private static Contact GetContactInput()
    {
        var contacts = ContactController.GetContacts();

        var contactsArray = contacts.Select(x => x.Id);
        
        var option = AnsiConsole.Prompt(new SelectionPrompt<int>()
            .Title("Choose Product")
            .AddChoices(contactsArray));
        
        var contact = contacts.Single(x => x.Id == option);

        return contact;
    }

    public static void GetName()
    {
        var contact = GetContactNameInput();
        UserInterface.ShowContact(contact);
    }

    private static Contact GetContactNameInput()
    {
        var contacts = ContactController.GetContacts();

        var contactsArray = contacts.Select(x => x.Name);
        
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose Name")
            .AddChoices(contactsArray));
        
        var contact = contacts.Single(x => x.Name == option);

        return contact;
    }

    public static void GetEmail()
    {
        var contact = GetContactEmailInput();
        UserInterface.ShowContact(contact);
    }

    private static Contact GetContactEmailInput()
    {
        var contacts = ContactController.GetContacts();

        var contactsArray = contacts.Select(x => x.Email);
        
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose Email")
            .AddChoices(contactsArray));
        
        var contact = contacts.Single(x => x.Email == option);

        return contact;
    }

    public static void GetPhoneNumber()
    {
        var contact = GetContactPhoneNumberInput();
        UserInterface.ShowContact(contact);
    }

    private static Contact GetContactPhoneNumberInput()
    {
        var contacts = ContactController.GetContacts();

        var contactsArray = contacts.Select(x => x.PhoneNumber);
        
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose PhoneNumber")
            .AddChoices(contactsArray));
        
        var contact = contacts.Single(x => x.PhoneNumber == option);

        return contact;
    }
}