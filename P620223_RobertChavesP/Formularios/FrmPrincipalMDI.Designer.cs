namespace P620223_RobertChavesP.Formularios
{
    partial class FrmPrincipalMDI
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
            this.components = new System.ComponentModel.Container();
            this.MnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.MnuMantenimietos = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuUsuariosGestion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuClientesGestion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuImpuestosGestion = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuInventarioGetion = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuCategoriaGestion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuProveedoresGestion = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuProcesos = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFacturacion = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuVentasRangoFechas = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuVentasCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuVentasUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuListaClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuListaProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuListaInventarioActual = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuFacturasReimpresion = new System.Windows.Forms.ToolStripMenuItem();
            this.aCERCADEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblUsuarioLogueando = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblFechaYHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.TmrFechaHora = new System.Windows.Forms.Timer(this.components);
            this.MnuPrincipal.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MnuPrincipal
            // 
            this.MnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuMantenimietos,
            this.MnuProcesos,
            this.MnuReportes,
            this.aCERCADEToolStripMenuItem});
            this.MnuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.MnuPrincipal.Name = "MnuPrincipal";
            this.MnuPrincipal.Size = new System.Drawing.Size(800, 24);
            this.MnuPrincipal.TabIndex = 1;
            this.MnuPrincipal.Text = "menuStrip1";
            // 
            // MnuMantenimietos
            // 
            this.MnuMantenimietos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuUsuariosGestion,
            this.toolStripSeparator1,
            this.MnuClientesGestion,
            this.toolStripSeparator2,
            this.MnuImpuestosGestion,
            this.MnuInventarioGetion,
            this.MnuCategoriaGestion,
            this.toolStripSeparator3,
            this.MnuProveedoresGestion});
            this.MnuMantenimietos.Name = "MnuMantenimietos";
            this.MnuMantenimietos.Size = new System.Drawing.Size(120, 20);
            this.MnuMantenimietos.Text = "MANTENIMIENTOS";
            this.MnuMantenimietos.Click += new System.EventHandler(this.mANTENIMIENTOSToolStripMenuItem_Click);
            // 
            // MnuUsuariosGestion
            // 
            this.MnuUsuariosGestion.Name = "MnuUsuariosGestion";
            this.MnuUsuariosGestion.Size = new System.Drawing.Size(205, 22);
            this.MnuUsuariosGestion.Text = "USUARIOS";
            this.MnuUsuariosGestion.Click += new System.EventHandler(this.uSUARIOSToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // MnuClientesGestion
            // 
            this.MnuClientesGestion.Name = "MnuClientesGestion";
            this.MnuClientesGestion.Size = new System.Drawing.Size(205, 22);
            this.MnuClientesGestion.Text = "CLIENTES";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(202, 6);
            // 
            // MnuImpuestosGestion
            // 
            this.MnuImpuestosGestion.Name = "MnuImpuestosGestion";
            this.MnuImpuestosGestion.Size = new System.Drawing.Size(205, 22);
            this.MnuImpuestosGestion.Text = "IMPUESTOS";
            // 
            // MnuInventarioGetion
            // 
            this.MnuInventarioGetion.Name = "MnuInventarioGetion";
            this.MnuInventarioGetion.Size = new System.Drawing.Size(205, 22);
            this.MnuInventarioGetion.Text = "INVENTARIO";
            // 
            // MnuCategoriaGestion
            // 
            this.MnuCategoriaGestion.Name = "MnuCategoriaGestion";
            this.MnuCategoriaGestion.Size = new System.Drawing.Size(205, 22);
            this.MnuCategoriaGestion.Text = "CATEGORIA INVENTARIO";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(202, 6);
            // 
            // MnuProveedoresGestion
            // 
            this.MnuProveedoresGestion.Name = "MnuProveedoresGestion";
            this.MnuProveedoresGestion.Size = new System.Drawing.Size(205, 22);
            this.MnuProveedoresGestion.Text = "PROVEEDORES";
            // 
            // MnuProcesos
            // 
            this.MnuProcesos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFacturacion});
            this.MnuProcesos.Name = "MnuProcesos";
            this.MnuProcesos.Size = new System.Drawing.Size(77, 20);
            this.MnuProcesos.Text = "PROCESOS";
            this.MnuProcesos.Click += new System.EventHandler(this.pROCESOSToolStripMenuItem_Click);
            // 
            // MnuFacturacion
            // 
            this.MnuFacturacion.Name = "MnuFacturacion";
            this.MnuFacturacion.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.MnuFacturacion.Size = new System.Drawing.Size(193, 22);
            this.MnuFacturacion.Text = "FACTURACION";
            this.MnuFacturacion.Click += new System.EventHandler(this.MnuFacturacion_Click);
            // 
            // MnuReportes
            // 
            this.MnuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuVentasRangoFechas,
            this.MnuVentasCliente,
            this.MnuVentasUsuario,
            this.toolStripSeparator4,
            this.MnuListaClientes,
            this.MnuListaProveedores,
            this.MnuListaInventarioActual,
            this.toolStripSeparator5,
            this.MnuFacturasReimpresion});
            this.MnuReportes.Name = "MnuReportes";
            this.MnuReportes.Size = new System.Drawing.Size(138, 20);
            this.MnuReportes.Text = "GALERIA DE REPORTES";
            this.MnuReportes.Click += new System.EventHandler(this.gALERIADEREPORTESToolStripMenuItem_Click);
            // 
            // MnuVentasRangoFechas
            // 
            this.MnuVentasRangoFechas.Name = "MnuVentasRangoFechas";
            this.MnuVentasRangoFechas.Size = new System.Drawing.Size(248, 22);
            this.MnuVentasRangoFechas.Text = "VENTAS POR RANGO DE FECHAS";
            // 
            // MnuVentasCliente
            // 
            this.MnuVentasCliente.Name = "MnuVentasCliente";
            this.MnuVentasCliente.Size = new System.Drawing.Size(248, 22);
            this.MnuVentasCliente.Text = "VENTAS POR CLIENTE";
            // 
            // MnuVentasUsuario
            // 
            this.MnuVentasUsuario.Name = "MnuVentasUsuario";
            this.MnuVentasUsuario.Size = new System.Drawing.Size(248, 22);
            this.MnuVentasUsuario.Text = "VENTAS POR USUARIO";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(245, 6);
            // 
            // MnuListaClientes
            // 
            this.MnuListaClientes.Name = "MnuListaClientes";
            this.MnuListaClientes.Size = new System.Drawing.Size(248, 22);
            this.MnuListaClientes.Text = "LISTADO CLIENTES";
            // 
            // MnuListaProveedores
            // 
            this.MnuListaProveedores.Name = "MnuListaProveedores";
            this.MnuListaProveedores.Size = new System.Drawing.Size(248, 22);
            this.MnuListaProveedores.Text = "LISTADO PROVEEDOR";
            // 
            // MnuListaInventarioActual
            // 
            this.MnuListaInventarioActual.Name = "MnuListaInventarioActual";
            this.MnuListaInventarioActual.Size = new System.Drawing.Size(248, 22);
            this.MnuListaInventarioActual.Text = "LISTA INVENTARIO ACTUAL";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(245, 6);
            // 
            // MnuFacturasReimpresion
            // 
            this.MnuFacturasReimpresion.Name = "MnuFacturasReimpresion";
            this.MnuFacturasReimpresion.Size = new System.Drawing.Size(248, 22);
            this.MnuFacturasReimpresion.Text = "REIMPRESION FACTURAS";
            // 
            // aCERCADEToolStripMenuItem
            // 
            this.aCERCADEToolStripMenuItem.Name = "aCERCADEToolStripMenuItem";
            this.aCERCADEToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.aCERCADEToolStripMenuItem.Text = "ACERCA DE ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.LblUsuarioLogueando,
            this.LblFechaYHora});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(62, 17);
            this.toolStripStatusLabel1.Text = "USUARIO: ";
            // 
            // LblUsuarioLogueando
            // 
            this.LblUsuarioLogueando.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuarioLogueando.Name = "LblUsuarioLogueando";
            this.LblUsuarioLogueando.Size = new System.Drawing.Size(49, 17);
            this.LblUsuarioLogueando.Text = "Usuario";
            // 
            // LblFechaYHora
            // 
            this.LblFechaYHora.Name = "LblFechaYHora";
            this.LblFechaYHora.Size = new System.Drawing.Size(674, 17);
            this.LblFechaYHora.Spring = true;
            this.LblFechaYHora.Text = "FechaHora";
            this.LblFechaYHora.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TmrFechaHora
            // 
            this.TmrFechaHora.Interval = 1000;
            this.TmrFechaHora.Tick += new System.EventHandler(this.TmrFechaHora_Tick);
            // 
            // FrmPrincipalMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MnuPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MnuPrincipal;
            this.Name = "FrmPrincipalMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "P5 Facturacion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPrincipalMDI_FormClosed);
            this.Load += new System.EventHandler(this.FrmPrincipalMDI_Load);
            this.MnuPrincipal.ResumeLayout(false);
            this.MnuPrincipal.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MnuPrincipal;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem MnuMantenimietos;
        private System.Windows.Forms.ToolStripMenuItem MnuUsuariosGestion;
        private System.Windows.Forms.ToolStripMenuItem MnuClientesGestion;
        private System.Windows.Forms.ToolStripMenuItem MnuImpuestosGestion;
        private System.Windows.Forms.ToolStripMenuItem MnuInventarioGetion;
        private System.Windows.Forms.ToolStripMenuItem MnuCategoriaGestion;
        private System.Windows.Forms.ToolStripMenuItem MnuProveedoresGestion;
        private System.Windows.Forms.ToolStripMenuItem MnuProcesos;
        private System.Windows.Forms.ToolStripMenuItem MnuReportes;
        private System.Windows.Forms.ToolStripMenuItem aCERCADEToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem MnuFacturacion;
        private System.Windows.Forms.ToolStripMenuItem MnuVentasRangoFechas;
        private System.Windows.Forms.ToolStripMenuItem MnuVentasCliente;
        private System.Windows.Forms.ToolStripMenuItem MnuVentasUsuario;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem MnuListaClientes;
        private System.Windows.Forms.ToolStripMenuItem MnuListaProveedores;
        private System.Windows.Forms.ToolStripMenuItem MnuListaInventarioActual;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem MnuFacturasReimpresion;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel LblUsuarioLogueando;
        private System.Windows.Forms.ToolStripStatusLabel LblFechaYHora;
        private System.Windows.Forms.Timer TmrFechaHora;
    }
}