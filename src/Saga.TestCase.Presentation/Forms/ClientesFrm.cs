using MediatR;
using Saga.TestCase.Application.Clientes.Commands.Dto;
using Saga.TestCase.Application.Clientes.Queries;
using Saga.TestCase.Infrastructure.Interfaces;
using Saga.TestCase.Presentation.Utils;
using System.Threading;

namespace Saga.TestCase.Presentation
{
    public partial class ClientesFrm : Form
    {
        #region Properties
        private IGlobalExceptionHandler _globalException;
        private CancellationTokenSource _cancellationTokenSource;
        private List<ClientesRequestDTO> _clientes;
        private readonly IMediator _mediator;
        private int _paginaActual = 1;
        private int _tamanyoPagina = 50;
        private int _total = 0;
        #endregion

        #region Constructor
        public ClientesFrm(IMediator mediator, IGlobalExceptionHandler globalException)
        {
            InitializeComponent();

            _mediator = mediator;
            _globalException = globalException;
            ConfigurarGrid();
        }
        #endregion

        #region Methods
        private async void ClientesFrm_Load(object sender, EventArgs e)
        {
            //var query = new GetAllClientesQuery { TipoRepositorio = "ADO", PageNumber = _paginaActual, PageSize = _tamanyoPagina };
            //var clientes = await _mediator.Send(query);
            //_clientes = clientes.Item1;
            //_total = clientes.Item2;
            //gridViewClientes.DataSource = _clientes.ToList();
            //CargarPagina();
            _paginaActual = 1;
            await CargarPagina();
        }
        private void ConfigurarGrid()
        {
            gridViewClientes.Width = 500;
            gridViewClientes.Height = 300;
            gridViewClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridViewClientes.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            gridViewClientes.AllowUserToAddRows = false;
            gridViewClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridViewClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            gridViewClientes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridViewClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            gridViewClientes.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            gridViewClientes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        private async Task CargarPagina()
        {
            //var clientesPaginados = _clientes
            //    .Skip((_paginaActual - 1) * _tamanyoPagina)
            //    .Take(_tamanyoPagina)
            //.ToList();
            var query = new GetAllClientesQuery { TipoRepositorio = "ADO", PageNumber = _paginaActual, PageSize = _tamanyoPagina };
            var clientes = await _mediator.Send(query);
            _clientes = clientes.Item1;
            _total = clientes.Item2;
            int totalPaginas = (int)Math.Ceiling((double)_total / _tamanyoPagina);

            gridViewClientes.DataSource = _clientes.ToList();
            lblPagina.Text = $"Pagina {_paginaActual} de {totalPaginas}";
            lblRegistros.Text = $"Registros: {_clientes.Count.ToString("###,###,###,###")}";
            lblTotalRegistros.Text = $"Total: {_total.ToString("###,###,###,###")}";
        }

        // TODO: agregar progressbar
        //private async Task ProcessData(List<string> list, IProgress<ProgressBarReport> progress, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        int index = 1;
        //        int totalProcess = list.Count;
        //        var progressBarReport = new ProgressBarReport();

        //        await Task.Run(() =>
        //        {
        //            for (int i = 0; i < totalProcess; i++)
        //            {
        //                cancellationToken.ThrowIfCancellationRequested();
        //                progressBarReport.Porcentaje = index++ * 100 / totalProcess;
        //                progress.Report(progressBarReport);
        //                Thread.Sleep(10);
        //            }
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        _globalException.CaptureException<string>(ex, ApplicationLayer.Presentation, ActionType.LaunchForm);
        //    }
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
        }

        //private async void btnStart_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        List<string> list = new List<string>();
        //        for (int i = 0; i < 100; i++)
        //        {
        //            list.Add(i.ToString());
        //        }

        //        lblPercentage.Text = "Working...";
        //        progressBar.Value = 0;
        //        _cancellationTokenSource = new CancellationTokenSource();

        //        var progress = new Progress<ProgressBarReport>(report =>
        //        {
        //            progressBar.Value = report.Porcentaje;
        //            lblPercentage.Text = $"{report.Porcentaje}%";
        //        });

        //        try
        //        {
        //            await ProcessData(list, progress, _cancellationTokenSource.Token);
        //            lblPercentage.Text = "Completed!";
        //        }
        //        catch (OperationCanceledException)
        //        {
        //            lblPercentage.Text = "Operation canceled.";
        //        }
        //        finally
        //        {
        //            _cancellationTokenSource.Dispose();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        _globalException.CaptureException<string>(ex, ApplicationLayer.Presentation, ActionType.LaunchForm);
        //    }
        //}
        #endregion

        private async void btnRecargar_Click(object sender, EventArgs e)
        {
            try
            {
                var query = new GetAllClientesQuery { TipoRepositorio = "ADO", PageNumber = _paginaActual, PageSize = _tamanyoPagina };
                var clientes = await _mediator.Send(query);
                _clientes = clientes.Item1;
                _total = clientes.Item2;
                int totalPaginas = (int)Math.Ceiling((double)_total / _tamanyoPagina);

                if (_clientes.Count != 0)
                {
                    gridViewClientes.DataSource = _clientes;
                    lblPagina.Text = $"Pagina {_paginaActual} de {totalPaginas}";
                    lblRegistros.Text = $"Registros: {_clientes.Count.ToString("###,###,###,###")}";
                    lblTotalRegistros.Text = $"Total: {_total.ToString("###,###,###,###")}";
                }
            }
            catch (Exception ex)
            {
                _globalException.CaptureException<string>(ex, ApplicationLayer.Presentation, ActionType.LaunchForm);
            }
        }

        private async void btnSiguiente_Click(object sender, EventArgs e)
        {
            int totalPaginas = (int)Math.Ceiling((double)_total / _tamanyoPagina);
            if (_paginaActual < totalPaginas)
            {
                _paginaActual++;
                await CargarPagina();
            }
        }

        private async void btnAnterior_Click(object sender, EventArgs e)
        {
            if (_paginaActual > 1)
            {
                _paginaActual--;
                await CargarPagina();
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.ToLower();
            if (!string.IsNullOrEmpty(filtro))
            {

                //var filtro = _clientes.Where(
                //        x => x.Nombre.ToLower().Contains(buscar) ||
                //        x.Apellido.ToLower().Contains(buscar) ||
                //        x.Id.ToLower().Contains(buscar) ||
                //        x.RFC.ToLower().Contains(buscar)
                //    ).ToList();
                var query = new GetAllClientesQuery { TipoRepositorio = "ADO", PageNumber = _paginaActual, PageSize = _tamanyoPagina, Search = filtro };
                var clientes = await _mediator.Send(query);
                _clientes = clientes.Item1;
                _total = clientes.Item2;
                int totalPaginas = (int)Math.Ceiling((double)_total / _tamanyoPagina);

                gridViewClientes.DataSource = _clientes;
                lblRegistros.Text = $"Registros filtrados: {totalPaginas.ToString("###,###,###,###")}";
            }
            else
            {
                gridViewClientes.DataSource = _clientes;
                lblRegistros.Text = $"Registros mostrados: {_clientes.Count.ToString("###,###,###,###")}";
            }
        }
    }
}
