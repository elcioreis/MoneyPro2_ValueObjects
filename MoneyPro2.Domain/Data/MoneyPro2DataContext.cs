using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Money2.Domain.Data.Mappings;
using Money2.Domain.Entities;
using Money2.Domain.ValueObjects;
using MoneyPro2.Domain.Entities;

namespace Money2.Domain.Data;

public class MoneyPro2DataContext : DbContext
{
    public MoneyPro2DataContext(DbContextOptions<MoneyPro2DataContext> options)
        : base(options)
    {

    }

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Ignorar os ValueObjects
        modelBuilder.Ignore<Notification>();
        modelBuilder.Ignore<UserName>();
        modelBuilder.Ignore<Name>();
        modelBuilder.Ignore<Email>();
        modelBuilder.Ignore<CPF>();
        modelBuilder.Ignore<Password>();

        // Ignorar as seguintes classes
        modelBuilder.Ignore<Login>();

        modelBuilder.ApplyConfiguration(new UserMap());
    }
}
