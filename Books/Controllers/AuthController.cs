using AutoMapper.Internal;
using Books.Models.DTOs.AuthDto;
using Books.Reposistories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        //Post Method 
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Password
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerDto.Password);

            if (identityResult.Succeeded)
            {
                //add roles
                if (registerDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("Succeeded");
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
            var usernameCheck = await userManager.FindByEmailAsync(loginDto.Username);


            //check usernamne 
            if (usernameCheck == null)
            {
                return BadRequest("Username or Password was incorrect!!");
            }

            var passwordCheck = await userManager.CheckPasswordAsync(usernameCheck, loginDto.Password);

            //check password
            if (!passwordCheck)
            {
                return BadRequest("Username or Password was incorrect!!");
            }

            var userRoles = await userManager.GetRolesAsync(usernameCheck);

            //check for roles
            if (userRoles == null)
            {
                return BadRequest("Username or Password was incorrect!!");

            }

            //create a tokken
            var jwtToken = tokenRepository.CreateJwtToken(usernameCheck, userRoles.ToList());

            //wrap jwt in dto and send reponse
            var response = new LoginResponseDto
            {
                JwtToken = jwtToken
            };

            return Ok(response);




        }
    }
}
