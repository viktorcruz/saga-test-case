using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saga.TestCase.Presentation.Forms
{
    public partial class BusquedaExhaustivaFrm : Form
    {
        #region Properties
        private readonly IMediator _mediator;
        private int _paginaActual = 1;
        private int _tamanyoPagina = 50;
        #endregion

        #region Constructor
        public BusquedaExhaustivaFrm(IMediator mediator)
        {
            InitializeComponent();

            _mediator = mediator;
        }
        #endregion

        #region Methods

        #endregion
    }
}
