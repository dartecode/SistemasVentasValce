using CapaPresentacion.Utilidades;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using System.Collections.Generic;
using System.Drawing;
using System;

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

            //Mostrar Usuarios en el DataGridView con datos de la DB
            List<Usuario> listaUsuario = new NegocioUsuario().Listar();

            foreach (Usuario item in listaUsuario)
            {
                dgvData
                .Rows
                .Add(new object[] { "",
                                    item.idUsuario,
                                    item.cedula,
                                    item.nombreCompleto,
                                    item.email,
                                    item.clave,
                                    item.rol.idRol,
                                    item.rol.descripcion,
                                    item.estado == true ? 1 : 0,
                                    item.estado == true ? "Activo" : "No Activo",
                });
            }
        }

        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            String mensaje = string.Empty;
            //Crear un objeto de clase Usuario para almacenar datos que queremos insertar a base de datos
            Usuario usuario = new Usuario()
            {
                idUsuario = Convert.ToInt32(txtId.Text),
                cedula = txtCedula.Text,
                nombreCompleto = txtNombreCompleto.Text,
                email = txtEmail.Text,
                clave = txtClave.Text,
                rol = new Rol() { idRol = Convert.ToInt32(((OpcionCombo)cbxRol.SelectedItem).Valor)  },
                estado = Convert.ToInt32(((OpcionCombo)cbxEstado.SelectedItem).Valor) == 1 ? true : false
            };

            int idUsuarioGenerado = new NegocioUsuario().RegistrarUsuario(usuario, out mensaje);

            if (idUsuarioGenerado != 0)
            {
                //Agregar Datos al DataGridView
                dgvData
                .Rows
                .Add(new object[] { "",
                                    idUsuarioGenerado,
                                    txtCedula.Text,
                                    txtNombreCompleto.Text,
                                    txtEmail.Text,
                                    txtClave.Text,
                                    ((OpcionCombo)cbxRol.SelectedItem).Valor.ToString(),
                                    ((OpcionCombo)cbxRol.SelectedItem).Texto.ToString(),
                                    ((OpcionCombo)cbxEstado.SelectedItem).Valor.ToString(),
                                    ((OpcionCombo)cbxEstado.SelectedItem).Texto.ToString(),
                });
            }
            else
            {
                MessageBox.Show(mensaje);
            }
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

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var width = Properties.Resources.check20.Width;
                var height = Properties.Resources.check20.Width;
                var x = e.CellBounds.Left + (e.CellBounds.Width - width) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - height) / 2;

                e.Graphics.DrawImage(Properties.Resources.check20, new Rectangle(x,y,width,height));
                e.Handled = true;
            }
        }

        //Seleccionar elementos del DataGridView y enviar datos al formulario
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Seleccionar usuario con el boton
            if (dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                //Pregunta si hay un usuario seleccionado y pone los datos del usuario en formulario
                if (indice >= 0)
                {
                    txtId.Text = dgvData.Rows[indice].Cells["dgvIdUsuario"].Value.ToString();
                    txtCedula.Text = dgvData.Rows[indice].Cells["dgvCedula"].Value.ToString();
                    txtNombreCompleto.Text = dgvData.Rows[indice].Cells["dgvNombreCompleto"].Value.ToString();
                    txtEmail.Text = dgvData.Rows[indice].Cells["dgvEmail"].Value.ToString();
                    txtClave.Text = dgvData.Rows[indice].Cells["dgvClave"].Value.ToString();
                    txtConfirmarClave.Text = dgvData.Rows[indice].Cells["dgvClave"].Value.ToString();

                    //Para poner el valor del usuario en el comboboxRol del formulario
                    foreach (OpcionCombo opcion in cbxRol.Items)
                    {
                        if (Convert.ToInt32(opcion.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["dgvIdRol"].Value))
                        {
                            int indiceCombo = cbxRol.Items.IndexOf(opcion);
                            cbxRol.SelectedIndex = indiceCombo;
                            break;
                        }
                    }

                    //Para poner el valor del usuario en el comboboxEstado del formulario
                    foreach (OpcionCombo opcion in cbxEstado.Items)
                    {
                        if (Convert.ToInt32(opcion.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["dgvEstadoValor"].Value))
                        {
                            int indiceCombo = cbxEstado.Items.IndexOf(opcion);
                            cbxEstado.SelectedIndex = indiceCombo;
                            break;
                        }
                    }

                }
            }
        }
    }
}