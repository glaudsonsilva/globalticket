using AutoMapper;
using GlobalTicket.TicketManagement.Application.Features.Events.GetAll;
using GlobalTicket.TicketManagement.Application.Features.Events.GetDetailed;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GlobalTicket.TicketManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Category, CategoryVm>().ReverseMap();
        }
    }
}
