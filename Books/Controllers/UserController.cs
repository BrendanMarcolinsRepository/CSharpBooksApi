using AutoMapper;
using Books.Reposistories.UserRepository;
using Books.Service;
using Books.Service.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            this.mapper = mapper;
            this.userService = userService;
        }

        [HttpGet]
        [Route("{id:Guid}")]
    
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            if (id == null) return NotFound();

            var user = await userService.GetAUserById(id);


            return user == null ? NotFound() : Ok(user);

        }

        [HttpGet]
        [Route("{id:Guid}/{name}")]
        public async Task<IActionResult> GetAUserWithBookSpeficicBookName([FromRoute] Guid id, [FromRoute] string name) {
            
            var user = await userService.GetAUserWithBookSpeficicBookName(id, name);


            return user == null ? NotFound() : Ok(user);
        }

    }
}
