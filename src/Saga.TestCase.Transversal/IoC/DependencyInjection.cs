using Microsoft.Extensions.DependencyInjection;
using Saga.TestCase.Transversal.Interfaces;
using Saga.TestCase.Transversal.Responses;

namespace Saga.TestCase.Transversal.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomTransversalIoC(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IResponseToClient<>), typeof(ResponseToClient<>));
            services.AddSingleton(typeof(PagedResult<>));



            return services;
        }
    }
}
