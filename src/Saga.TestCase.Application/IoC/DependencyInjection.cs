using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Saga.TestCase.Application.Mapping;

namespace Saga.TestCase.Application.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomApplicationIoC(this IServiceCollection services)
        {
            var mapping = new AutoMapper.MapperConfiguration(config =>
            {
                config.AddProfile(new MappingProfiles());
            });

            IMapper mapper = mapping.CreateMapper();

            services.AddSingleton(mapper);
            services.AddScoped<IMediator, Mediator>();

            return services;
        }
    }
}
