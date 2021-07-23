using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Infrastructure;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport
{
    public class GetEventsExportQueryHandler : IRequestHandler<GetEventsExportQuery, EventExportFileVm>
    {
        private readonly IAsyncRepository<Event> _repository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetEventsExportQueryHandler(IAsyncRepository<Event> repository, IMapper mapper, ICsvExporter csvExporter)
        {
            _repository = repository;
            _mapper = mapper;
            _csvExporter = csvExporter;
        }

        public async Task<EventExportFileVm> Handle(GetEventsExportQuery request, CancellationToken cancellationToken)
        {
            var events = _mapper.Map<List<EventExportVm>>((await _repository.ListAllAsync()).OrderBy(x => x.Date));

            var file = _csvExporter.ExportEventsToCsv(events);

            var vm = new EventExportFileVm { ContentType = "text/csv", Data = file, EventExportFileName = $"{Guid.NewGuid()}.csv" };

            return vm;
        }
    }
}
