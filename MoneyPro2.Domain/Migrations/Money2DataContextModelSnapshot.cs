﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Money2.Domain.Data;

#nullable disable

namespace MoneyPro2.Domain.Migrations
{
    [DbContext(typeof(Money2DataContext))]
    partial class Money2DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Money2.Domain.Entities.User", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Money2.Domain.Entities.User", b =>
                {
                    b.OwnsOne("Money2.Domain.ValueObjects.CPF", "CPF", b1 =>
                        {
                            b1.Property<short>("UserId")
                                .HasColumnType("smallint");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("CPF");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Money2.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<short>("UserId")
                                .HasColumnType("smallint");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.HasIndex("Address")
                                .IsUnique()
                                .HasDatabaseName("IX_User_Email");

                            SqlServerIndexBuilderExtensions.IsClustered(b1.HasIndex("Address"), false);

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Money2.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<short>("UserId")
                                .HasColumnType("smallint");

                            b1.Property<string>("FullName")
                                .IsRequired()
                                .HasMaxLength(82)
                                .HasColumnType("NVARCHAR")
                                .HasColumnName("Name");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Money2.Domain.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<short>("UserId")
                                .HasColumnType("smallint");

                            b1.Property<string>("MD5")
                                .IsRequired()
                                .HasMaxLength(32)
                                .HasColumnType("CHAR")
                                .HasColumnName("PasswordHash");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Money2.Domain.ValueObjects.UserName", "UserName", b1 =>
                        {
                            b1.Property<short>("UserId")
                                .HasColumnType("smallint");

                            b1.Property<string>("Username")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("Username");

                            b1.HasKey("UserId");

                            b1.HasIndex("Username")
                                .IsUnique()
                                .HasDatabaseName("IX_User_Username");

                            SqlServerIndexBuilderExtensions.IsClustered(b1.HasIndex("Username"), false);

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("CPF")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();

                    b.Navigation("UserName")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
