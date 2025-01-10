namespace Saga.TestCase.Presentation.Forms
{
    partial class EdicionArchivosFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbLayoutEdicion = new TableLayoutPanel();
            pnEdicionTop = new Panel();
            btnExportar = new Button();
            txtEdicion = new TextBox();
            btnAgregar = new Button();
            btnActualizar = new Button();
            pnEdicionBotton = new Panel();
            btnAnterior = new Button();
            btnSiguiente = new Button();
            gridEdicion = new DataGridView();
            lblTotalRegistros = new Label();
            lblRegistros = new Label();
            lblPagina = new Label();
            tbLayoutEdicion.SuspendLayout();
            pnEdicionTop.SuspendLayout();
            pnEdicionBotton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridEdicion).BeginInit();
            SuspendLayout();
            // 
            // tbLayoutEdicion
            // 
            tbLayoutEdicion.ColumnCount = 1;
            tbLayoutEdicion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbLayoutEdicion.Controls.Add(pnEdicionTop, 0, 0);
            tbLayoutEdicion.Controls.Add(pnEdicionBotton, 0, 2);
            tbLayoutEdicion.Controls.Add(gridEdicion, 0, 1);
            tbLayoutEdicion.Dock = DockStyle.Fill;
            tbLayoutEdicion.Location = new Point(0, 0);
            tbLayoutEdicion.Name = "tbLayoutEdicion";
            tbLayoutEdicion.RowCount = 3;
            tbLayoutEdicion.RowStyles.Add(new RowStyle(SizeType.Percent, 19.7530861F));
            tbLayoutEdicion.RowStyles.Add(new RowStyle(SizeType.Percent, 80.24691F));
            tbLayoutEdicion.RowStyles.Add(new RowStyle(SizeType.Absolute, 79F));
            tbLayoutEdicion.Size = new Size(1075, 647);
            tbLayoutEdicion.TabIndex = 0;
            // 
            // pnEdicionTop
            // 
            pnEdicionTop.Controls.Add(lblTotalRegistros);
            pnEdicionTop.Controls.Add(btnExportar);
            pnEdicionTop.Controls.Add(lblRegistros);
            pnEdicionTop.Controls.Add(txtEdicion);
            pnEdicionTop.Controls.Add(lblPagina);
            pnEdicionTop.Controls.Add(btnAgregar);
            pnEdicionTop.Controls.Add(btnActualizar);
            pnEdicionTop.Dock = DockStyle.Fill;
            pnEdicionTop.Location = new Point(3, 3);
            pnEdicionTop.Name = "pnEdicionTop";
            pnEdicionTop.Size = new Size(1069, 106);
            pnEdicionTop.TabIndex = 0;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(943, 19);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(113, 49);
            btnExportar.TabIndex = 9;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // txtEdicion
            // 
            txtEdicion.Location = new Point(563, 30);
            txtEdicion.Name = "txtEdicion";
            txtEdicion.Size = new Size(374, 27);
            txtEdicion.TabIndex = 8;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(311, 19);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(113, 49);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(430, 18);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(113, 49);
            btnActualizar.TabIndex = 6;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // pnEdicionBotton
            // 
            pnEdicionBotton.Controls.Add(btnAnterior);
            pnEdicionBotton.Controls.Add(btnSiguiente);
            pnEdicionBotton.Dock = DockStyle.Fill;
            pnEdicionBotton.Location = new Point(3, 570);
            pnEdicionBotton.Name = "pnEdicionBotton";
            pnEdicionBotton.Size = new Size(1069, 74);
            pnEdicionBotton.TabIndex = 3;
            // 
            // btnAnterior
            // 
            btnAnterior.Location = new Point(820, 16);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(113, 49);
            btnAnterior.TabIndex = 3;
            btnAnterior.Text = "Anterior";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Location = new Point(943, 16);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(113, 49);
            btnSiguiente.TabIndex = 2;
            btnSiguiente.Text = "Siguiente";
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // gridEdicion
            // 
            gridEdicion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridEdicion.Dock = DockStyle.Fill;
            gridEdicion.Location = new Point(3, 115);
            gridEdicion.Name = "gridEdicion";
            gridEdicion.RowHeadersWidth = 51;
            gridEdicion.Size = new Size(1069, 449);
            gridEdicion.TabIndex = 4;
            // 
            // lblTotalRegistros
            // 
            lblTotalRegistros.AutoSize = true;
            lblTotalRegistros.Location = new Point(4, 83);
            lblTotalRegistros.Name = "lblTotalRegistros";
            lblTotalRegistros.Size = new Size(42, 20);
            lblTotalRegistros.TabIndex = 9;
            lblTotalRegistros.Text = "Total";
            // 
            // lblRegistros
            // 
            lblRegistros.AutoSize = true;
            lblRegistros.Location = new Point(3, 47);
            lblRegistros.Name = "lblRegistros";
            lblRegistros.Size = new Size(70, 20);
            lblRegistros.TabIndex = 8;
            lblRegistros.Text = "Registros";
            // 
            // lblPagina
            // 
            lblPagina.AutoSize = true;
            lblPagina.Location = new Point(3, 18);
            lblPagina.Name = "lblPagina";
            lblPagina.Size = new Size(53, 20);
            lblPagina.TabIndex = 7;
            lblPagina.Text = "Pagina";
            // 
            // EdicionArchivosFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1075, 647);
            Controls.Add(tbLayoutEdicion);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "EdicionArchivosFrm";
            Text = "EdicionArchivosFrm";
            tbLayoutEdicion.ResumeLayout(false);
            pnEdicionTop.ResumeLayout(false);
            pnEdicionTop.PerformLayout();
            pnEdicionBotton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridEdicion).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tbLayoutEdicion;
        private Panel pnEdicionTop;
        private TextBox txtEdicion;
        private Button btnAgregar;
        private Button btnActualizar;
        private Panel pnEdicionBotton;
        private Button btnAnterior;
        private Button btnSiguiente;
        private DataGridView gridEdicion;
        private Button btnExportar;
        private Label lblTotalRegistros;
        private Label lblRegistros;
        private Label lblPagina;
    }
}