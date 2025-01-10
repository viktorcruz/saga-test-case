namespace Saga.TestCase.Application.Clientes.Commands.Dto
{
    public class ClientesRequestDTO
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string RFC { get; set; }
        public string CuentaBancariaId { get; set; }
        public bool Activo { get; set; }
    }
}
