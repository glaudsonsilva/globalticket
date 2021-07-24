using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Infrastructure;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Application.Models.Mail;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateEventCommandHandler> _logger;

        public CreateEventCommandHandler(IEventRepository repository, IMapper mapper, IEmailService emailService, ILogger<CreateEventCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Creating event: {JsonConvert.SerializeObject(request)}");

            var validator = new CreateEventCommandValidator(_repository);
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var @event = _mapper.Map<Event>(request);

            @event = await _repository.AddAsync(@event);

            await SendEmail(@event.EventId, request);

            return @event.EventId;
        }

        private async Task SendEmail(Guid eventId, CreateEventCommand request)
        {
            var email = new Email
            {
                To = "glaudsonsilva@gmail.com",
                Body = $"A new event was created: {request.Name}",
                Subject = "A new event was created"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mailing about event {eventId} failed due to an error with the mails service: {ex.Message}");
            }
        }
    }
}
