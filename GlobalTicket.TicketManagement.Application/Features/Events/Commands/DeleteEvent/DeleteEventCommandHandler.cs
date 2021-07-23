using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IEventRepository _repository;

        public DeleteEventCommandHandler(IEventRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var eventToDelete = await _repository.GetByIdAsync(request.EventId);

            await _repository.DeleteAsync(eventToDelete);

            return Unit.Value;
        }
    }
}
