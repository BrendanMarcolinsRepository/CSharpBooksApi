using Books.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Books.Data
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options) 
        {

            
        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data for difficulties

            var difficulties = new List<Difficulty>()
            {
               new Difficulty(){ Id = Guid.Parse("df289bf2-06f2-477b-89ef-aa82bb905d47") , Name = "Easy" },
               new Difficulty(){ Id = Guid.Parse("166373b8-74e9-4b99-bd3d-e7dd77b1590b") , Name = "Medium" },
               new Difficulty(){ Id = Guid.Parse("3b28d9bd-7f0a-4718-8bd6-06e5785ea865"),  Name = "Hard" },
               new Difficulty(){ Id = Guid.Parse("abcd9987-fbac-4ba4-a15d-e12f5d15fe8f"),  Name = "Expert" }
            };

          

            var author = new List<Author>()
            {
                new Author() { Id = Guid.Parse("06580836-f2af-42c0-b5a7-479975ef1c9d"), Name = "Neil Stephenson"},
                new Author() { Id = Guid.Parse("302afacb-becd-4dfc-9186-5c7eaa93424b"), Name = "Dan Simmons" }
            };

            

            var publisher = new List<Publisher>()
            {
                new Publisher(){Id = Guid.Parse("5104a982-9ee5-4cf8-b947-037a1728e427"), Name = "Penguin" }
            };

       

            var genre = new List<Genre>()
            {
                new Genre(){Id = Guid.Parse("a0f16189-1e04-44e9-8022-90168db7b6c3"), Name = "Horror" },
                new Genre(){Id = Guid.Parse("387e14af-27b6-45ef-8d8e-29a708019073"), Name = "History" },
                new Genre(){Id = Guid.Parse("1ae27bf6-6b8e-4cfd-a23d-d16f232669e2"), Name = "Sci-Fi" },
            };

          


            //seed Books
            var books = new List<Book>()
            {
                new Book()
                {
                    Id = Guid.Parse("ad241e9a-dc28-4a30-93e2-300402631654"), 
                    Name = "Snow Crash",
                    Description = "", 
                    BookCover = "",
                    AuthorId = Guid.Parse("06580836-f2af-42c0-b5a7-479975ef1c9d"),
                    GenreId = Guid.Parse("1ae27bf6-6b8e-4cfd-a23d-d16f232669e2"),
                    PublisherId =  Guid.Parse("5104a982-9ee5-4cf8-b947-037a1728e427"),
                    DifficultyId = Guid.Parse("166373b8-74e9-4b99-bd3d-e7dd77b1590b"),


                },
                
                
                new Book() 
                {
                    Id = Guid.Parse("941e317b-77e5-4f7d-915f-beb98541e560"),
                    Name = "Cryptonomicon", 
                    Description = "",
                    BookCover = "",
                    AuthorId = Guid.Parse("06580836-f2af-42c0-b5a7-479975ef1c9d"),
                    GenreId = Guid.Parse("1ae27bf6-6b8e-4cfd-a23d-d16f232669e2"),
                    PublisherId =  Guid.Parse("5104a982-9ee5-4cf8-b947-037a1728e427"),
                    DifficultyId = Guid.Parse("166373b8-74e9-4b99-bd3d-e7dd77b1590b"),

                },
                new Book() 
                { 
                    Id = Guid.Parse("2a7ada53-e3f7-4154-8737-dfee6aff1b80"), 
                    Name = "Hyperion",
                    Description = "", 
                    BookCover = "",
                    AuthorId = Guid.Parse("302afacb-becd-4dfc-9186-5c7eaa93424b"),
                    GenreId = Guid.Parse("1ae27bf6-6b8e-4cfd-a23d-d16f232669e2"),
                    PublisherId =  Guid.Parse("5104a982-9ee5-4cf8-b947-037a1728e427"),
                    DifficultyId = Guid.Parse("166373b8-74e9-4b99-bd3d-e7dd77b1590b"),

                },
                new Book() 
                {
                    Id = Guid.Parse("9c9e4237-bd98-4dda-8fb3-9e6ab9a75963"),
                    Name = "Fall of Hyperion", 
                    Description = "", 
                    BookCover = "",
                    AuthorId = Guid.Parse("302afacb-becd-4dfc-9186-5c7eaa93424b"),
                    GenreId = Guid.Parse("1ae27bf6-6b8e-4cfd-a23d-d16f232669e2"),
                    PublisherId =  Guid.Parse("5104a982-9ee5-4cf8-b947-037a1728e427"),
                    DifficultyId = Guid.Parse("166373b8-74e9-4b99-bd3d-e7dd77b1590b"),

                }
                
            };

           

            var users = new List<User>()
            {
                new User()
                {
                    Id = Guid.Parse("eac69ca4-a917-4faf-9e3e-5bff6a951576"), Username = "m@gmail.com", Password = "Password123!", Roles = new string[] {"Writer"}
                }
            };


            var BookUser = new[] 
            {
                new { 
                    BooksId = Guid.Parse("ad241e9a-dc28-4a30-93e2-300402631654"),
                    UsersId = Guid.Parse("eac69ca4-a917-4faf-9e3e-5bff6a951576") 
                },

                new {
                    BooksId = Guid.Parse("941e317b-77e5-4f7d-915f-beb98541e560"),
                    UsersId = Guid.Parse("eac69ca4-a917-4faf-9e3e-5bff6a951576")
                },

                new {
                    BooksId = Guid.Parse("2a7ada53-e3f7-4154-8737-dfee6aff1b80"),
                    UsersId = Guid.Parse("eac69ca4-a917-4faf-9e3e-5bff6a951576")
                },

                new {
                    BooksId = Guid.Parse("9c9e4237-bd98-4dda-8fb3-9e6ab9a75963"),
                    UsersId = Guid.Parse("eac69ca4-a917-4faf-9e3e-5bff6a951576")
                }
            };


           

            modelBuilder.Entity<Book>().HasOne(exp => exp.Author).WithOne(exp => exp.book).HasForeignKey<Book>(exp => exp.AuthorId);
            modelBuilder.Entity<Book>().HasOne(exp => exp.Difficulty).WithOne(exp => exp.book).HasForeignKey<Book>(exp => exp.DifficultyId);
            modelBuilder.Entity<Book>().HasOne(exp => exp.Publisher).WithOne(exp => exp.book).HasForeignKey<Book>(exp => exp.PublisherId);
            modelBuilder.Entity<Book>().HasOne(exp => exp.Genre).WithOne(exp => exp.book).HasForeignKey<Book>(exp => exp.GenreId);

            
            modelBuilder.Entity<Publisher>().HasData(publisher);
            modelBuilder.Entity<Difficulty>().HasData(difficulties);
            modelBuilder.Entity<Author>().HasData(author);
            modelBuilder.Entity<Genre>().HasData(genre);
            modelBuilder.Entity<Book>().HasData(books);
            modelBuilder.Entity<User>().HasData(users);

            modelBuilder.Entity<Book>()
               .HasMany<User>(user => user.Users)
               .WithMany(book => book.Books)
               .UsingEntity(bookuser => bookuser
                    .ToTable("BookUser")
                    .HasData(BookUser)
               );

          
           


        }  

        

    }
}
