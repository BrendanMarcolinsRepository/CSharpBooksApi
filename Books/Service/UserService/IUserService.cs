using Books.Models.Domain;
using Books.Models.DTOs;
using Books.Models.DTOs.GenresDto;
using Books.Models.DTOs.UserDto;

namespace Books.Service.UserService
{
    public interface IUserService
    {
        Task<List<GeneralUserDto>> GetAllUser();

        Task<GeneralUserDto?> GetAUserById(Guid id);

        Task<GeneralUserDto> GetAUserWithBookSpeficicBookName(Guid id, string name);

        Task<GeneralUserDto?> CreateAUser(UserDto userDto);


        Task<GeneralUserDto?> UpdateAUser(Guid id, UserDto UserDto);

        Task<GeneralUserDto?> DeleteAUser(Guid id, UserDto UserDto);
    }
}
