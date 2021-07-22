using GloboTicket.TicketManagement.Domain.Entities;

namespace GlobalTicket.TicketManagement.Application.Contracts.Persistance
{
    public interface IOrderRepository: IAsyncRepository<Order>
    { 
    }
}
