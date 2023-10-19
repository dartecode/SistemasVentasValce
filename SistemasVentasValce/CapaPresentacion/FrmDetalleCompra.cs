using CapaEntidad;
using CapaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.IO;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmDetalleCompra : Form
    {
        public FrmDetalleCompra()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Compra compra = new NegocioCompra().ObtenerCompra(txtBuscar.Text);

            if (compra.idCompra != 0)
            {
                txtNumeroDocumento.Text = compra.numeroDocumento;

                txtFechaCompra.Text = compra.fechaRegistro;
                txtTipoDocumento.Text = compra.tipoDocumento;
                txtUsuario.Text = compra.usuario.nombreCompleto;
                txtNumeroDocProveedor.Text = compra.proveedor.cedula;
                txtRazonSocialProv.Text = compra.proveedor.razonSocial;

                dgvData.Rows.Clear();

                foreach (DetalleCompra detalleCompra in compra.detalleCompra)
                {
                    dgvData.Rows.Add(new object[]
                    {
                        detalleCompra.producto.nombreProducto,
                        detalleCompra.precioCompra,
                        detalleCompra.cantidad,
                        detalleCompra.montoTotal
                    });
                }
                txtTotalPagar.Text = compra.montoTotal.ToString("0.00");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumeroDocumento.Text = "";

            txtFechaCompra.Text = "";
            txtTipoDocumento.Text = "";
            txtUsuario.Text = "";
            txtNumeroDocProveedor.Text = "";
            txtRazonSocialProv.Text = "";

            dgvData.Rows.Clear();
            txtTotalPagar.Text = "0.00";


        }

        private void btnSavePdf_Click(object sender, EventArgs e)
        {
            if (txtTipoDocumento.Text == "")
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string textoHtml = Properties.Resources.PlantillaCompra.ToString();

            Negocio datos = new CNegocio().ObtenerDatos();

            textoHtml = textoHtml.Replace("@nombrenegocio", datos.nombreNegocio.ToUpper());
            textoHtml = textoHtml.Replace("@docnegocio", datos.ruc.ToUpper());
            textoHtml = textoHtml.Replace("@direcnegocio", datos.direccion.ToUpper());

            textoHtml = textoHtml.Replace("@tipodocumento", txtTipoDocumento.Text.ToUpper());
            textoHtml = textoHtml.Replace("@numerodocumento", txtNumeroDocumento.Text.ToUpper());

            textoHtml = textoHtml.Replace("@docproveedor", txtNumeroDocProveedor.Text.ToUpper());
            textoHtml = textoHtml.Replace("@nombreproveedor", txtRazonSocialProv.Text.ToUpper());
            textoHtml = textoHtml.Replace("@fecharegistro", txtFechaCompra.Text.ToUpper());
            textoHtml = textoHtml.Replace("@usuarioregistro", txtUsuario.Text.ToUpper());

            string filas = string.Empty;

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["dgvProducto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["dgvPrecioCompra"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["dgvCantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["dgvSubtotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            textoHtml = textoHtml.Replace("@filas", filas);
            textoHtml = textoHtml.Replace("@montototal", txtTotalPagar.Text);


            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = string.Format("Compra_{0}.pdf", txtNumeroDocumento.Text);
            saveFile.Filter = "Pdf Files|*.pdf";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(saveFile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                    pdfDoc.Open();

                    bool obtenido = true;
                    byte[] byteImage = new CNegocio().ObtenerLogo(out obtenido);

                    if (obtenido)
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                        img.ScaleToFit(60,60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                        pdfDoc.Add(img);
                    }

                    using (StringReader sr = new StringReader(textoHtml)) 
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();

                    MessageBox.Show("Documento Generado", 
                                    "Mensaje", 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information);

                }
            }
        }

    }
}