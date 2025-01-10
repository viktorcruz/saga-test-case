using AutoMapper;
using MediatR;
using Saga.TestCase.Application.Clientes.Commands.Dto;
using Saga.TestCase.Infrastructure.Extensions;
using Saga.TestCase.Infrastructure.Interfaces;
using Saga.TestCase.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Saga.TestCase.Application.Clientes.Queries.QueryHandler
{
    public class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesQuery, (List<ClientesRequestDTO>, int)>
    {
        #region Properties
        private readonly IGlobalExceptionHandler _globalExceptionHandler;
        private readonly ClientesRepositoryFactory _repositoryFactory;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public GetAllClientesQueryHandler(ClientesRepositoryFactory repositoryFactory, IMapper mapper, IGlobalExceptionHandler globalExceptionHandler)
        {
            _repositoryFactory = repositoryFactory;
            _mapper = mapper;
            _globalExceptionHandler = globalExceptionHandler;

        }
        #endregion

        #region Properties
        public async Task<(List<ClientesRequestDTO>, int)> Handle(GetAllClientesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var repository = _repositoryFactory.GetRepository(request.TipoRepositorio);
                var clientes = await repository.GetClientesPaginatedAsync(request.PageNumber, request.PageSize, request.Search);
                var clientesDto = _mapper.Map<List<ClientesRequestDTO>>(clientes);

                _globalExceptionHandler.CaptureOperations(ActionType.FetchAll.ToActionTypeName(), "Consulta de datos masivos.");

                return await Task.FromResult((clientesDto, clientes.TotalCount));
            }
            catch (Exception ex)
            {
                _globalExceptionHandler.CaptureException<string>(ex, ApplicationLayer.Application, ActionType.Create);
            }
            return await Task.FromResult((new List<ClientesRequestDTO>(), 0));
        }
        #endregion
    }
}
