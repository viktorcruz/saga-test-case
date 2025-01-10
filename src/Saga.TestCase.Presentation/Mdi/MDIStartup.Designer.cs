namespace Saga.TestCase.Presentation.Mdi
{
    partial class MDIStartup
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
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            cargarDatosToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            dToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            productosToolStripMenuItem = new ToolStripMenuItem();
            agregarProductoToolStripMenuItem = new ToolStripMenuItem();
            modificarProductoToolStripMenuItem = new ToolStripMenuItem();
            eliminarProductoToolStripMenuItem = new ToolStripMenuItem();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            agregarVentaToolStripMenuItem = new ToolStripMenuItem();
            modificarVentaToolStripMenuItem = new ToolStripMenuItem();
            eliminarVentaToolStripMenuItem = new ToolStripMenuItem();
            actualizarToolStripMenuItem = new ToolStripMenuItem();
            backupToolStripMenuItem = new ToolStripMenuItem();
            herramientasToolStripMenuItem = new ToolStripMenuItem();
            busquedaExhaustivaToolStripMenuItem = new ToolStripMenuItem();
            opcionesToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripProgressBar1 = new ToolStripProgressBar();
            pnBottom = new Panel();
            rtbErrorDetailLog = new RichTextBox();
            menuStrip.SuspendLayout();
            statusStrip1.SuspendLayout();
            pnBottom.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, dToolStripMenuItem, herramientasToolStripMenuItem, ayudaToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1323, 28);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cargarDatosToolStripMenuItem, salirToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(73, 24);
            fileToolStripMenuItem.Text = "Archivo";
            // 
            // cargarDatosToolStripMenuItem
            // 
            cargarDatosToolStripMenuItem.Name = "cargarDatosToolStripMenuItem";
            cargarDatosToolStripMenuItem.Size = new Size(179, 26);
            cargarDatosToolStripMenuItem.Text = "Cargar Datos";
            cargarDatosToolStripMenuItem.Click += cargarDatosToolStripMenuItem_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(179, 26);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // dToolStripMenuItem
            // 
            dToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clientesToolStripMenuItem, productosToolStripMenuItem, ventasToolStripMenuItem, actualizarToolStripMenuItem, backupToolStripMenuItem });
            dToolStripMenuItem.Name = "dToolStripMenuItem";
            dToolStripMenuItem.Size = new Size(62, 24);
            dToolStripMenuItem.Text = "Datos";
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(224, 26);
            clientesToolStripMenuItem.Text = "Clientes";
            clientesToolStripMenuItem.Click += clientesToolStripMenuItem_Click;
            // 
            // productosToolStripMenuItem
            // 
            productosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { agregarProductoToolStripMenuItem, modificarProductoToolStripMenuItem, eliminarProductoToolStripMenuItem });
            productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            productosToolStripMenuItem.Size = new Size(224, 26);
            productosToolStripMenuItem.Text = "Productos";
            productosToolStripMenuItem.Click += productosToolStripMenuItem_Click;
            // 
            // agregarProductoToolStripMenuItem
            // 
            agregarProductoToolStripMenuItem.Name = "agregarProductoToolStripMenuItem";
            agregarProductoToolStripMenuItem.Size = new Size(220, 26);
            agregarProductoToolStripMenuItem.Text = "Agregar Producto";
            // 
            // modificarProductoToolStripMenuItem
            // 
            modificarProductoToolStripMenuItem.Name = "modificarProductoToolStripMenuItem";
            modificarProductoToolStripMenuItem.Size = new Size(220, 26);
            modificarProductoToolStripMenuItem.Text = "Modificar Producto";
            // 
            // eliminarProductoToolStripMenuItem
            // 
            eliminarProductoToolStripMenuItem.Name = "eliminarProductoToolStripMenuItem";
            eliminarProductoToolStripMenuItem.Size = new Size(220, 26);
            eliminarProductoToolStripMenuItem.Text = "Eliminar Producto";
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { agregarVentaToolStripMenuItem, modificarVentaToolStripMenuItem, eliminarVentaToolStripMenuItem });
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(224, 26);
            ventasToolStripMenuItem.Text = "Ventas";
            ventasToolStripMenuItem.Click += ventasToolStripMenuItem_Click;
            // 
            // agregarVentaToolStripMenuItem
            // 
            agregarVentaToolStripMenuItem.Name = "agregarVentaToolStripMenuItem";
            agregarVentaToolStripMenuItem.Size = new Size(197, 26);
            agregarVentaToolStripMenuItem.Text = "Agregar Venta";
            // 
            // modificarVentaToolStripMenuItem
            // 
            modificarVentaToolStripMenuItem.Name = "modificarVentaToolStripMenuItem";
            modificarVentaToolStripMenuItem.Size = new Size(197, 26);
            modificarVentaToolStripMenuItem.Text = "Modificar Venta";
            // 
            // eliminarVentaToolStripMenuItem
            // 
            eliminarVentaToolStripMenuItem.Name = "eliminarVentaToolStripMenuItem";
            eliminarVentaToolStripMenuItem.Size = new Size(197, 26);
            eliminarVentaToolStripMenuItem.Text = "Eliminar Venta";
            // 
            // actualizarToolStripMenuItem
            // 
            actualizarToolStripMenuItem.Name = "actualizarToolStripMenuItem";
            actualizarToolStripMenuItem.Size = new Size(224, 26);
            actualizarToolStripMenuItem.Text = "Actualizar";
            actualizarToolStripMenuItem.Click += actualizarToolStripMenuItem_Click;
            // 
            // backupToolStripMenuItem
            // 
            backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            backupToolStripMenuItem.Size = new Size(224, 26);
            backupToolStripMenuItem.Text = "Backup";
            backupToolStripMenuItem.Click += backupToolStripMenuItem_Click;
            // 
            // herramientasToolStripMenuItem
            // 
            herramientasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { busquedaExhaustivaToolStripMenuItem, opcionesToolStripMenuItem });
            herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            herramientasToolStripMenuItem.Size = new Size(112, 24);
            herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // busquedaExhaustivaToolStripMenuItem
            // 
            busquedaExhaustivaToolStripMenuItem.Name = "busquedaExhaustivaToolStripMenuItem";
            busquedaExhaustivaToolStripMenuItem.Size = new Size(230, 26);
            busquedaExhaustivaToolStripMenuItem.Text = "Busqueda Exhaustiva";
            busquedaExhaustivaToolStripMenuItem.Click += busquedaExhaustivaToolStripMenuItem_Click;
            // 
            // opcionesToolStripMenuItem
            // 
            opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            opcionesToolStripMenuItem.Size = new Size(230, 26);
            opcionesToolStripMenuItem.Text = "Opciones";
            opcionesToolStripMenuItem.Click += opcionesToolStripMenuItem_Click;
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { acercaDeToolStripMenuItem });
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(65, 24);
            ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(171, 26);
            acercaDeToolStripMenuItem.Text = "Acerca de ...";
            acercaDeToolStripMenuItem.Click += acercaDeToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 886);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1323, 23);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 15);
            // 
            // pnBottom
            // 
            pnBottom.AutoScroll = true;
            pnBottom.Controls.Add(rtbErrorDetailLog);
            pnBottom.Dock = DockStyle.Bottom;
            pnBottom.Location = new Point(0, 790);
            pnBottom.Name = "pnBottom";
            pnBottom.Size = new Size(1323, 96);
            pnBottom.TabIndex = 4;
            // 
            // rtbErrorDetailLog
            // 
            rtbErrorDetailLog.Dock = DockStyle.Fill;
            rtbErrorDetailLog.Location = new Point(0, 0);
            rtbErrorDetailLog.Name = "rtbErrorDetailLog";
            rtbErrorDetailLog.Size = new Size(1323, 96);
            rtbErrorDetailLog.TabIndex = 0;
            rtbErrorDetailLog.Text = "";
            // 
            // MDIStartup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1323, 909);
            Controls.Add(pnBottom);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Name = "MDIStartup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Saga / Test Case";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            pnBottom.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem cargarDatosToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem dToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem productosToolStripMenuItem;
        private ToolStripMenuItem agregarProductoToolStripMenuItem;
        private ToolStripMenuItem modificarProductoToolStripMenuItem;
        private ToolStripMenuItem eliminarProductoToolStripMenuItem;
        private ToolStripMenuItem ventasToolStripMenuItem;
        private ToolStripMenuItem agregarVentaToolStripMenuItem;
        private ToolStripMenuItem modificarVentaToolStripMenuItem;
        private ToolStripMenuItem eliminarVentaToolStripMenuItem;
        private ToolStripMenuItem actualizarToolStripMenuItem;
        private ToolStripMenuItem herramientasToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
        private ToolStripMenuItem backupToolStripMenuItem;
        private ToolStripMenuItem opcionesToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar toolStripProgressBar1;
        private Panel pnBottom;
        private ToolStripMenuItem busquedaExhaustivaToolStripMenuItem;
        private RichTextBox rtbErrorDetailLog;
    }
}