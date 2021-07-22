using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GlobalTicket.TicketManagement.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(executingAssembly);
            services.AddMediatR(executingAssembly);

            return services;
        }
    }
}
