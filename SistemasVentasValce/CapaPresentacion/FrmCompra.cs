using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmCompra : Form
    {
        private Usuario _usuario;
        public FrmCompra(Usuario usuario = null)
        {
            _usuario = usuario;
            InitializeComponent();
        }

        private void FrmCompra_Load(object sender, EventArgs e)
        {   
            //Llenar ComboBox
            cbxTipoDoc.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cbxTipoDoc.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
            cbxTipoDoc.DisplayMember = "Texto";
            cbxTipoDoc.ValueMember = "Valor";
            cbxTipoDoc.SelectedIndex = 0;

            //Poner fecha actual en textbox
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            //Abrir Modal
            using (var modal = new mdProveedor())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdProveedor.Text = modal._proveedor.idProveedor.ToString();
                    txtCedulaProveedor.Text = modal._proveedor.cedula;
                    txtRazonSocialProveedor.Text = modal._proveedor.razonSocial;
                }
                else
                {
                    txtCedulaProveedor.Select();
                }
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            //Abrir Modal
            using (var modal = new mdProducto())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdProducto.Text = modal._producto.idProducto.ToString();
                    txtCodigoProducto.Text = modal._producto.codigo;
                    txtNombreProducto.Text = modal._producto.nombreProducto;
                    txtPrecioCompra.Select();
                }
                else
                {
                    txtCodigoProducto.Select();
                }
            }
        }

        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Producto producto = 
                    new NegocioProducto()
                        .Listar()
                        .Where(p => p.codigo == txtCodigoProducto.Text && 
                                    p.estado == true)
                        .FirstOrDefault();

                if (producto != null)
                {
                    txtCodigoProducto.BackColor = System.Drawing.Color.Honeydew;
                    txtNombreProducto.Text = producto.nombreProducto;
                    txtPrecioCompra.Select();
                }
                else
                {
                    txtCodigoProducto.BackColor = System.Drawing.Color.MistyRose;
                    txtNombreProducto.Text = "";
                }
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            decimal precioCompra = 0;
            decimal precioVenta = 0;
            bool productoExiste = false;

            if (int.Parse(txtIdProducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", 
                                "Mensaje", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(txtPrecioCompra.Text, out precioCompra))
            {
                MessageBox.Show("Precio Compra - Formato moneda incorrecto",
                                "Mensaje",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                txtPrecioCompra.Select();
                return;
            }
            if (!decimal.TryParse(txtPrecioVenta.Text, out precioVenta))
            {
                MessageBox.Show("Precio Compra - Formato moneda incorrecto",
                                "Mensaje",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                txtPrecioVenta.Select();
                return;
            }

            foreach (DataGridViewRow fila in dgvData.Rows)
            {
                if (fila.Cells["dgvIdProducto"].Value.ToString() == txtIdProducto.Text)
                {
                    productoExiste = true;
                    break;
                }
            }   

            if (!productoExiste)
            {
                dgvData.Rows.Add(new object[]
                {
                    txtIdProducto.Text,
                    txtNombreProducto.Text,
                    precioCompra.ToString("0.00"),
                    precioVenta.ToString("0.00"),
                    numericCantidad.Value.ToString(),
                    (numericCantidad.Value * precioCompra).ToString("0.00")
                });
                CalcularTotal();
                LimpiarProducto();
                txtCodigoProducto.Select();
            }

        }

        private void LimpiarProducto()
        {
            txtIdProducto.Text = "0";
            txtCodigoProducto.Text = "";
            txtCodigoProducto.BackColor = System.Drawing.Color.White;
            txtNombreProducto.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            numericCantidad.Value = 1;
        }

        private void CalcularTotal()
        {
            decimal total = 0;

            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    total += Convert.ToDecimal(row.Cells["dgvSubtotal"].Value.ToString());
                }
                txtTotalPagar.Text = total.ToString("0.00");
            }
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 6)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var width = Properties.Resources.delete25.Width;
                var height = Properties.Resources.delete25.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - width) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - height) / 2;

                e.Graphics.DrawImage(Properties.Resources.delete25, new Rectangle(x, y, width, height));
                e.Handled = true;
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    dgvData.Rows.RemoveAt(indice);
                    CalcularTotal();
                }
            }
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPrecioCompra.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == "." )
                    {
                        e.Handled = false;  
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
            
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtIdProveedor.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor",
                                "Mensaje",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            if (dgvData.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar productos en la compra",
                                "Mensaje",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dtDetalleCompra = new DataTable();

            dtDetalleCompra.Columns.Add("idProducto", typeof(int));
            dtDetalleCompra.Columns.Add("precioCompra", typeof(decimal));
            dtDetalleCompra.Columns.Add("precioVenta", typeof(decimal));
            dtDetalleCompra.Columns.Add("cantidad", typeof(int));
            dtDetalleCompra.Columns.Add("montoTotal", typeof(decimal));

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                dtDetalleCompra.Rows.Add(
                    new object[]
                    {
                        Convert.ToInt32(row.Cells["dgvIdProducto"].Value.ToString()),
                        row.Cells["dgvPrecioCompra"].Value.ToString(),
                        row.Cells["dgvPrecioVenta"].Value.ToString(),
                        row.Cells["dgvCantidad"].Value.ToString(),
                        row.Cells["dgvSubtotal"].Value.ToString(),
                    });
            }

            int idCorrelativo = new NegocioCompra().ObtenerCorrelativo();
            string numeroDocumento = string.Format("{0:00000}", idCorrelativo);

            Compra compra = new Compra()
            {
                usuario = new Usuario() { idUsuario = _usuario.idUsuario },
                proveedor = new Proveedor() { idProveedor = Convert.ToInt32(txtIdProveedor.Text) },
                tipoDocumento = ((OpcionCombo)cbxTipoDoc.SelectedItem).Texto,
                numeroDocumento = numeroDocumento,
                montoTotal = Convert.ToDecimal(txtTotalPagar.Text)
            };

            string mensaje = string.Empty;
            bool respuesta = new NegocioCompra().Registrar(compra, dtDetalleCompra, out mensaje);

            if (respuesta)
            {
                var result = 
                    MessageBox.Show("Numero de compra generada:\n" + numeroDocumento + "\n\n Desea copiar al portapapeples?",
                                    "Mensaje",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                    Clipboard.SetText(numeroDocumento);

                txtIdProveedor .Text = "";
                txtRazonSocialProveedor.Text = "";
                txtCedulaProveedor.Text = "";
                dgvData.Rows.Clear();
                CalcularTotal();

            }
            else
            {
                MessageBox.Show(mensaje,
                                "Mensaje",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }

        }
    }
}