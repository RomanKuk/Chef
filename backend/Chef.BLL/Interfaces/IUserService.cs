using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chef.Common.DTO.User;
using Microsoft.AspNetCore.Http;

namespace Chef.BLL.Interfaces
{
    public  interface IUserService
    {
        Task<UserDto> Login(string uId);
        Task<UserDto> Register(NewUserDto creatingUser);
        Task<UserDto> UpdateUserAvatar(IFormFile file, int userId);
        Task<bool> ValidateUsername(ValidateUserDto user);
        Task<ICollection<UserDto>> GetAll();
        Task<UserDto> GetUserById(int id);
        Task<UserDto> Update(UserDto user);
        Task Delete(int id);
    }
}
