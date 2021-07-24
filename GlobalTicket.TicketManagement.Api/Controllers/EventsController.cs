using GlobalTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using GlobalTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent;
using GlobalTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetAll;
using GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetDetailed;
using GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EventListVm>>> GetAllCategories()
        {
            var vm = await _mediator.Send(new GetAllEventsListQuery());
            return Ok(vm);
        }

        [HttpGet("{id}", Name = "GetEventById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EventDetailVm>> GetEventById(Guid id)
        {
            var vm = await _mediator.Send(new GetEventDetailQuery { Id = id });
            return Ok(vm);
        }

        [HttpPost(Name = "AddEvent")]
        public async Task<ActionResult> Create([FromBody] CreateEventCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateEventCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete(Name = "DeleteEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteEventCommand { EventId = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("export", Name = "ExportEvents")]
        public async Task<FileResult> ExportEvents()
        {
            var file = await _mediator.Send(new GetEventsExportQuery());
            return File(file.Data, file.ContentType, file.EventExportFileName);
        }
    }
}
