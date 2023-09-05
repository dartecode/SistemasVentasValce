using CapaPresentacion.Utilidades;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using System.Collections.Generic;

namespace CapaPresentacion
{
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void FrmUsuario_Load(object sender, System.EventArgs e)
        {
            //Llenar ComboBoxEstado
            cbxEstado.Items.Add(new OpcionCombo() { Valor = 1 , Texto = "Activo" } );
            cbxEstado.Items.Add(new OpcionCombo() { Valor = 0 , Texto = "No Activo" } );
            cbxEstado.DisplayMember = "Texto";
            cbxEstado.ValueMember = "Valor";
            cbxEstado.SelectedIndex = 0;

            //Llenar ComboBoxRol mediante consulta de base de datos
            List<Rol> listaRol = new NegocioRol().Listar();

            foreach (Rol item in listaRol)
            {
                cbxRol.Items.Add(new OpcionCombo() { Valor = item.idRol , Texto = item.descripcion });
            }
            cbxRol.DisplayMember = "Texto";
            cbxRol.ValueMember = "Valor";
            cbxRol.SelectedIndex = 0;

            //Llenar ComboBoxBusqueda con las columnas del DataGridView
            foreach (DataGridViewColumn columna  in dgvData.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cbxBusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbxBusqueda.DisplayMember = "Texto";
            cbxBusqueda.ValueMember = "Valor";
            cbxBusqueda.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            dgvData
                .Rows
                .Add(new object[] { "", 
                                    txtId.Text, 
                                    txtCedula.Text, 
                                    txtNombreCompleto.Text,
                                    txtEmail.Text,
                                    txtClave.Text, 
                                    ((OpcionCombo)cbxRol.SelectedItem).Valor.ToString(),
                                    ((OpcionCombo)cbxRol.SelectedItem).Texto.ToString(),
                                    ((OpcionCombo)cbxEstado.SelectedItem).Valor.ToString(),
                                    ((OpcionCombo)cbxEstado.SelectedItem).Texto.ToString(),
                });
            LimpiarTextBox();
        }

        private void LimpiarTextBox ()
        {
            txtId.Text = "";
            txtCedula.Text = "";
            txtNombreCompleto.Text = "";
            txtEmail.Text = "";
            txtClave.Text = "";
            txtConfirmarClave.Text = "";
            cbxEstado.SelectedIndex = 0;
            cbxRol.SelectedIndex = 0;
        }
    }
}
