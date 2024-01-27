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
}