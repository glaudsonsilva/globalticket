using GlobalTicket.TicketManagement.Identity.Models;
using Microsoft.EntityFrameworkCore; 
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; 


namespace GlobalTicket.TicketManagement.Identity
{
    public class GlobalTicketIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public GlobalTicketIdentityDbContext(DbContextOptions<GlobalTicketIdentityDbContext> options) : base(options)
        {

        }
    }
}
