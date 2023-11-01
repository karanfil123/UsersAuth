using AutoMapper;
using UsersAuth.Models;

namespace UsersAuth.Mapping
{
    public class Mapprofile : Profile
    {
        protected Mapprofile()
        {
            CreateMap<User, UserLoginDto>().ReverseMap();
        }
    }
}
