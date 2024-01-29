﻿using Phone_Book.Models;
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

    public static void UpdateContacts()
    {
        var contact = GetContactInput();
        
        contact.Name = AnsiConsole.Confirm("Update name?")
            ? AnsiConsole.Ask<string>("Contact's new name:")
            : contact.Name;
        
        contact.Email = AnsiConsole.Confirm("Update email?")
            ? AnsiConsole.Ask<string>("Contact's new email:")
            : contact.Email;
        
        contact.PhoneNumber = AnsiConsole.Confirm("Update phone number?")
            ? AnsiConsole.Ask<string>("Contact's new phone number:")
            : contact.PhoneNumber;

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
}