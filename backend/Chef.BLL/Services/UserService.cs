using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Chef.BLL.Interfaces;
using Chef.BLL.Services.Abstract;
using Chef.Common.DTO.User;
using Chef.DAL.Context;
using Chef.DAL.Entities;
using Microsoft.AspNetCore.Http;

namespace Chef.BLL.Services
{
    public class UserService : BaseCrudService<User, UserDto, NewUserDto>, IUserService
    {
        public UserService(ChefContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public Task<UserDto> Login(string uId)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> Register(NewUserDto creatingUser)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> UpdateUserAvatar(IFormFile file, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateUsername(ValidateUserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
