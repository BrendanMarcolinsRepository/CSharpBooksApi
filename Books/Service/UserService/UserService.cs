using AutoMapper;
using Books.Models.Domain;
using Books.Models.DTOs.GenresDto;
using Books.Models.DTOs.UserDto;
using Books.Reposistories.GenreRepository;
using Books.Reposistories.UserRepository;

namespace Books.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<GeneralUserDto?> CreateAUser(UserDto userDto)
        {
            var user = mapper.Map<User>(userDto);

            user = await userRepository.CreateAUser(user);

            if (user == null) return null;

            var generalUserDto = mapper.Map<GeneralUserDto>(user);

            return generalUserDto;
        }

        public async Task<GeneralUserDto?> DeleteAUser(Guid id, UserDto UserDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GeneralUserDto>> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public async Task<GeneralUserDto?> GetAUserById(Guid id)
        {
            var user = await userRepository.GetAUserById(id);

            var generalUserDto = mapper.Map<GeneralUserDto?>(user);

            return generalUserDto != null ? generalUserDto : null;
        }

        public async Task<GeneralUserDto> GetAUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<GeneralUserDto?> UpdateAUser(Guid id, UserDto UserDto)
        {
            throw new NotImplementedException();
        }
    }
}
