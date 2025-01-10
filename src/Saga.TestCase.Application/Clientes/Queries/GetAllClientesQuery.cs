using MediatR;
using Saga.TestCase.Application.Clientes.Commands.Dto;

namespace Saga.TestCase.Application.Clientes.Queries
{
    public class GetAllClientesQuery : IRequest<(List<ClientesRequestDTO>, int)>
    {
        #region Properties
        public string TipoRepositorio { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
        #endregion
    }
}
