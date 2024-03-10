using _2FluentValidation.Models;
using _2FluentValidation.Models.DTOs;
using AutoMapper;

namespace _2FluentValidation.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            //CreateMap<Customer,CustomerDto>().ReverseMap();
            //Farklı property isimlerine sahip iki nesne nasıl maplenir.

            CreateMap<CreditCard, CustomerDto>();

            CreateMap<Customer, CustomerDto>()
                 //IncludeMembers isimleri aynı olmak şartıyla mapler.
                 .IncludeMembers(x => x.CreditCard)
                 .ForMember(dest => dest.Isim, opt => opt.MapFrom(x => x.Name))
                 .ForMember(dest => dest.Posta, opt => opt.MapFrom(x => x.Email))
                 .ForMember(dest => dest.Yas, opt => opt.MapFrom(x => x.Age))
                 //.ForMember(dest=>dest.FullName,opt=>opt.MapFrom(x=>x.FullName2()))
                 //.ForMember(dest=>dest.CCNumber,opt=>opt.MapFrom(x=>x.CreditCard.Number))
                 //.ForMember(dest=>dest.CCValidDate,opt=>opt.MapFrom(x=>x.CreditCard.ValidDate))

                 .ReverseMap();
        }
    }
}
