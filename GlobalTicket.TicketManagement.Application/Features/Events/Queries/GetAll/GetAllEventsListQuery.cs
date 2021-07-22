using MediatR;
using System.Collections.Generic;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetAll
{
    public class GetAllEventsListQuery : IRequest<List<EventListVm>>
    {
    }
}
