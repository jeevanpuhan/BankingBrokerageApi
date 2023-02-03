using AutoMapper;

namespace BankingBrokerage.API.MappingProfiles
{
    public class BankMappingProfile : Profile
    {
        public BankMappingProfile()
        {
            CreateMap<Models.Domain.Bank, Models.DTO.Bank>()
                .ReverseMap();

            CreateMap<Models.Domain.Bank, Models.DTO.AddBankRequest>()
                .ReverseMap();

            CreateMap<Models.Domain.Bank, Models.DTO.UpdateBankRequest>()
                .ReverseMap();
        }
    }
}
