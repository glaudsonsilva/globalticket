using MediatR;
using System;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Commands.CreateCategory
{
    public class CreateCategoryCommand: IRequest<CreateCategoryCommandResponse>
    { 
        public string Name { get; set; } 
    }
}
