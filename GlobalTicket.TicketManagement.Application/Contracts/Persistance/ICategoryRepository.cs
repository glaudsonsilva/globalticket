using GloboTicket.TicketManagement.Domain.Entities;

namespace GlobalTicket.TicketManagement.Application.Contracts.Persistance
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
    }
}
