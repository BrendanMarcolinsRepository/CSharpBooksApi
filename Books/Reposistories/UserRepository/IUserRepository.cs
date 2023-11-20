using Books.Models.Domain;

namespace Books.Reposistories.UserRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();

        Task<User?> GetAUserById(Guid id);

        Task<User> GetAUserWithBookSpeficicBookName(Guid id, string name);

        Task<User?> CreateAUser(User user);


        Task<User?> UpdateAUser(Guid id, User user);

        Task<User?> DeleteAUser(Guid id, User user);
    }
}
