namespace CapaPresentacion
{
    partial class FrmCompra
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxTipoDoc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRazonSocialProveedor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCedulaProveedor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtIdProducto = new System.Windows.Forms.TextBox();
            this.numericCantidad = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrecioCompra = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodigoProducto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.dgvIdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTotalPagar = new System.Windows.Forms.TextBox();
            this.txtIdProveedor = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new FontAwesome.Sharp.IconButton();
            this.btnAgregarProducto = new FontAwesome.Sharp.IconButton();
            this.btnBuscarProducto = new FontAwesome.Sharp.IconButton();
            this.btnBuscarProveedor = new FontAwesome.Sharp.IconButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(2, -8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(1010, 545);
            this.label10.TabIndex = 21;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 29);
            this.label1.TabIndex = 22;
            this.label1.Text = "Registrar Compra";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.cbxTipoDoc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFecha);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(47, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 76);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informacion de la compra";
            // 
            // cbxTipoDoc
            // 
            this.cbxTipoDoc.FormattingEnabled = true;
            this.cbxTipoDoc.Location = new System.Drawing.Point(232, 39);
            this.cbxTipoDoc.Name = "cbxTipoDoc";
            this.cbxTipoDoc.Size = new System.Drawing.Size(184, 24);
            this.cbxTipoDoc.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo Documento";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(6, 39);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(184, 23);
            this.txtFecha.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.txtRazonSocialProveedor);
            this.groupBox2.Controls.Add(this.btnBuscarProveedor);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtCedulaProveedor);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(516, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 76);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informacion de Proveedor";
            // 
            // txtRazonSocialProveedor
            // 
            this.txtRazonSocialProveedor.Location = new System.Drawing.Point(247, 40);
            this.txtRazonSocialProveedor.Name = "txtRazonSocialProveedor";
            this.txtRazonSocialProveedor.Size = new System.Drawing.Size(154, 23);
            this.txtRazonSocialProveedor.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Razon Social";
            // 
            // txtCedulaProveedor
            // 
            this.txtCedulaProveedor.Location = new System.Drawing.Point(6, 39);
            this.txtCedulaProveedor.Name = "txtCedulaProveedor";
            this.txtCedulaProveedor.Size = new System.Drawing.Size(154, 23);
            this.txtCedulaProveedor.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Numero Cedula";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.txtIdProducto);
            this.groupBox3.Controls.Add(this.numericCantidad);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtPrecioVenta);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtPrecioCompra);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtNombreProducto);
            this.groupBox3.Controls.Add(this.btnBuscarProducto);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtCodigoProducto);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(47, 155);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(903, 79);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Informacion de producto";
            // 
            // txtIdProducto
            // 
            this.txtIdProducto.Enabled = false;
            this.txtIdProducto.Location = new System.Drawing.Point(839, 17);
            this.txtIdProducto.Name = "txtIdProducto";
            this.txtIdProducto.Size = new System.Drawing.Size(42, 23);
            this.txtIdProducto.TabIndex = 36;
            this.txtIdProducto.Text = "0";
            // 
            // numericCantidad
            // 
            this.numericCantidad.Location = new System.Drawing.Point(716, 43);
            this.numericCantidad.Name = "numericCantidad";
            this.numericCantidad.Size = new System.Drawing.Size(75, 23);
            this.numericCantidad.TabIndex = 35;
            this.numericCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(713, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 17);
            this.label11.TabIndex = 34;
            this.label11.Text = "Cantidad";
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(584, 43);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(98, 23);
            this.txtPrecioVenta.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(581, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 17);
            this.label9.TabIndex = 32;
            this.label9.Text = "Precio Venta";
            // 
            // txtPrecioCompra
            // 
            this.txtPrecioCompra.Location = new System.Drawing.Point(469, 43);
            this.txtPrecioCompra.Name = "txtPrecioCompra";
            this.txtPrecioCompra.Size = new System.Drawing.Size(98, 23);
            this.txtPrecioCompra.TabIndex = 31;
            this.txtPrecioCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioCompra_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(466, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 17);
            this.label8.TabIndex = 30;
            this.label8.Text = "Precio Compra";
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Location = new System.Drawing.Point(262, 40);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(172, 23);
            this.txtNombreProducto.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(259, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Producto";
            // 
            // txtCodigoProducto
            // 
            this.txtCodigoProducto.Location = new System.Drawing.Point(6, 40);
            this.txtCodigoProducto.Name = "txtCodigoProducto";
            this.txtCodigoProducto.Size = new System.Drawing.Size(184, 23);
            this.txtCodigoProducto.TabIndex = 1;
            this.txtCodigoProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProducto_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Cod Producto:";
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
            this.dgvIdProducto,
            this.dgvProducto,
            this.dgvPrecioCompra,
            this.dgvPrecioVenta,
            this.dgvCantidad,
            this.dgvSubtotal,
            this.btnEliminar});
            this.dgvData.Location = new System.Drawing.Point(47, 254);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvData.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.RowTemplate.Height = 28;
            this.dgvData.Size = new System.Drawing.Size(709, 259);
            this.dgvData.TabIndex = 48;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            this.dgvData.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvData_CellPainting);
            // 
            // dgvIdProducto
            // 
            this.dgvIdProducto.HeaderText = "ID Producto";
            this.dgvIdProducto.MinimumWidth = 6;
            this.dgvIdProducto.Name = "dgvIdProducto";
            this.dgvIdProducto.ReadOnly = true;
            this.dgvIdProducto.Visible = false;
            this.dgvIdProducto.Width = 125;
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
            // dgvPrecioVenta
            // 
            this.dgvPrecioVenta.HeaderText = "Precio Venta";
            this.dgvPrecioVenta.MinimumWidth = 6;
            this.dgvPrecioVenta.Name = "dgvPrecioVenta";
            this.dgvPrecioVenta.ReadOnly = true;
            this.dgvPrecioVenta.Visible = false;
            this.dgvPrecioVenta.Width = 125;
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
            // btnEliminar
            // 
            this.btnEliminar.HeaderText = "";
            this.btnEliminar.MinimumWidth = 10;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ReadOnly = true;
            this.btnEliminar.Width = 50;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(808, 395);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 16);
            this.label12.TabIndex = 50;
            this.label12.Text = "Total a Pagar";
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.Location = new System.Drawing.Point(811, 419);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.Size = new System.Drawing.Size(139, 22);
            this.txtTotalPagar.TabIndex = 51;
            this.txtTotalPagar.Text = "0";
            // 
            // txtIdProveedor
            // 
            this.txtIdProveedor.Enabled = false;
            this.txtIdProveedor.Location = new System.Drawing.Point(875, 55);
            this.txtIdProveedor.Name = "txtIdProveedor";
            this.txtIdProveedor.Size = new System.Drawing.Size(42, 22);
            this.txtIdProveedor.TabIndex = 37;
            this.txtIdProveedor.Text = "0";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.IconChar = FontAwesome.Sharp.IconChar.Tag;
            this.btnRegistrar.IconColor = System.Drawing.Color.SteelBlue;
            this.btnRegistrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRegistrar.Location = new System.Drawing.Point(811, 452);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(139, 61);
            this.btnRegistrar.TabIndex = 52;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.IconChar = FontAwesome.Sharp.IconChar.Add;
            this.btnAgregarProducto.IconColor = System.Drawing.Color.ForestGreen;
            this.btnAgregarProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgregarProducto.Location = new System.Drawing.Point(811, 254);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(139, 97);
            this.btnAgregarProducto.TabIndex = 49;
            this.btnAgregarProducto.Text = "Agregar";
            this.btnAgregarProducto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackColor = System.Drawing.Color.White;
            this.btnBuscarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarProducto.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarProducto.ForeColor = System.Drawing.Color.White;
            this.btnBuscarProducto.IconChar = FontAwesome.Sharp.IconChar.Searchengin;
            this.btnBuscarProducto.IconColor = System.Drawing.Color.Black;
            this.btnBuscarProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarProducto.IconSize = 20;
            this.btnBuscarProducto.Location = new System.Drawing.Point(210, 35);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(29, 21);
            this.btnBuscarProducto.TabIndex = 28;
            this.btnBuscarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarProducto.UseVisualStyleBackColor = false;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // btnBuscarProveedor
            // 
            this.btnBuscarProveedor.BackColor = System.Drawing.Color.White;
            this.btnBuscarProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarProveedor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarProveedor.ForeColor = System.Drawing.Color.White;
            this.btnBuscarProveedor.IconChar = FontAwesome.Sharp.IconChar.Searchengin;
            this.btnBuscarProveedor.IconColor = System.Drawing.Color.Black;
            this.btnBuscarProveedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarProveedor.IconSize = 20;
            this.btnBuscarProveedor.Location = new System.Drawing.Point(184, 36);
            this.btnBuscarProveedor.Name = "btnBuscarProveedor";
            this.btnBuscarProveedor.Size = new System.Drawing.Size(29, 29);
            this.btnBuscarProveedor.TabIndex = 26;
            this.btnBuscarProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarProveedor.UseVisualStyleBackColor = false;
            this.btnBuscarProveedor.Click += new System.EventHandler(this.btnBuscarProveedor_Click);
            // 
            // FrmCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 553);
            this.Controls.Add(this.txtIdProveedor);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtTotalPagar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Name = "FrmCompra";
            this.Text = "FrmCompra";
            this.Load += new System.EventHandler(this.FrmCompra_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxTipoDoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCedulaProveedor;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconButton btnBuscarProveedor;
        private System.Windows.Forms.TextBox txtRazonSocialProveedor;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodigoProducto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericCantidad;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPrecioCompra;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private FontAwesome.Sharp.IconButton btnBuscarProducto;
        private System.Windows.Forms.DataGridView dgvData;
        private FontAwesome.Sharp.IconButton btnAgregarProducto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTotalPagar;
        private FontAwesome.Sharp.IconButton btnRegistrar;
        private System.Windows.Forms.TextBox txtIdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvIdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSubtotal;
        private System.Windows.Forms.DataGridViewButtonColumn btnEliminar;
        private System.Windows.Forms.TextBox txtIdProveedor;
    }
}