using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistance;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IEventRepository _repository;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IEventRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventTopUpdate = await _repository.GetByIdAsync(request.EventId);

            _mapper.Map(request, eventTopUpdate, typeof(UpdateEventCommand), typeof(Event));

            await _repository.UpdatedAsync(eventTopUpdate);

            return Unit.Value;
        }
    }
}
