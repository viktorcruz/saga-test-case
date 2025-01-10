namespace Saga.TestCase.Presentation
{
    partial class ClientesFrm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tlpBase = new TableLayoutPanel();
            pnBottom = new Panel();
            btnEliminar = new Button();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnAnterior = new Button();
            btnSiguiente = new Button();
            gridViewClientes = new DataGridView();
            panel1 = new Panel();
            lblTotalRegistros = new Label();
            txtBuscar = new TextBox();
            btnRecargar = new Button();
            btnBuscar = new Button();
            lblRegistros = new Label();
            lblPagina = new Label();
            tlpBase.SuspendLayout();
            pnBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridViewClientes).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tlpBase
            // 
            tlpBase.ColumnCount = 1;
            tlpBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpBase.Controls.Add(pnBottom, 0, 3);
            tlpBase.Controls.Add(gridViewClientes, 0, 2);
            tlpBase.Controls.Add(panel1, 0, 1);
            tlpBase.Dock = DockStyle.Fill;
            tlpBase.Location = new Point(0, 0);
            tlpBase.Name = "tlpBase";
            tlpBase.RowCount = 4;
            tlpBase.RowStyles.Add(new RowStyle(SizeType.Percent, 6.34920645F));
            tlpBase.RowStyles.Add(new RowStyle(SizeType.Percent, 93.650795F));
            tlpBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 451F));
            tlpBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 86F));
            tlpBase.Size = new Size(1071, 634);
            tlpBase.TabIndex = 0;
            // 
            // pnBottom
            // 
            pnBottom.Controls.Add(btnEliminar);
            pnBottom.Controls.Add(btnAgregar);
            pnBottom.Controls.Add(btnActualizar);
            pnBottom.Controls.Add(btnAnterior);
            pnBottom.Controls.Add(btnSiguiente);
            pnBottom.Dock = DockStyle.Bottom;
            pnBottom.Location = new Point(3, 558);
            pnBottom.Name = "pnBottom";
            pnBottom.Size = new Size(1065, 73);
            pnBottom.TabIndex = 0;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(623, 11);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(113, 49);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(385, 12);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(113, 49);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(504, 11);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(113, 49);
            btnActualizar.TabIndex = 2;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnAnterior
            // 
            btnAnterior.Location = new Point(815, 11);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(113, 49);
            btnAnterior.TabIndex = 1;
            btnAnterior.Text = "Anterior";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Location = new Point(938, 11);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(113, 49);
            btnSiguiente.TabIndex = 0;
            btnSiguiente.Text = "Siguiente";
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // gridViewClientes
            // 
            gridViewClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridViewClientes.Dock = DockStyle.Fill;
            gridViewClientes.Location = new Point(3, 99);
            gridViewClientes.Name = "gridViewClientes";
            gridViewClientes.RowHeadersWidth = 51;
            gridViewClientes.Size = new Size(1065, 445);
            gridViewClientes.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblTotalRegistros);
            panel1.Controls.Add(txtBuscar);
            panel1.Controls.Add(btnRecargar);
            panel1.Controls.Add(btnBuscar);
            panel1.Controls.Add(lblRegistros);
            panel1.Controls.Add(lblPagina);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 9);
            panel1.Name = "panel1";
            panel1.Size = new Size(1065, 79);
            panel1.TabIndex = 2;
            // 
            // lblTotalRegistros
            // 
            lblTotalRegistros.AutoSize = true;
            lblTotalRegistros.Location = new Point(231, 39);
            lblTotalRegistros.Name = "lblTotalRegistros";
            lblTotalRegistros.Size = new Size(42, 20);
            lblTotalRegistros.TabIndex = 6;
            lblTotalRegistros.Text = "Total";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(543, 36);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(454, 27);
            txtBuscar.TabIndex = 5;
            // 
            // btnRecargar
            // 
            btnRecargar.Location = new Point(394, 30);
            btnRecargar.Name = "btnRecargar";
            btnRecargar.Size = new Size(76, 39);
            btnRecargar.TabIndex = 4;
            btnRecargar.Text = "Recargar";
            btnRecargar.UseVisualStyleBackColor = true;
            btnRecargar.Click += btnRecargar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(476, 30);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(61, 39);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Burcar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblRegistros
            // 
            lblRegistros.AutoSize = true;
            lblRegistros.Location = new Point(22, 39);
            lblRegistros.Name = "lblRegistros";
            lblRegistros.Size = new Size(70, 20);
            lblRegistros.TabIndex = 1;
            lblRegistros.Text = "Registros";
            // 
            // lblPagina
            // 
            lblPagina.AutoSize = true;
            lblPagina.Location = new Point(22, 0);
            lblPagina.Name = "lblPagina";
            lblPagina.Size = new Size(53, 20);
            lblPagina.TabIndex = 0;
            lblPagina.Text = "Pagina";
            // 
            // ClientesFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1071, 634);
            Controls.Add(tlpBase);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ClientesFrm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clientes";
            Load += ClientesFrm_Load;
            tlpBase.ResumeLayout(false);
            pnBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridViewClientes).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpBase;
        private Panel pnBottom;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnAnterior;
        private Button btnSiguiente;
        private DataGridView gridViewClientes;
        private Panel panel1;
        private Button btnRecargar;
        private Button btnBuscar;
        private Label lblRegistros;
        private Label lblPagina;
        private TextBox txtBuscar;
        private Button btnEliminar;
        private Label lblTotalRegistros;
    }
}
