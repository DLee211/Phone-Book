using Microsoft.EntityFrameworkCore;
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
            new Contact { Id = 1, Name = "John Doe", Email = "john.doe@example.com", PhoneNumber = "1234567890" },
            new Contact { Id = 2, Name = "Jane Doe", Email = "jane.doe@example.com", PhoneNumber = "9876543210" },
            new Contact { Id = 3, Name = "Alice Smith", Email = "alice.smith@example.com", PhoneNumber = "5551234567" },
            new Contact { Id = 4, Name = "Bob Johnson", Email = "bob.johnson@example.com", PhoneNumber = "7778889999" },
            new Contact { Id = 5, Name = "Eva Brown", Email = "eva.brown@example.com", PhoneNumber = "1112223333" },
            new Contact { Id = 6, Name = "Michael Davis", Email = "michael.davis@example.com", PhoneNumber = "4445556666" },
            new Contact { Id = 7, Name = "Sophia Wilson", Email = "sophia.wilson@example.com", PhoneNumber = "6667778888" },
            new Contact { Id = 8, Name = "David Miller", Email = "david.miller@example.com", PhoneNumber = "8889990000" },
            new Contact { Id = 9, Name = "Olivia Anderson", Email = "olivia.anderson@example.com", PhoneNumber = "2223334444" },
            new Contact { Id = 10, Name = "Liam White", Email = "liam.white@example.com", PhoneNumber = "9990001111" }
        );
    }
}

