using MediatR;
using Saga.TestCase.Application.Clientes.Commands.Dto;

namespace Saga.TestCase.Application.Clientes.Commands
{
    public class CreateClienteCommand : IRequest<bool>
    {
        #region Properties
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string RFC { get; set; }
        public string CuentaBancariaId { get; set; }
        #endregion

        #region Constructor
        public CreateClienteCommand(ClientesRequestDTO dto)
        {
            Id = dto.Id;
            Nombre = dto.Nombre;
            Apellido = dto.Apellido;
            RFC = dto.RFC;
            CuentaBancariaId = dto.CuentaBancariaId;
        }
        #endregion
    }
}
