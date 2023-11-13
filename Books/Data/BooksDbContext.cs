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

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Progress> Progress { get; set; }


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
                    Pagecount = 576,
                    WordsPerPage = 400,
                    WordCount = 182234,
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
                    Pagecount = 1152,
                    WordsPerPage = 400,
                    WordCount = 349056,
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
                    Pagecount = 482,
                    WordsPerPage = 400,
                    WordCount = 163500,
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
                    Pagecount = 544,
                    WordsPerPage = 400,
                    WordCount = 169059,
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

            var progress = new[]
            {
                new Progress()
                {
                    Id = Guid.Parse("ad91f371-ce2f-432b-b001-572f493c4112"),
                    completed = true,
                    percentage = 100,
                    timeleft = 0,
                    BookId = Guid.Parse("ad241e9a-dc28-4a30-93e2-300402631654"),
                    UserId = Guid.Parse("eac69ca4-a917-4faf-9e3e-5bff6a951576")
                },

                new Progress()
                {
                    Id = Guid.Parse("8ea8c311-aaa9-4e1a-ac39-95d2bd989cc1"),
                    completed = false,
                    percentage = 50,
                    timeleft = 698,
                    BookId = Guid.Parse("941e317b-77e5-4f7d-915f-beb98541e560"),
                    UserId = Guid.Parse("eac69ca4-a917-4faf-9e3e-5bff6a951576")
                },

                new Progress()
                {
                    Id = Guid.Parse("f4f791b9-4df7-4786-a247-4d2e69630eef"),
                    completed = false,
                    percentage = 75,
                    timeleft = 163,
                    BookId = Guid.Parse("2a7ada53-e3f7-4154-8737-dfee6aff1b80"),
                    UserId = Guid.Parse("eac69ca4-a917-4faf-9e3e-5bff6a951576")
                },

                new Progress()
                {
                    Id = Guid.Parse("9738c657-a1f3-4e5c-8f5b-e9e8b9e5bd06"),
                    completed = false,
                    percentage = 25,
                    timeleft = 507,
                    BookId = Guid.Parse("9c9e4237-bd98-4dda-8fb3-9e6ab9a75963"),
                    UserId = Guid.Parse("eac69ca4-a917-4faf-9e3e-5bff6a951576")
                }
            }; 

            var reviews = new[]
            {
               new Review()
               {
                   Id = Guid.Parse("fc859859-d1a9-495e-aac9-082b6e3f7989"),
                   Name = "Amazing book!!!",
                   Comment = "This book is amazing blah blah ",
                   rating = 5,
                   BookId = Guid.Parse("ad241e9a-dc28-4a30-93e2-300402631654"),
                   UserId = Guid.Parse("eac69ca4-a917-4faf-9e3e-5bff6a951576")
               }
           };

            modelBuilder.Entity<Book>().HasOne(exp => exp.Author).WithMany(exp => exp.Books).HasForeignKey(exp => exp.AuthorId);
            modelBuilder.Entity<Book>().HasOne(exp => exp.Difficulty).WithOne(exp => exp.book).HasForeignKey<Book>(exp => exp.DifficultyId);
            modelBuilder.Entity<Book>().HasOne(exp => exp.Publisher).WithMany(exp => exp.Books).HasForeignKey(exp => exp.PublisherId);
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

            modelBuilder.Entity<Progress>().HasOne(x => x.Book).WithOne(x => x.Progress).HasForeignKey<Progress>(x => x.BookId);
            modelBuilder.Entity<Progress>().HasOne(x => x.User).WithOne(x => x.Progress).HasForeignKey<Progress>(x => x.UserId);

            modelBuilder.Entity<Progress>().HasData(progress);

            modelBuilder.Entity<Review>().HasOne(x => x.Book).WithMany(x => x.Reviews).HasForeignKey(x => x.BookId);
            modelBuilder.Entity<Review>().HasOne(x => x.User).WithMany(x => x.Reviews).HasForeignKey(x => x.UserId);



            modelBuilder.Entity<Review>().HasData(reviews);



        }



    }
}
