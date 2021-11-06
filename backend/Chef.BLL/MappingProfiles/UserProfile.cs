using AutoMapper;
using Chef.Common.DTO.User;
using Chef.DAL.Entities;

namespace Chef.BLL.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<UserDto, User>();
            CreateMap<NewUserDto, User>();
        }
    }
}
