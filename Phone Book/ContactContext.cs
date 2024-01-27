using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Phone_Book.Models;

namespace Phone_Book;

public class ContactContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }
}

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var connectionString = configuration.GetConnectionString("DbCoreConnectionString");
        optionsBuilder.UseSqlServer(connectionString);
    }
}
