﻿using Books.Data;
using Books.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Books.Reposistories
{
    public class PostGresBookRepository : IBookRepository
    {
        private readonly BooksDbContext dbContext;

        public PostGresBookRepository(BooksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Book> createABook(Book book)
        {

            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();

            return book;
            
        }

        public async Task<Book?> DeleteABook(Guid id)
        {
            var existingBook = await getBookById(id);

            if (existingBook != null) 
            {
                dbContext.Books.Remove(existingBook);
                await dbContext.SaveChangesAsync();

                return existingBook;
            }

            return null;
        }

        public async Task<List<Book>> getAllBooks(
            string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 200
        )
        {

            var book = dbContext.Books.Include("Author").Include("Difficulty").AsQueryable();

            //filtering 
            if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery)) 
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))

                    book = book.Where(b => b.Name.Contains(filterQuery));
            }

           

            if(!string.IsNullOrEmpty(sortBy)) 
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    book = isAscending ? book.OrderBy(b => b.Name) : book.OrderByDescending(b => b.Name);
                }
            }

            var skipResults = (pageNumber - 1) * pageSize;




            return await book.Skip(skipResults).Take(pageSize).ToListAsync();


            //return await dbContext.Books.Include("Author").Include("Difficulty").ToListAsync();

        }

       

        public async Task<Book?> getBookById(Guid id)
        {
            return await dbContext
                .Books.Include("Author")
                .Include("Difficulty")
                .Include("Genre")
                .Include("Publisher")
                .FirstOrDefaultAsync(book => book.Id == id);
        }

        public async Task<Book?> updateABook(Guid id, Book book)
        {
            var existingBook = await getBookById(id);
            
            if(existingBook != null) 
            {
                existingBook.Name = book.Name;
                existingBook.Description = book.Description;
                existingBook.AuthorId = book.AuthorId;
                existingBook.DifficultyId = book.DifficultyId;

                await dbContext.SaveChangesAsync();

                return existingBook;
            }

            return null;
        }
    }
}
