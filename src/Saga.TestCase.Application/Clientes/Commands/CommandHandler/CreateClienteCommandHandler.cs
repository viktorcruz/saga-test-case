using MediatR;
using Saga.TestCase.Infrastructure.Interfaces;

namespace Saga.TestCase.Application.Clientes.Commands.CommandHandler
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, bool>
    {
        #region Properties
        private readonly IClientesRepository _clientesRepository;
        private readonly IGlobalExceptionHandler _globalExceptionHandler;
        #endregion

        #region Constructor
        public CreateClienteCommandHandler(IClientesRepository clientesRepository, IGlobalExceptionHandler globalExceptionHandler)
        {
            _clientesRepository = clientesRepository;
            _globalExceptionHandler = globalExceptionHandler;

        }
        #endregion

        #region Methods

        public Task<bool> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                throw new Exception("Errro");

            }catch(Exception ex)
            {

                _globalExceptionHandler.CaptureException<string>(ex, ApplicationLayer.Application, ActionType.Create);

            }
            return Task.FromResult(false);
        }
        #endregion
    }
}
