namespace CapaPresentacion
{
    partial class Home
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuUsuarios = new FontAwesome.Sharp.IconMenuItem();
            this.menuMantenedor = new FontAwesome.Sharp.IconMenuItem();
            this.submenuCategoria = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuProducto = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVentas = new FontAwesome.Sharp.IconMenuItem();
            this.submenuRegistrarVenta = new FontAwesome.Sharp.IconMenuItem();
            this.submenuDetalleVenta = new FontAwesome.Sharp.IconMenuItem();
            this.menuCompras = new FontAwesome.Sharp.IconMenuItem();
            this.submenuRegistrarCompra = new FontAwesome.Sharp.IconMenuItem();
            this.submenuDetalleCompra = new FontAwesome.Sharp.IconMenuItem();
            this.menuClientes = new FontAwesome.Sharp.IconMenuItem();
            this.menuProveedores = new FontAwesome.Sharp.IconMenuItem();
            this.menuReportes = new FontAwesome.Sharp.IconMenuItem();
            this.menuAcercaDe = new FontAwesome.Sharp.IconMenuItem();
            this.menuTitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.panelHome = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsuarios,
            this.menuMantenedor,
            this.menuVentas,
            this.menuCompras,
            this.menuClientes,
            this.menuProveedores,
            this.menuReportes,
            this.menuAcercaDe});
            this.menu.Location = new System.Drawing.Point(0, 63);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(983, 74);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuUsuarios
            // 
            this.menuUsuarios.AutoSize = false;
            this.menuUsuarios.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            this.menuUsuarios.IconColor = System.Drawing.Color.Black;
            this.menuUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuUsuarios.IconSize = 50;
            this.menuUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuUsuarios.Name = "menuUsuarios";
            this.menuUsuarios.Size = new System.Drawing.Size(90, 70);
            this.menuUsuarios.Text = "Usuarios";
            this.menuUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuUsuarios.Click += new System.EventHandler(this.menuUsuarios_Click);
            // 
            // menuMantenedor
            // 
            this.menuMantenedor.AutoSize = false;
            this.menuMantenedor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuCategoria,
            this.submenuProducto});
            this.menuMantenedor.IconChar = FontAwesome.Sharp.IconChar.Tools;
            this.menuMantenedor.IconColor = System.Drawing.Color.Black;
            this.menuMantenedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuMantenedor.IconSize = 50;
            this.menuMantenedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuMantenedor.Name = "menuMantenedor";
            this.menuMantenedor.Size = new System.Drawing.Size(120, 70);
            this.menuMantenedor.Text = "Mantenedor";
            this.menuMantenedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuCategoria
            // 
            this.submenuCategoria.Name = "submenuCategoria";
            this.submenuCategoria.Size = new System.Drawing.Size(157, 26);
            this.submenuCategoria.Text = "Categoria";
            this.submenuCategoria.Click += new System.EventHandler(this.submenuCategoria_Click);
            // 
            // submenuProducto
            // 
            this.submenuProducto.Name = "submenuProducto";
            this.submenuProducto.Size = new System.Drawing.Size(157, 26);
            this.submenuProducto.Text = "Producto";
            this.submenuProducto.Click += new System.EventHandler(this.submenuProducto_Click);
            // 
            // menuVentas
            // 
            this.menuVentas.AutoSize = false;
            this.menuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuRegistrarVenta,
            this.submenuDetalleVenta});
            this.menuVentas.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.menuVentas.IconColor = System.Drawing.Color.Black;
            this.menuVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuVentas.IconSize = 50;
            this.menuVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuVentas.Name = "menuVentas";
            this.menuVentas.Size = new System.Drawing.Size(90, 70);
            this.menuVentas.Text = "Ventas";
            this.menuVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuRegistrarVenta
            // 
            this.submenuRegistrarVenta.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuRegistrarVenta.IconColor = System.Drawing.Color.Black;
            this.submenuRegistrarVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuRegistrarVenta.Name = "submenuRegistrarVenta";
            this.submenuRegistrarVenta.Size = new System.Drawing.Size(165, 26);
            this.submenuRegistrarVenta.Text = "Registrar";
            this.submenuRegistrarVenta.Click += new System.EventHandler(this.submenuRegistrarVenta_Click);
            // 
            // submenuDetalleVenta
            // 
            this.submenuDetalleVenta.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuDetalleVenta.IconColor = System.Drawing.Color.Black;
            this.submenuDetalleVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuDetalleVenta.Name = "submenuDetalleVenta";
            this.submenuDetalleVenta.Size = new System.Drawing.Size(165, 26);
            this.submenuDetalleVenta.Text = "Ver Detalle";
            this.submenuDetalleVenta.Click += new System.EventHandler(this.submenuDetalleVenta_Click);
            // 
            // menuCompras
            // 
            this.menuCompras.AutoSize = false;
            this.menuCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuRegistrarCompra,
            this.submenuDetalleCompra});
            this.menuCompras.IconChar = FontAwesome.Sharp.IconChar.DollyFlatbed;
            this.menuCompras.IconColor = System.Drawing.Color.Black;
            this.menuCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuCompras.IconSize = 50;
            this.menuCompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuCompras.Name = "menuCompras";
            this.menuCompras.Size = new System.Drawing.Size(90, 70);
            this.menuCompras.Text = "Compras";
            this.menuCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuRegistrarCompra
            // 
            this.submenuRegistrarCompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuRegistrarCompra.IconColor = System.Drawing.Color.Black;
            this.submenuRegistrarCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuRegistrarCompra.Name = "submenuRegistrarCompra";
            this.submenuRegistrarCompra.Size = new System.Drawing.Size(165, 26);
            this.submenuRegistrarCompra.Text = "Registrar";
            this.submenuRegistrarCompra.Click += new System.EventHandler(this.submenuRegistrarCompra_Click);
            // 
            // submenuDetalleCompra
            // 
            this.submenuDetalleCompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuDetalleCompra.IconColor = System.Drawing.Color.Black;
            this.submenuDetalleCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuDetalleCompra.Name = "submenuDetalleCompra";
            this.submenuDetalleCompra.Size = new System.Drawing.Size(165, 26);
            this.submenuDetalleCompra.Text = "Ver Detalle";
            this.submenuDetalleCompra.Click += new System.EventHandler(this.submenuDetalleCompra_Click);
            // 
            // menuClientes
            // 
            this.menuClientes.AutoSize = false;
            this.menuClientes.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.menuClientes.IconColor = System.Drawing.Color.Black;
            this.menuClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuClientes.IconSize = 50;
            this.menuClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuClientes.Name = "menuClientes";
            this.menuClientes.Size = new System.Drawing.Size(90, 70);
            this.menuClientes.Text = "Clientes";
            this.menuClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuClientes.Click += new System.EventHandler(this.menuClientes_Click);
            // 
            // menuProveedores
            // 
            this.menuProveedores.AutoSize = false;
            this.menuProveedores.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.menuProveedores.IconColor = System.Drawing.Color.Black;
            this.menuProveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuProveedores.IconSize = 50;
            this.menuProveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuProveedores.Name = "menuProveedores";
            this.menuProveedores.Size = new System.Drawing.Size(120, 70);
            this.menuProveedores.Text = "Proveedores";
            this.menuProveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuProveedores.Click += new System.EventHandler(this.menuProveedores_Click);
            // 
            // menuReportes
            // 
            this.menuReportes.AutoSize = false;
            this.menuReportes.IconChar = FontAwesome.Sharp.IconChar.BarChart;
            this.menuReportes.IconColor = System.Drawing.Color.Black;
            this.menuReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuReportes.IconSize = 50;
            this.menuReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuReportes.Name = "menuReportes";
            this.menuReportes.Size = new System.Drawing.Size(90, 70);
            this.menuReportes.Text = "Reportes";
            this.menuReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuReportes.Click += new System.EventHandler(this.menuReportes_Click);
            // 
            // menuAcercaDe
            // 
            this.menuAcercaDe.AutoSize = false;
            this.menuAcercaDe.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.menuAcercaDe.IconColor = System.Drawing.Color.Black;
            this.menuAcercaDe.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuAcercaDe.IconSize = 50;
            this.menuAcercaDe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuAcercaDe.Name = "menuAcercaDe";
            this.menuAcercaDe.Size = new System.Drawing.Size(120, 70);
            this.menuAcercaDe.Text = "Acerca de";
            this.menuAcercaDe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuTitulo
            // 
            this.menuTitulo.AutoSize = false;
            this.menuTitulo.BackColor = System.Drawing.Color.SteelBlue;
            this.menuTitulo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTitulo.Location = new System.Drawing.Point(0, 0);
            this.menuTitulo.Name = "menuTitulo";
            this.menuTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuTitulo.Size = new System.Drawing.Size(983, 63);
            this.menuTitulo.TabIndex = 1;
            this.menuTitulo.Text = "menuStrip2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "SISTEMA DE VENTAS";
            // 
            // panelHome
            // 
            this.panelHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHome.Location = new System.Drawing.Point(0, 137);
            this.panelHome.Name = "panelHome";
            this.panelHome.Size = new System.Drawing.Size(983, 544);
            this.panelHome.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(658, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario: ";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.SteelBlue;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(734, 13);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(132, 22);
            this.lblUsuario.TabIndex = 5;
            this.lblUsuario.Text = "nombreUsuario";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 681);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelHome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menuTitulo);
            this.MainMenuStrip = this.menu;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Home_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.MenuStrip menuTitulo;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconMenuItem menuUsuarios;
        private FontAwesome.Sharp.IconMenuItem menuClientes;
        private FontAwesome.Sharp.IconMenuItem menuMantenedor;
        private FontAwesome.Sharp.IconMenuItem menuVentas;
        private FontAwesome.Sharp.IconMenuItem menuCompras;
        private FontAwesome.Sharp.IconMenuItem menuProveedores;
        private FontAwesome.Sharp.IconMenuItem menuReportes;
        private FontAwesome.Sharp.IconMenuItem menuAcercaDe;
        private System.Windows.Forms.Panel panelHome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ToolStripMenuItem submenuCategoria;
        private System.Windows.Forms.ToolStripMenuItem submenuProducto;
        private FontAwesome.Sharp.IconMenuItem submenuRegistrarVenta;
        private FontAwesome.Sharp.IconMenuItem submenuDetalleVenta;
        private FontAwesome.Sharp.IconMenuItem submenuRegistrarCompra;
        private FontAwesome.Sharp.IconMenuItem submenuDetalleCompra;
    }
}

