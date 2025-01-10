using AutoMapper;
using MediatR;
using Saga.TestCase.Application.Core.Queries;
using Saga.TestCase.Application.Logger.Queries.Dto;
using Saga.TestCase.Domain.Entities;
using Saga.TestCase.Infrastructure.Extensions;
using Saga.TestCase.Infrastructure.Interfaces;
using Saga.TestCase.Infrastructure.Repositories;

namespace Saga.TestCase.Application.Logger.Queries.QueryHandler
{
    public class GetAllLoggerQueryHandler : IRequestHandler<GetAllLoggerQuery, List<LoggerResponseDTO>>
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IGlobalExceptionHandler _globalExceptionHandler;
        private readonly LoggerRepositoryFactory _loggerRepositoryFactory;
        #endregion

        #region Constructor
        public GetAllLoggerQueryHandler(IMapper mapper, LoggerRepositoryFactory loggerRepositoryFactory, IGlobalExceptionHandler globalExceptionHandler)
        {
            _mapper = mapper;
            _loggerRepositoryFactory = loggerRepositoryFactory;
            _globalExceptionHandler = globalExceptionHandler;
        }
        #endregion

        #region Methods
        public async Task<List<LoggerResponseDTO>> Handle(GetAllLoggerQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var repository = _loggerRepositoryFactory.GetRepository(request.TipoRepositorio);
                var logs = await repository.GetAllLoggerAsync();
                var logsDto = _mapper.Map<List<LoggerResponseDTO>>(logs);

                _globalExceptionHandler.CaptureOperations(ActionType.FetchAll.ToActionTypeName(), "Consulta de datos masivos.");

                return logsDto;
            }
            catch (Exception ex)
            {
                _globalExceptionHandler.CaptureException<string>(ex, ApplicationLayer.Application, ActionType.FetchAll);
            }

            return new List<LoggerResponseDTO>();
        }
        #endregion
    }
}
