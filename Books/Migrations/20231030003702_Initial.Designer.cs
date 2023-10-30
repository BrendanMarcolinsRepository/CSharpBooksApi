﻿// <auto-generated />
using System;
using Books.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Books.Migrations
{
    [DbContext(typeof(BooksDbContext))]
    [Migration("20231030003702_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookUser", b =>
                {
                    b.Property<Guid>("BooksId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uuid");

                    b.HasKey("BooksId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("BookUser", (string)null);

                    b.HasData(
                        new
                        {
                            BooksId = new Guid("ad241e9a-dc28-4a30-93e2-300402631654"),
                            UsersId = new Guid("eac69ca4-a917-4faf-9e3e-5bff6a951576")
                        },
                        new
                        {
                            BooksId = new Guid("941e317b-77e5-4f7d-915f-beb98541e560"),
                            UsersId = new Guid("eac69ca4-a917-4faf-9e3e-5bff6a951576")
                        },
                        new
                        {
                            BooksId = new Guid("2a7ada53-e3f7-4154-8737-dfee6aff1b80"),
                            UsersId = new Guid("eac69ca4-a917-4faf-9e3e-5bff6a951576")
                        },
                        new
                        {
                            BooksId = new Guid("9c9e4237-bd98-4dda-8fb3-9e6ab9a75963"),
                            UsersId = new Guid("eac69ca4-a917-4faf-9e3e-5bff6a951576")
                        });
                });

            modelBuilder.Entity("Books.Models.Domain.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Author");

                    b.HasData(
                        new
                        {
                            Id = new Guid("06580836-f2af-42c0-b5a7-479975ef1c9d"),
                            Name = "Neil Stephenson"
                        },
                        new
                        {
                            Id = new Guid("302afacb-becd-4dfc-9186-5c7eaa93424b"),
                            Name = "Dan Simmons"
                        });
                });

            modelBuilder.Entity("Books.Models.Domain.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<string>("BookCover")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PublisherId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId")
                        .IsUnique();

                    b.HasIndex("DifficultyId")
                        .IsUnique();

                    b.HasIndex("GenreId")
                        .IsUnique();

                    b.HasIndex("PublisherId")
                        .IsUnique();

                    b.ToTable("Book");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ad241e9a-dc28-4a30-93e2-300402631654"),
                            AuthorId = new Guid("06580836-f2af-42c0-b5a7-479975ef1c9d"),
                            BookCover = "",
                            Description = "",
                            DifficultyId = new Guid("166373b8-74e9-4b99-bd3d-e7dd77b1590b"),
                            GenreId = new Guid("1ae27bf6-6b8e-4cfd-a23d-d16f232669e2"),
                            Name = "Snow Crash",
                            PublisherId = new Guid("5104a982-9ee5-4cf8-b947-037a1728e427")
                        },
                        new
                        {
                            Id = new Guid("941e317b-77e5-4f7d-915f-beb98541e560"),
                            AuthorId = new Guid("06580836-f2af-42c0-b5a7-479975ef1c9d"),
                            BookCover = "",
                            Description = "",
                            DifficultyId = new Guid("166373b8-74e9-4b99-bd3d-e7dd77b1590b"),
                            GenreId = new Guid("1ae27bf6-6b8e-4cfd-a23d-d16f232669e2"),
                            Name = "Cryptonomicon",
                            PublisherId = new Guid("5104a982-9ee5-4cf8-b947-037a1728e427")
                        },
                        new
                        {
                            Id = new Guid("2a7ada53-e3f7-4154-8737-dfee6aff1b80"),
                            AuthorId = new Guid("302afacb-becd-4dfc-9186-5c7eaa93424b"),
                            BookCover = "",
                            Description = "",
                            DifficultyId = new Guid("166373b8-74e9-4b99-bd3d-e7dd77b1590b"),
                            GenreId = new Guid("1ae27bf6-6b8e-4cfd-a23d-d16f232669e2"),
                            Name = "Hyperion",
                            PublisherId = new Guid("5104a982-9ee5-4cf8-b947-037a1728e427")
                        },
                        new
                        {
                            Id = new Guid("9c9e4237-bd98-4dda-8fb3-9e6ab9a75963"),
                            AuthorId = new Guid("302afacb-becd-4dfc-9186-5c7eaa93424b"),
                            BookCover = "",
                            Description = "",
                            DifficultyId = new Guid("166373b8-74e9-4b99-bd3d-e7dd77b1590b"),
                            GenreId = new Guid("1ae27bf6-6b8e-4cfd-a23d-d16f232669e2"),
                            Name = "Fall of Hyperion",
                            PublisherId = new Guid("5104a982-9ee5-4cf8-b947-037a1728e427")
                        });
                });

            modelBuilder.Entity("Books.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Difficulty");

                    b.HasData(
                        new
                        {
                            Id = new Guid("df289bf2-06f2-477b-89ef-aa82bb905d47"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("166373b8-74e9-4b99-bd3d-e7dd77b1590b"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("3b28d9bd-7f0a-4718-8bd6-06e5785ea865"),
                            Name = "Hard"
                        },
                        new
                        {
                            Id = new Guid("abcd9987-fbac-4ba4-a15d-e12f5d15fe8f"),
                            Name = "Expert"
                        });
                });

            modelBuilder.Entity("Books.Models.Domain.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a0f16189-1e04-44e9-8022-90168db7b6c3"),
                            Name = "Horror"
                        },
                        new
                        {
                            Id = new Guid("387e14af-27b6-45ef-8d8e-29a708019073"),
                            Name = "History"
                        },
                        new
                        {
                            Id = new Guid("1ae27bf6-6b8e-4cfd-a23d-d16f232669e2"),
                            Name = "Sci-Fi"
                        });
                });

            modelBuilder.Entity("Books.Models.Domain.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FileDescription")
                        .HasColumnType("text");

                    b.Property<string>("FileExtension")
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .HasColumnType("text");

                    b.Property<long?>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Books.Models.Domain.Publisher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5104a982-9ee5-4cf8-b947-037a1728e427"),
                            Name = "Penguin"
                        });
                });

            modelBuilder.Entity("Books.Models.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string[]>("Roles")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("eac69ca4-a917-4faf-9e3e-5bff6a951576"),
                            Password = "Password123!",
                            Roles = new[] { "Writer" },
                            Username = "m@gmail.com"
                        });
                });

            modelBuilder.Entity("BookUser", b =>
                {
                    b.HasOne("Books.Models.Domain.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Books.Models.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Books.Models.Domain.Book", b =>
                {
                    b.HasOne("Books.Models.Domain.Author", "Author")
                        .WithOne("book")
                        .HasForeignKey("Books.Models.Domain.Book", "AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Books.Models.Domain.Difficulty", "Difficulty")
                        .WithOne("book")
                        .HasForeignKey("Books.Models.Domain.Book", "DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Books.Models.Domain.Genre", "Genre")
                        .WithOne("book")
                        .HasForeignKey("Books.Models.Domain.Book", "GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Books.Models.Domain.Publisher", "Publisher")
                        .WithOne("book")
                        .HasForeignKey("Books.Models.Domain.Book", "PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Difficulty");

                    b.Navigation("Genre");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Books.Models.Domain.Author", b =>
                {
                    b.Navigation("book")
                        .IsRequired();
                });

            modelBuilder.Entity("Books.Models.Domain.Difficulty", b =>
                {
                    b.Navigation("book")
                        .IsRequired();
                });

            modelBuilder.Entity("Books.Models.Domain.Genre", b =>
                {
                    b.Navigation("book")
                        .IsRequired();
                });

            modelBuilder.Entity("Books.Models.Domain.Publisher", b =>
                {
                    b.Navigation("book")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
