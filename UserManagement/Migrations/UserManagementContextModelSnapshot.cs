﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UserManagementService.DataAccessLayer;

namespace UserManagementService.Migrations
{
    [DbContext(typeof(UserManagementContext))]
    partial class UserManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("UserManagementService.Models.ChiliUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ChiliUserRoleId")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SecretAnswer")
                        .HasColumnType("text");

                    b.Property<Guid>("SecretQuestionId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChiliUserRoleId");

                    b.HasIndex("SecretQuestionId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0da09c36-50ac-44fb-a102-8b528bcbad51"),
                            ChiliUserRoleId = new Guid("39bf46f0-cc42-438f-866c-c20c393a307b"),
                            Email = "adminuser@chiliboard.de",
                            PasswordHash = "AQAAAAEAACcQAAAAEMoFpxlv0k75JcYxDckqwIM+Q/OUpBHnG0CGxUrGNbPe8SuCT9BgmnZ5Mb5091WAMg==",
                            RegistrationDate = new DateTime(2022, 1, 6, 8, 25, 16, 835, DateTimeKind.Local).AddTicks(3218),
                            SecretAnswer = "AQAAAAEAACcQAAAAEPefExEpvKEFIqh3cSOKiRu93rkydpnnig0u8J1IiQZMUv0ru6X5Y48DItMKhts2Pw==",
                            SecretQuestionId = new Guid("f7f78ebd-22d5-4861-893e-7dceee4ee4fe"),
                            UserName = "admin"
                        },
                        new
                        {
                            Id = new Guid("bf9657c5-0827-44bb-b902-f627d24c0313"),
                            ChiliUserRoleId = new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                            Email = "casualUser@web.de",
                            PasswordHash = "AQAAAAEAACcQAAAAEAnwfh0wE9Wssf31dZoBIG3QHj7ljGR9OTqwK7bQw+LyZm2buE9sx9F1RJEtzFXV3g==",
                            RegistrationDate = new DateTime(2022, 1, 6, 8, 25, 16, 837, DateTimeKind.Local).AddTicks(9522),
                            SecretAnswer = "AQAAAAEAACcQAAAAEAwPbNZSxsmcgy6YrkT5lS575mrqdpfNsxEd8A3eZFfjio83riTTcUtVsrgB14fDmA==",
                            SecretQuestionId = new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"),
                            UserName = "CasualUser69420"
                        },
                        new
                        {
                            Id = new Guid("8c8dd0dd-a6b6-478d-a298-1011cb5bf060"),
                            ChiliUserRoleId = new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                            Email = "catlover@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEOOx54WrvJyqlxKzryYaEVzJ8Epp8gzL5CKDWnN8N63CP/ks1OuUR8eUGaLgjjvE0Q==",
                            RegistrationDate = new DateTime(2022, 1, 6, 8, 25, 16, 837, DateTimeKind.Local).AddTicks(9533),
                            SecretAnswer = "AQAAAAEAACcQAAAAENjhiQ0jJfztyQikCFmivAqKRr+w6RrCw/UTPCvTcXxgE0OyWNh4H7Q3rEgtgmilqA==",
                            SecretQuestionId = new Guid("f3124fb0-79ce-403b-8cd4-eceafaf2a0ff"),
                            UserName = "CatLover123"
                        },
                        new
                        {
                            Id = new Guid("0da09c36-50ac-44fb-a102-8b528bcbad58"),
                            ChiliUserRoleId = new Guid("39bf46f0-cc42-438f-866c-c20c393a307b"),
                            Email = "nis@chiliboard.de",
                            PasswordHash = "AQAAAAEAACcQAAAAEM4+PFxccFjRIJFhSIFf0yqL97ip4aD4UWCKdTKHszUvf0zx1a0jQ12HZa6Uxq64vQ==",
                            RegistrationDate = new DateTime(2022, 1, 6, 8, 25, 16, 837, DateTimeKind.Local).AddTicks(9488),
                            SecretAnswer = "AQAAAAEAACcQAAAAECfEPj0Kc3WkSjRBD+0A4PHc8fGBUFM/kYmOyVciwPGY4XJ6kH9Hd9E/u+VTewEt2Q==",
                            SecretQuestionId = new Guid("f3124fb0-79ce-403b-8cd4-eceafaf2a0ff"),
                            UserName = "nis"
                        });
                });

            modelBuilder.Entity("UserManagementService.Models.ChiliUserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Rolename")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("39bf46f0-cc42-438f-866c-c20c393a307b"),
                            Rolename = "Admin"
                        },
                        new
                        {
                            Id = new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                            Rolename = "DefaultChiliUser"
                        });
                });

            modelBuilder.Entity("UserManagementService.Models.RefreshToken", b =>
                {
                    b.Property<Guid>("Token")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Invalidated")
                        .HasColumnType("boolean");

                    b.Property<string>("JwtId")
                        .HasColumnType("text");

                    b.Property<bool>("Used")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Token");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("UserManagementService.Models.SecurityQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Question")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SecurityQuestions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f3124fb0-79ce-403b-8cd4-eceafaf2a0ff"),
                            Question = "Was ist Ihr Lieblingsessen?"
                        },
                        new
                        {
                            Id = new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"),
                            Question = "Wie lautet der Geburtsname Ihrer Mutter?"
                        },
                        new
                        {
                            Id = new Guid("f7f78ebd-22d5-4861-893e-7dceee4ee4fe"),
                            Question = "Wie lautet Ihre Lieblingsprimzahl?"
                        });
                });

            modelBuilder.Entity("UserManagementService.Models.ChiliUser", b =>
                {
                    b.HasOne("UserManagementService.Models.ChiliUserRole", "Role")
                        .WithMany()
                        .HasForeignKey("ChiliUserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserManagementService.Models.SecurityQuestion", "SecretQuestion")
                        .WithMany()
                        .HasForeignKey("SecretQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("SecretQuestion");
                });

            modelBuilder.Entity("UserManagementService.Models.RefreshToken", b =>
                {
                    b.HasOne("UserManagementService.Models.ChiliUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
