using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;
using System;

namespace GlobalTicket.TicketManagement.Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        public LoggedInUserService()
        {
            UserId = Guid.NewGuid().ToString();//httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        //public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        //{
        //    UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        //}

        public string UserId { get; }
    }
}
