using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Chef.BLL.Exceptions;
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
        private readonly IFileProvider _fileProvider;

        public UserService(ChefContext context, IMapper mapper, IFileProvider fileProvider) : base(context, mapper)
        {
            _fileProvider = fileProvider;
        }

        public async Task<UserDto> Login(string uId)
        {
            try
            {
                return (await GetAllAsync()).First(u => u.UId == uId);
            }
            catch (Exception)
            {
                throw new NotFoundException("User");
            }
        }

        public async Task<UserDto> Register(NewUserDto creatingUser)
        {
            creatingUser.CreatedAt = DateTime.UtcNow;
            return await AddAsync(creatingUser);
        }

        public async Task<UserDto> UpdateUserAvatar(IFormFile file, int userId)
        {
            string dbPath = await _fileProvider.UploadUserPhoto(file);
            var user = await GetAsync(userId);
            user.AvatarUrl = dbPath;
            return await UpdateAsync(user);
        }

        public async Task<bool> ValidateUsername(ValidateUserDto user)
        {
            return user.Id != 0 ? 
                (await GetAllAsync())
                    .Any(x => string.Equals(x.Username, user.Username, StringComparison.InvariantCultureIgnoreCase) && x.Id != user.Id) :
                (await GetAllAsync())
                    .Any(x => string.Equals(x.Username, user.Username, StringComparison.InvariantCultureIgnoreCase));
        }

        public async Task<ICollection<UserDto>> GetAll()
        {
            return (await GetAllAsync()).ToList();
        }

        public async Task<UserDto> GetUserById(int id)
        {
            return await GetAsync(id);
        }

        public async Task<UserDto> Update(UserDto user)
        {
            return await UpdateAsync(user);
        }

        public async Task Delete(int id)
        {
            await RemoveAsync(id);
        }
    }
}
