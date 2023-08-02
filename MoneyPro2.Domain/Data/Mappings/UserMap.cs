using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Money2.Domain.Entities;

namespace Money2.Domain.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.Ignore(x => x.Notifications);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

        // Incluindo os ValueObjects no mapeamento
        builder
            .OwnsOne(o => o.UserName)
            .Property(p => p.Username)
            .IsRequired(true)
            .HasColumnName("Username")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20);

        builder
            .OwnsOne(o => o.Name)
            .Property(p => p.FullName)
            .IsRequired(true)
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(82);

        builder
            .OwnsOne(o => o.Email)
            .Property(p => p.Address)
            .IsRequired(true)
            .HasColumnName("Email")
            .HasColumnType("VARCHAR")
            .HasMaxLength(200);

        builder
            .OwnsOne(o => o.CPF)
            .Property(p => p.Valor)
            .IsRequired(true)
            .HasColumnName("CPF")
            .HasColumnType("VARCHAR")
            .HasMaxLength(11);

        builder
            .OwnsOne(o => o.Password)
            .Property(p => p.MD5)
            .IsRequired(true)
            .HasColumnName("PasswordHash")
            .HasColumnType("CHAR")
            .HasMaxLength(32);

        // Criando indices para os ValueObjects
        builder
            .OwnsOne(p => p.UserName)
            .HasIndex(i => i.Username)
            .IsClustered(false)
            .HasDatabaseName("IX_User_Username")
            .IsUnique();

        builder
            .OwnsOne(p => p.Email)
            .HasIndex(i => i.Address)
            .IsClustered(false)
            .HasDatabaseName("IX_User_Email")
            .IsUnique();
    }
}
