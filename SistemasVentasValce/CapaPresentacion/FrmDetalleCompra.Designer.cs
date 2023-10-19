namespace CapaPresentacion
{
    partial class FrmDetalleCompra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTipoDocumento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFechaCompra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.txtRazonSocialProv = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumeroDocProveedor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.dgvProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalPagar = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSavePdf = new FontAwesome.Sharp.IconButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(71, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(831, 507);
            this.label10.TabIndex = 22;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(105, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 29);
            this.label1.TabIndex = 23;
            this.label1.Text = "Detalle Compra";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(491, 35);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(111, 22);
            this.txtBuscar.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(326, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 16);
            this.label11.TabIndex = 27;
            this.label11.Text = "Numero Documento:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.LightGray;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.Color.Black;
            this.btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnLimpiar.IconColor = System.Drawing.Color.Black;
            this.btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar.IconSize = 18;
            this.btnLimpiar.Location = new System.Drawing.Point(739, 30);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(109, 29);
            this.btnLimpiar.TabIndex = 30;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Searchengin;
            this.btnBuscar.IconColor = System.Drawing.Color.Black;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 20;
            this.btnBuscar.Location = new System.Drawing.Point(620, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(109, 29);
            this.btnBuscar.TabIndex = 29;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTipoDocumento);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFechaCompra);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(109, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(739, 76);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informacion de la compra";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(484, 42);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(200, 23);
            this.txtUsuario.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(481, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Usuario";
            // 
            // txtTipoDocumento
            // 
            this.txtTipoDocumento.Enabled = false;
            this.txtTipoDocumento.Location = new System.Drawing.Point(216, 42);
            this.txtTipoDocumento.Name = "txtTipoDocumento";
            this.txtTipoDocumento.Size = new System.Drawing.Size(205, 23);
            this.txtTipoDocumento.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo Documento";
            // 
            // txtFechaCompra
            // 
            this.txtFechaCompra.Enabled = false;
            this.txtFechaCompra.Location = new System.Drawing.Point(6, 42);
            this.txtFechaCompra.Name = "txtFechaCompra";
            this.txtFechaCompra.Size = new System.Drawing.Size(149, 23);
            this.txtFechaCompra.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.txtNumeroDocumento);
            this.groupBox2.Controls.Add(this.txtRazonSocialProv);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtNumeroDocProveedor);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(109, 182);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(739, 76);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informacion de Proveedor";
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Enabled = false;
            this.txtNumeroDocumento.Location = new System.Drawing.Point(600, 42);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(75, 23);
            this.txtNumeroDocumento.TabIndex = 5;
            // 
            // txtRazonSocialProv
            // 
            this.txtRazonSocialProv.Enabled = false;
            this.txtRazonSocialProv.Location = new System.Drawing.Point(232, 42);
            this.txtRazonSocialProv.Name = "txtRazonSocialProv";
            this.txtRazonSocialProv.Size = new System.Drawing.Size(205, 23);
            this.txtRazonSocialProv.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(229, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "RazonSocial";
            // 
            // txtNumeroDocProveedor
            // 
            this.txtNumeroDocProveedor.Enabled = false;
            this.txtNumeroDocProveedor.Location = new System.Drawing.Point(6, 42);
            this.txtNumeroDocProveedor.Name = "txtNumeroDocProveedor";
            this.txtNumeroDocProveedor.Size = new System.Drawing.Size(149, 23);
            this.txtNumeroDocProveedor.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Numero Documento";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvProducto,
            this.dgvPrecioCompra,
            this.dgvCantidad,
            this.dgvSubtotal});
            this.dgvData.Location = new System.Drawing.Point(109, 264);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvData.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.RowTemplate.Height = 28;
            this.dgvData.Size = new System.Drawing.Size(739, 213);
            this.dgvData.TabIndex = 49;
            // 
            // dgvProducto
            // 
            this.dgvProducto.HeaderText = "Producto";
            this.dgvProducto.MinimumWidth = 6;
            this.dgvProducto.Name = "dgvProducto";
            this.dgvProducto.ReadOnly = true;
            this.dgvProducto.Width = 160;
            // 
            // dgvPrecioCompra
            // 
            this.dgvPrecioCompra.HeaderText = "Precio Compra";
            this.dgvPrecioCompra.MinimumWidth = 6;
            this.dgvPrecioCompra.Name = "dgvPrecioCompra";
            this.dgvPrecioCompra.ReadOnly = true;
            this.dgvPrecioCompra.Width = 130;
            // 
            // dgvCantidad
            // 
            this.dgvCantidad.HeaderText = "Cantidad";
            this.dgvCantidad.MinimumWidth = 6;
            this.dgvCantidad.Name = "dgvCantidad";
            this.dgvCantidad.ReadOnly = true;
            this.dgvCantidad.Width = 150;
            // 
            // dgvSubtotal
            // 
            this.dgvSubtotal.HeaderText = "SubTotal";
            this.dgvSubtotal.MinimumWidth = 6;
            this.dgvSubtotal.Name = "dgvSubtotal";
            this.dgvSubtotal.ReadOnly = true;
            this.dgvSubtotal.Width = 130;
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.Enabled = false;
            this.txtTotalPagar.Location = new System.Drawing.Point(223, 490);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.Size = new System.Drawing.Size(71, 22);
            this.txtTotalPagar.TabIndex = 53;
            this.txtTotalPagar.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(107, 493);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 16);
            this.label12.TabIndex = 52;
            this.label12.Text = "Monto Total";
            // 
            // btnSavePdf
            // 
            this.btnSavePdf.BackColor = System.Drawing.Color.LightGray;
            this.btnSavePdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSavePdf.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSavePdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePdf.ForeColor = System.Drawing.Color.Black;
            this.btnSavePdf.IconChar = FontAwesome.Sharp.IconChar.Paperclip;
            this.btnSavePdf.IconColor = System.Drawing.Color.Black;
            this.btnSavePdf.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSavePdf.IconSize = 20;
            this.btnSavePdf.Location = new System.Drawing.Point(620, 483);
            this.btnSavePdf.Name = "btnSavePdf";
            this.btnSavePdf.Size = new System.Drawing.Size(228, 33);
            this.btnSavePdf.TabIndex = 54;
            this.btnSavePdf.Text = "Descargar en PDF";
            this.btnSavePdf.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSavePdf.UseVisualStyleBackColor = false;
            this.btnSavePdf.Click += new System.EventHandler(this.btnSavePdf_Click);
            // 
            // FrmDetalleCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 561);
            this.Controls.Add(this.btnSavePdf);
            this.Controls.Add(this.txtTotalPagar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Name = "FrmDetalleCompra";
            this.Text = "FrmDetalleCompra";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTipoDocumento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFechaCompra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.TextBox txtRazonSocialProv;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumeroDocProveedor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox txtTotalPagar;
        private System.Windows.Forms.Label label12;
        private FontAwesome.Sharp.IconButton btnSavePdf;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSubtotal;
    }
}