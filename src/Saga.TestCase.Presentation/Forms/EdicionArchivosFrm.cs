using MediatR;
using Saga.TestCase.Application.Clientes.Commands.Dto;
using Saga.TestCase.Infrastructure.Interfaces;

namespace Saga.TestCase.Presentation.Forms
{
    public partial class EdicionArchivosFrm : Form
    {
        #region Properties
        private IGlobalExceptionHandler _globalException;
        private CancellationTokenSource _cancellationTokenSource;
        private List<ClientesRequestDTO> _clientes = new List<ClientesRequestDTO>();
        private readonly IMediator _mediator;
        private int _paginaActual = 1;
        private int _tamanyoPagina = 100;
        private int _total = 0;
        #endregion

        public EdicionArchivosFrm(IMediator mediator, IGlobalExceptionHandler globalException)
        {
            InitializeComponent();

            _mediator = mediator;
            _globalException = globalException;
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            gridEdicion.Width = 500;
            gridEdicion.Height = 300;
            gridEdicion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridEdicion.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            gridEdicion.AllowUserToAddRows = false;
            gridEdicion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridEdicion.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            gridEdicion.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridEdicion.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            gridEdicion.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            gridEdicion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private object[] ProcesarLineas(string linea)
        {
            try
            {
                var datos = new object[6];
                string[] secciones = linea.Split(',');

                foreach (var seccion in secciones)
                {
                    var keyValue = seccion.Split(':');
                    if (keyValue.Length == 2)
                    {
                        string key = keyValue[0].Trim();
                        string value = keyValue[1].Trim();

                        switch (key)
                        {
                            case "Cliente - ID":
                                datos[0] = value;
                                break;
                            case "Nombre":
                                datos[1] = value;
                                break;
                            case "Apellido":
                                datos[2] = value;
                                break;
                            case "RFC":
                                datos[3] = value;
                                break;
                            case "CuentaBancariaId":
                                datos[4] = value;
                                break;
                            case "Activo":
                                datos[5] = value;
                                break;
                        }
                    }
                }
                return datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _globalException.CaptureException<string>(ex, ApplicationLayer.Presentation, ActionType.LaunchForm);
            }
            return new object[0];
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
        private async Task CargarPagina()
        {
            gridEdicion.Rows.Clear();

            int startIndex = (_paginaActual - 1) * _tamanyoPagina;
            int endIndex = Math.Min(startIndex + _tamanyoPagina, _clientes.Count);

            if (startIndex >= _clientes.Count)
            {
                MessageBox.Show("No hay más datos para cargar.");
                return;
            }

            for (int i = startIndex; i < endIndex; i++)
            {
                var cliente = _clientes[i];

                gridEdicion.Rows.Add(cliente.Id, cliente.Nombre, cliente.Apellido, cliente.RFC, cliente.CuentaBancariaId, cliente.Activo);
            }

            int totalPaginas = (int)Math.Ceiling((double)_clientes.Count / _tamanyoPagina);
            lblPagina.Text = $"Página {_paginaActual} de {totalPaginas}";
            lblRegistros.Text = $"Registros: {_clientes.Count.ToString("###,###,###,###")}";
            lblTotalRegistros.Text = $"Total: {_total.ToString("###,###,###,###")}";
        }
        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Archivos TXT (*.txt)|*.txt";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = true;

                gridEdicion.Columns.Clear();

                gridEdicion.Columns.Add("Id", "Cliente - ID");
                gridEdicion.Columns.Add("Nombre", "Nombre");
                gridEdicion.Columns.Add("Apellido", "Apellido");
                gridEdicion.Columns.Add("RFC", "RFC");
                gridEdicion.Columns.Add("CuentaBancariaId", "Cuenta Bancaria ID");
                gridEdicion.Columns.Add("Activo", "Activo");

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if(_clientes.Any())
                    {
                        _clientes.Clear();
                    }

                    foreach (var fileName in openFileDialog.FileNames)
                    {
                        using (StreamReader reader = new StreamReader(fileName))
                        {
                            string linea;
                            int contador = 0;

                            while ((linea = reader.ReadLine()) != null)
                            {
                                var datos = ProcesarLineas(linea); 
                                var cliente = new ClientesRequestDTO
                                {
                                    Id = (string)datos[0], 
                                    Nombre = (string)datos[1], 
                                    Apellido = (string)datos[2], 
                                    RFC = (string)datos[3], 
                                    CuentaBancariaId = (string)datos[4],
                                    Activo = true
                                };
                                _clientes.Add(cliente); 
                                contador++;

                                if (contador % 1000 == 0)
                                {
                                    System.Windows.Forms.Application.DoEvents();
                                }
                            }
                        }
                    }
                    _total = _clientes.Count;
                    await CargarPagina();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _globalException.CaptureException<string>(ex, ApplicationLayer.Presentation, ActionType.LaunchForm);
            }
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string agregarCaracter = txtEdicion.Text; 

                foreach (DataGridViewRow row in gridEdicion.Rows)
                {
                    if (row.Cells[0].Value != null) 
                    {
                        row.Cells[0].Value = row.Cells[0].Value.ToString() + agregarCaracter; 
                        row.Cells[1].Value = row.Cells[1].Value.ToString() + agregarCaracter; 
                        row.Cells[2].Value = row.Cells[2].Value.ToString() + agregarCaracter; 
                        row.Cells[3].Value = row.Cells[3].Value.ToString() + agregarCaracter; 
                        row.Cells[4].Value = row.Cells[4].Value.ToString() + agregarCaracter; 
                        row.Cells[5].Value = row.Cells[5].Value.ToString() + agregarCaracter; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _globalException.CaptureException<string>(ex, ApplicationLayer.Presentation, ActionType.LaunchForm);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos Txt (*.txt)|*.txt";
                saveFileDialog.FileName = "nuevos_registros.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (DataGridViewRow row in gridEdicion.Rows)
                        {
                            if (row.IsNewRow) continue; 
                            var datos = new string[row.Cells.Count];
                            for (int i = 0; i < row.Cells.Count; i++)
                            {
                                datos[i] = row.Cells[i].Value?.ToString(); 
                            }

                            writer.WriteLine(string.Join(", ", datos)); 
                        }
                    }

                    MessageBox.Show("Archivo exportado con éxito.", "Exportación completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _globalException.CaptureException<string>(ex, ApplicationLayer.Presentation, ActionType.LaunchForm);
            }
        }
    }
}
