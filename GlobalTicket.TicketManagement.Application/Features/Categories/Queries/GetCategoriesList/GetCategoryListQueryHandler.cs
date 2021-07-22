using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistance;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, List<CategoryListVm>>
    {
        private readonly IAsyncRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoryListQueryHandler(IAsyncRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoryListVm>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categories = (await _repository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<CategoryListVm>>(categories);
        }
    }
}
