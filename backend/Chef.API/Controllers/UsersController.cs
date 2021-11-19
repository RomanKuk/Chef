using System.Collections.Generic;
using System.Threading.Tasks;
using Chef.BLL.Interfaces;
using Chef.Common.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chef.API.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ICollection<UserDto>> Get()
        {
            return await _userService.GetAll();
        }

        [HttpGet("{id:int}")]
        public async Task<UserDto> Get(int id)
        {
            return await _userService.GetUserById(id);
        }

        [AllowAnonymous]
        [HttpGet("login/{UId}")]
        public async Task<UserDto> Login(string uId)
        {
            return await _userService.Login(uId);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<UserDto> Register([FromBody] NewUserDto user)
        {
            return await _userService.Register(user);
        }

        [AllowAnonymous]
        [HttpPost("validate-username")]
        public async Task<bool> ValidateUsername([FromBody] ValidateUserDto user)
        {
            return await _userService.ValidateUsername(user);
        }

        [HttpPut]
        public async Task<UserDto> Update([FromBody] UserDto user)
        {
            return await _userService.Update(user);
        }
        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            await _userService.Delete(id);
        }

        [HttpPost("avatar/{id:int}")]
        public async Task<UserDto> UpdateAvatar(int id)
        {
            return await _userService.UpdateUserAvatar(Request.Form.Files[0], id);
        }
    }
}
