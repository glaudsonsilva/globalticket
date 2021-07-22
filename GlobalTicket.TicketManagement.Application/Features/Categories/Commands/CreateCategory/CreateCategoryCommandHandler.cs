using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly IAsyncRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IAsyncRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateCategoryCommandResponse();

            var validator = new CreateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var category = _mapper.Map<Category>(request);
                category = await _repository.AddAsync(category);
                response.Category = _mapper.Map<CategoryResponse>(category);
            }
            else
            {
                response.Success = false;
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            return response;
        }
    }
}
