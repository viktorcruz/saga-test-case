using MediatR;
using Saga.TestCase.Infrastructure.Interfaces;

namespace Saga.TestCase.Presentation.Forms
{
    public partial class OpcionesFrm : Form
    {
        #region Properties
        private readonly IGlobalExceptionHandler _globalException;
        private readonly IMediator _mediator;
        private int _paginaActual = 1;
        private int _tamanyoPagina = 50;

        #endregion

        #region Constructor
        public OpcionesFrm(IMediator mediator, IGlobalExceptionHandler globalException)
        {
            InitializeComponent();

            _mediator = mediator;
            _globalException = globalException;
        }
        #endregion

        #region Methods
        private void OptionsFrm_Load(object sender, EventArgs e)
        {

        }
        #endregion  
    }
}
