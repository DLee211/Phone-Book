﻿using Microsoft.EntityFrameworkCore;
using Phone_Book.Models;

namespace Phone_Book;

public class ContactController
{
    public static void AddContact(Contact contact)
    {
        using var db = new ContactContext();
        db.Add(contact);
        db.SaveChanges();
    }

    public static List<Contact> GetContacts()
    {
        using var db = new ContactContext();
        var contacts = db.Contacts.ToList();
        return contacts;
    }

    public static void DeleteContact(Contact contact)
    {
        using var db = new ContactContext();
        db.Remove(contact);
        db.SaveChanges();
    }

    public static void UpdateContact(Contact contact)
    {
        using var db = new ContactContext();
        db.Update(contact);
        db.SaveChanges();
    }
}