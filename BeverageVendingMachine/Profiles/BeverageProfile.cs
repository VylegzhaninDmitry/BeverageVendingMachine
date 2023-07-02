using AutoMapper;
using BeverageVendingMachine.DTOs;

namespace BeverageVendingMachine.Profiles
{
    public class BeverageProfile : Profile
    {
        public BeverageProfile() 
        {
            CreateMap<BeverageDto, Beverage>().ReverseMap().ForMember(dest => dest.Image, opt => opt.MapFrom(s => Convert.ToBase64String(s.Image)));
            CreateMap<CreateBeverageDto, Beverage>().ReverseMap();
            CreateMap<UpdateBeverageDto, Beverage>().ReverseMap();
        }
    }
}
