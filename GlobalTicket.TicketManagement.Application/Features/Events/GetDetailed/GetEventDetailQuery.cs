using MediatR;
using System;

namespace GlobalTicket.TicketManagement.Application.Features.Events.GetDetailed
{
    public class GetEventDetailQuery : IRequest<EventDetailVm>
    {
        public Guid Id { get; set; }
    }
}
