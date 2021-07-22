using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetAll
{
    public class GetAllEventsListQueryHandler : IRequestHandler<GetAllEventsListQuery, List<EventListVm>>
    {
        private readonly IAsyncRepository<Event> _repository;
        private readonly IMapper _mapper;

        public GetAllEventsListQueryHandler(IAsyncRepository<Event> repository, IMapper mapper)
        {
            _repository = repository;
            this._mapper = mapper;
        }

        public async Task<List<EventListVm>> Handle(GetAllEventsListQuery request, CancellationToken cancellationToken)
        {
            var events = (await _repository.ListAllAsync()).OrderBy(x => x.Date);
            return _mapper.Map<List<EventListVm>>(events); 
        }
    }
}
