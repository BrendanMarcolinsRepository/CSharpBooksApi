using AutoMapper.Internal;
using Books.Models.Domain;
using Books.Models.DTOs.AuthDto;
using Books.Models.DTOs.UserDto;
using Books.Reposistories;
using Books.Service.UserService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace Books.Controllers
{
 
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;
        private readonly IUserService userService;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository, IUserService userService)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
            this.userService = userService;
        }

        //Post Method 
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerDto.Password);

            if (identityResult.Succeeded)
            {
                //add roles
                if (registerDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerDto.Roles);
                    var user = await userManager.FindByEmailAsync(identityUser.Email);

                    if (identityResult.Succeeded && user != null)
                    {
                        var usersroles = await userManager.GetRolesAsync(user);

                        var createUser = new UserDto()
                        {
                            Id = Guid.Parse(user.Id),
                            Username = user.UserName,
                            Password = user.PasswordHash,
                            Roles = usersroles.ToArray()

                        };

                        var generalUserDto = await userService.CreateAUser(createUser);

                        return generalUserDto != null ?  Ok("Succeeded") : BadRequest("Something went wrong");

                       
                    }
                }

                return BadRequest("Something went wrong");


            }

            return BadRequest("Something went wrong");

        }

       
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {

            Debug.WriteLine($"============================== Details: {loginDto.Username}");
            var usernameCheck = await userManager.FindByEmailAsync(loginDto.Username);

            Debug.WriteLine($"============================== Details 2: {usernameCheck}");

            //check usernamne 
            if (usernameCheck == null)
            {
                Debug.WriteLine("============================== Here 1");
                return BadRequest("Username or Password was incorrect!!");
            }

            var passwordCheck = await userManager.CheckPasswordAsync(usernameCheck, loginDto.Password);

            //check password
            if (!passwordCheck)
            {
                Debug.WriteLine("============================== Here 2");
                return BadRequest("Username or Password was incorrect!!");
            }

            var userRoles = await userManager.GetRolesAsync(usernameCheck);

            //check for roles
            if (userRoles == null)
            {
                Debug.WriteLine("============================== Here 3");
                return BadRequest("Username or Password was incorrect!!");

            }

            //create a tokken
            var jwtToken = tokenRepository.CreateJwtToken(usernameCheck, userRoles.ToList());


            //wrap jwt in dto and send reponse
            var response = new LoginResponseDto
            {
                Id = Guid.Parse(usernameCheck.Id),
                Username = usernameCheck.UserName,
                JwtToken = jwtToken
            };

            Debug.WriteLine("============================== Here 4");

            return Ok(response);




        }
    }
}
