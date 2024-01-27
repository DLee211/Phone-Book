using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Phone_Book.Models;

namespace Phone_Book;

public class ContactContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer( "Server=(localdb)\\MSSQLLocalDB;Database=contacts.db;Integrated Security=True");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.ToTable("Contacts");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.PhoneNumber).IsRequired();
        });
        
        modelBuilder.Entity<Contact>().HasData(
            new Contact { Id = 1, Name = "John Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890" },
            new Contact { Id = 2, Name = "Jane Doe", Email = "jane.doe@example.com", PhoneNumber = "987-654-3210" },
            new Contact { Id = 3, Name = "Alice Smith", Email = "alice.smith@example.com", PhoneNumber = "555-123-4567" },
            new Contact { Id = 4, Name = "Bob Johnson", Email = "bob.johnson@example.com", PhoneNumber = "777-888-9999" },
            new Contact { Id = 5, Name = "Eva Brown", Email = "eva.brown@example.com", PhoneNumber = "111-222-3333" },
            new Contact { Id = 6, Name = "Michael Davis", Email = "michael.davis@example.com", PhoneNumber = "444-555-6666" },
            new Contact { Id = 7, Name = "Sophia Wilson", Email = "sophia.wilson@example.com", PhoneNumber = "666-777-8888" },
            new Contact { Id = 8, Name = "David Miller", Email = "david.miller@example.com", PhoneNumber = "888-999-0000" },
            new Contact { Id = 9, Name = "Olivia Anderson", Email = "olivia.anderson@example.com", PhoneNumber = "222-333-4444" },
            new Contact { Id = 10, Name = "Liam White", Email = "liam.white@example.com", PhoneNumber = "999-000-1111" }
        );
    }
}

