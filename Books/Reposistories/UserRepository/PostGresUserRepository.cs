using Books.Data;
using Books.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Books.Reposistories.UserRepository
{
    public class PostGresUserRepository : IUserRepository
    {
        private readonly BooksDbContext dbContext;

        public PostGresUserRepository(BooksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User?> CreateAUser(User user)
        {
            await dbContext.Users.AddAsync(user);

            var result = dbContext.SaveChangesAsync().IsCompletedSuccessfully;

            return result ? user : null;

          
        }

        public async Task<User?> DeleteAUser(Guid id, User user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetAUserById(Guid id)
        {
            var user = await dbContext.Users
                .Include(b => b.Books)
                    .ThenInclude(a => a.Author)
                .Include(b => b.Books)
                    .ThenInclude(d => d.Difficulty)
                .Include(b => b.Books)
                    .ThenInclude(p => p.Publisher)
                .Include(b => b.Books)
                    .ThenInclude(g => g.Genre)
                .FirstOrDefaultAsync(book => book.Id == id);

            return  user != null ? user : null;

        }

        public async Task<User> GetAUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> UpdateAUser(Guid id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
