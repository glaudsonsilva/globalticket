using GlobalTicket.TicketManagement.Application.Contracts.Persistance;
using GlobalTicket.TicketManagement.Domain.Entities;
using GloboTicket.TicketManagement.Persistence;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Persistance.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(GlobalTicketDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsEventNameAndDateUnique(string name, DateTime date)
        {
            var matches = _dbContext.Events.Any(e => e.Name.Equals(name) && e.Date.Date.Equals(date.Date));
            return Task.FromResult(matches);
        }
    }
}
