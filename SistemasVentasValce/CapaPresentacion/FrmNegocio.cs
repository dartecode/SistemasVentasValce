using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmNegocio : Form
    {
        public FrmNegocio()
        {
            InitializeComponent();
        }

        public Image ByteToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);

            return image;
        }

        private void FrmNegocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] byteimage = new CNegocio().ObtenerLogo(out obtenido);

            if (obtenido)
                pictureLogo.Image = ByteToImage(byteimage);

            Negocio datos = new CNegocio().ObtenerDatos();

            txtNombre.Text = datos.nombreNegocio.ToString();
            txtDirecion.Text = datos.direccion.ToString();
            txtRuc.Text = datos.ruc.ToString();

        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            string mensaje = String.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "Files|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] byteImage = File.ReadAllBytes(openFileDialog.FileName);
                bool respuesta = new CNegocio().ActualizarLogo(byteImage, out mensaje);

                if (respuesta)
                    pictureLogo.Image = ByteToImage(byteImage);
                else
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }

        }
    }
}