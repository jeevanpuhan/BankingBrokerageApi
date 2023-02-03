using AutoMapper;

namespace BankingBrokerage.API.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Models.Domain.User, Models.DTO.User>()
                .ReverseMap();

            CreateMap<Models.Domain.User, Models.DTO.AddUserRequest>()
                .ReverseMap();

            CreateMap<Models.Domain.User, Models.DTO.UpdateUserRequest>()
                .ReverseMap();
        }
    }
}
