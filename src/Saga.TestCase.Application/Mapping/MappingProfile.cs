using AutoMapper;
using Saga.TestCase.Application.Clientes.Commands.Dto;
using Saga.TestCase.Application.Clientes.Queries.Dto;
using Saga.TestCase.Application.Logger.Queries.Dto;
using Saga.TestCase.Application.Opciones.Commands.Dto;
using Saga.TestCase.Application.Productos.Commands.Dto;
using Saga.TestCase.Application.Productos.Queries.Dto;
using Saga.TestCase.Application.Ventas.Commands.Dto;
using Saga.TestCase.Application.Ventas.Queries.Dto;
using Saga.TestCase.Domain.Entities;
using Saga.TestCase.Transversal.Responses;

namespace Saga.TestCase.Application.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Commands
            CreateMap<ClientesRequestDTO, ClientesEntity>().ReverseMap();
            CreateMap<ProductosRequestDTO, ProductosEntity>().ReverseMap();
            CreateMap<VentasRequestDTO, VentasEntity>().ReverseMap();
            CreateMap<OpcionesRequestDTO, OpcionesEntity>().ReverseMap();

            // Queries
            CreateMap<ClientesResponseDTO, ClientesEntity>().ReverseMap();
            CreateMap<ProductosResponseDTO, ProductosEntity>().ReverseMap();
            CreateMap<VentasResponseDTO, VentasEntity>().ReverseMap();
            CreateMap<OpcionesRequestDTO, OpcionesEntity>().ReverseMap();
            CreateMap(typeof(PagedResult<>), typeof(List<>))
                .ConvertUsing(typeof(PagedResultToListConverter<,>));
            CreateMap<LoggerResponseDTO, LoggerEntity>().ReverseMap();
        }
    }

    public class PagedResultToListConverter<TSource, TDestination> : ITypeConverter<PagedResult<TSource>, List<TDestination>>
    {
        public List<TDestination> Convert(PagedResult<TSource> source, List<TDestination> destination, ResolutionContext context)
        {
            return source.Results.Select(context.Mapper.Map<TSource, TDestination>).ToList();
        }
    }

}
