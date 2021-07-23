using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Application.Features.Events.Commands.CreateCategory;
using GlobalTicket.TicketManagement.Application.Profiles;
using GlobalTicket.TicketManagement.Application.UnitTests.Mocks;
using GlobalTicket.TicketManagement.Domain.Entities;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GlobalTicket.TicketManagement.Application.UnitTests.Features.Categories.Commands
{
    public class CreateCategoryTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Category>> _repository;

        public CreateCategoryTests()
        {
            _repository = RepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task ItShouldIncrementListCountWhenInsertNewCategory()
        {
            var handler = new CreateCategoryCommandHandler(_repository.Object, _mapper);

            await handler.Handle(new CreateCategoryCommand { Name = "Test" }, CancellationToken.None);

            var categories = await _repository.Object.ListAllAsync();

            categories.Count.ShouldBe(5);
        }
    }
}
