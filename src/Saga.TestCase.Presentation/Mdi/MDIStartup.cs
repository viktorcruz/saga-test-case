using MediatR;
using Saga.TestCase.Application.Core.Queries;
using Saga.TestCase.Application.Logger.Queries.Dto;
using Saga.TestCase.Infrastructure.Interfaces;
using Saga.TestCase.Presentation.Forms;

namespace Saga.TestCase.Presentation.Mdi
{
    public partial class MDIStartup : Form
    {
        #region Properties
        private readonly IGlobalExceptionHandler _globalException;
        private readonly Dictionary<Type, Form> _formularios = new();
        private readonly IMediator _mediator;
        private List<LoggerResponseDTO> _loggers;
        private AboutFrm? _aboutFrm = null;
        private BusquedaExhaustivaFrm? _busquedaFrm = null;
        private ClientesFrm? _clientesFrm = null;
        private ProductosFrm? _productosFrm = null;
        private OpcionesFrm? _optionsFrm = null;
        private VentasFrm? _ventasFrm = null;
        #endregion

        #region Constructor
        public MDIStartup(IMediator mediator, IGlobalExceptionHandler globalException)
        {
            InitializeComponent();

            _mediator = mediator;
            _globalException = globalException;
            Configuracion();
        }
        #endregion

        #region Methods
        private async void Configuracion()
        {
            try
            {
                var query = new GetAllLoggerQuery { TipoRepositorio = "ADO" };
                _loggers = await _mediator.Send(query);
                foreach (var item in _loggers)
                {
                    rtbErrorDetailLog.SelectionFont = new System.Drawing.Font("Segoe UI", 10);
                    rtbErrorDetailLog.SelectionColor = System.Drawing.Color.Blue;
                    rtbErrorDetailLog.AppendText($"IdCorrelation:{item.IdCorrelation}, LogLevel:{item.LogLevel}, FileName:{item.FileName}, LogDate:{item.LogDate}" + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                _globalException.CaptureException<string>(ex, ApplicationLayer.Presentation, ActionType.LaunchForm);
            }
        }

        private void AbrirFormulario<T>(Func<Form> crearFormulario) where T : Form
        {
            try
            {
                if (_formularios.ContainsKey(typeof(T)))
                {
                    var form = _formularios[typeof(T)];
                    if (form != null && !form.IsDisposed)
                    {
                        form.Activate();
                        return;
                    }
                }

                var nuevoFormulario = crearFormulario();
                _formularios[typeof(T)] = nuevoFormulario;

                if (this.IsMdiContainer)
                {
                    nuevoFormulario.MdiParent = this;
                }

                nuevoFormulario.FormClosed += Form_Closed;
                CentrarFormulario(nuevoFormulario);
                Configuracion();
                nuevoFormulario.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form formulario)
            {
                _formularios.Remove(formulario.GetType());
                Configuracion();
            }
        }

        private void CentrarFormulario(Form frm)
        {
            try
            {
                int posX = (this.ClientSize.Width - frm.Width) / 2;
                int posY = (menuStrip.Height);
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(posX, posY + 5);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void cargarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirFormulario<EdicionArchivosFrm>(() => new EdicionArchivosFrm(_mediator, _globalException));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _globalException.CaptureException<string>(ex, ApplicationLayer.Presentation, ActionType.LaunchForm);
            }
        }

        private void guardarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Estas seguro de que deseas salir?", "Confirmar salida",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }

        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saga - Test Case", "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void busquedaExhaustivaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirFormulario<BusquedaExhaustivaFrm>(() => new BusquedaExhaustivaFrm(_mediator));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirFormulario<OpcionesFrm>(() => new OpcionesFrm(_mediator, _globalException));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _globalException.CaptureException<string>(ex, ApplicationLayer.Presentation, ActionType.LaunchForm);
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirFormulario<ClientesFrm>(() => new ClientesFrm(_mediator, _globalException));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _globalException.CaptureException<string>(ex, ApplicationLayer.Presentation, ActionType.LaunchForm);
            }
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
