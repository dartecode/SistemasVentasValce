using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = 
                new NegocioUsuario()
                .Listar()
                .Where(x => x.cedula ==  txtCedula.Text && 
                            x.clave == txtClave.Text)
                .FirstOrDefault();

            if (usuario != null)
            {
                Home form = new Home();
                form.Show();
                this.Hide();

                form.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("No se encontro el usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            //Limpiar textbox
            txtCedula.Text = "";
            txtClave.Text = "";

            this.Show();
        }

    }
}
