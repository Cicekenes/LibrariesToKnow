using _2FluentValidation.Models;
using _2FluentValidation.Models.DTOs;
using AutoMapper;

namespace _2FluentValidation.Mapping
{
    public class EventDateProfile : Profile
    {
        public EventDateProfile()
        {
            CreateMap<EventDateDto,EventDate>().ForMember(x=>x.Date,opt=>opt.MapFrom(x=>new DateTime(x.Year,x.Month,x.Day)));

            CreateMap<EventDate, EventDateDto>().ForMember(x => x.Year, opt => opt.MapFrom(x => x.Date.Year));
            CreateMap<EventDate, EventDateDto>().ForMember(x => x.Month, opt => opt.MapFrom(x => x.Date.Month));
            CreateMap<EventDate, EventDateDto>().ForMember(x => x.Day, opt => opt.MapFrom(x => x.Date.Day));
        }
    }
}
