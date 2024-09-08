using AutoMapper;

namespace DbGame
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Game,GameDto>();
            CreateMap<User, UserResponseDto>();
        }

    }
}
