using Microsoft.EntityFrameworkCore;
using Phone_Book.Models;

namespace Phone_Book;

public class ContactContext
{
    public DbSet<Contact> Contacts { get; set; }
    
    protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer($"Data Source = contact.db")
            .EnableSensitiveDataLogging();
}
