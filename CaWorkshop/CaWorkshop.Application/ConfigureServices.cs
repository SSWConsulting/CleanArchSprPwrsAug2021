using System.Reflection;
using CaWorkshop.Application.TodoLists.Queries.GetTodoLists;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CaWorkshop.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
