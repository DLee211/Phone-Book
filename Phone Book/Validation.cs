using System.Text.RegularExpressions;
using Phone_Book.Models;
using Spectre.Console;

namespace Phone_Book;

public class Validation
{
    public static Contact ValidateEmail(Contact contact)
    { 
        while (!IsValidEmail(contact.Email)) 
        { 
            AnsiConsole.MarkupLine("[red]Invalid email format. Please enter a valid email address.[/]"); 
            contact.Email = AnsiConsole.Ask<string>("Contact Email:");
        }
        return contact;
    }
    
    public static Contact ValidatePhoneNumber(Contact contact)
    { 
        while (!IsValidPhoneNumber(contact.PhoneNumber)) 
        { 
            AnsiConsole.MarkupLine("[red]Invalid Phone Number format. Please enter a valid phone number.[/]"); 
            contact.PhoneNumber = AnsiConsole.Ask<string>("Contact Phone Number:");
        }
        return contact;
    }

    internal static bool IsValidEmail(string email)
    {
        string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        return Regex.IsMatch(email, emailPattern);
    }

    internal static bool IsValidPhoneNumber(string phoneNumber)
    {
        string phonePattern = @"^\d{10}$";
        return Regex.IsMatch(phoneNumber, phonePattern);
    }
}