using CapaEntidad;
using CapaNegocio;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Home : Form
    {
        private static Usuario usuarioActual;
        private static IconMenuItem menuActivo = null;
        private static Form formularioActivo = null;

        public Home(Usuario usuario)
        {
            usuarioActual = usuario;
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            List<Permiso> listaPermiso = new NegocioPermiso().Listar(usuarioActual.idUsuario);

            foreach (IconMenuItem iconmenu in menu.Items)
            {
                bool permisoConcedido = listaPermiso.Any(m => m.nombreMenu == iconmenu.Name);
                if (permisoConcedido != true)
                {
                    iconmenu.Visible = false;
                }
            }

            //Mostrar nombre de usuario en label
            lblUsuario.Text = usuarioActual.nombreCompleto;
        }

        //Configurar panelHome para que se ejecuten los forms dentro de este
        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (menuActivo != null)
            {
                menuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            menuActivo = menu;

            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            formularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.SteelBlue;

            //Agregar formulario al panel
            panelHome.Controls.Add(formulario);
            formulario.Show();
        }

        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FrmUsuario());
        }

        private void submenuCategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMantenedor, new FrmCategoria());
        }

        private void submenuProducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMantenedor, new FrmProducto());
        }

        private void submenuRegistrarVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuVentas, new FrmVenta());
        }

        private void submenuDetalleVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuVentas, new FrmDetalleVenta());
        }

        private void submenuRegistrarCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuCompras, new FrmCompra());
        }

        private void submenuDetalleCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuCompras, new FrmDetalleCompra());
        }

        private void menuClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FrmCliente());
        }

        private void menuProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FrmProveedor());
        }

        private void menuReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FrmReporte());
        }
    }
}