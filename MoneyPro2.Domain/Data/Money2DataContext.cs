using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Money2.Domain.Data.Mappings;
using Money2.Domain.Entities;
using Money2.Domain.ValueObjects;

namespace Money2.Domain.Data;

public class Money2DataContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(
            "Server=localhost;Database=MoneyPro2;Integrated Security=True;Trust Server Certificate=true;"
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Ignorar os ValueObjects
        modelBuilder.Ignore<Notification>();
        modelBuilder.Ignore<UserName>();
        modelBuilder.Ignore<Name>();
        modelBuilder.Ignore<Email>();
        modelBuilder.Ignore<CPF>();
        modelBuilder.Ignore<Password>();

        modelBuilder.ApplyConfiguration(new UserMap());
    }
}
