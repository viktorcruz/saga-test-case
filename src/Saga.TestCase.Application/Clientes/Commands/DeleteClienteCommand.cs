using MediatR;

namespace Saga.TestCase.Application.Clientes.Commands
{
    public class DeleteClientesCommand : IRequest<bool>
    {
        public string ClienteId { get; set; }
        public DeleteClientesCommand(string clienteId) { ClienteId = clienteId; }
    }
}
