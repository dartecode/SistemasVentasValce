using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            //Llenar ComboBoxEstado
            cbxEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cbxEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cbxEstado.DisplayMember = "Texto";
            cbxEstado.ValueMember = "Valor";
            cbxEstado.SelectedIndex = 0;

            //Llenar ComboBoxBusqueda con las columnas del DataGridView
            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cbxBusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbxBusqueda.DisplayMember = "Texto";
            cbxBusqueda.ValueMember = "Valor";
            cbxBusqueda.SelectedIndex = 0;

            //Mostrar Cliente en el DataGridView con datos de la DB
            List<Cliente> listaCliente = new NegocioCliente().Listar();

            foreach (Cliente item in listaCliente)
            {
                dgvData
                .Rows
                .Add(new object[] { "",
                                    item.idCliente,
                                    item.cedula,
                                    item.nombreCompleto,
                                    item.email,
                                    item.telefono,
                                    item.estado == true ? 1 : 0,
                                    item.estado == true ? "Activo" : "No Activo",
                });
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String mensaje = string.Empty;
            //Crear un objeto de clase Usuario para almacenar datos que queremos insertar a base de datos
            Cliente cliente = new Cliente()
            {
                idCliente = Convert.ToInt32(txtId.Text),
                cedula = txtCedula.Text,
                nombreCompleto = txtNombreCompleto.Text,
                email = txtEmail.Text,
                telefono = txtTelefono.Text,
                estado = Convert.ToInt32(((OpcionCombo)cbxEstado.SelectedItem).Valor) == 1 ? true : false
            };

            //Validacion para ver si Guarda o Edita en la base de datos
            if (cliente.idCliente == 0)
            {
                //Metodo Agregar
                int idClienteGenerado = new NegocioCliente().RegistrarCliente(cliente, out mensaje);
                if (idClienteGenerado != 0)
                {
                    //Agregar Datos al DataGridView
                    dgvData
                    .Rows
                    .Add(new object[] { "",
                                    idClienteGenerado,
                                    txtCedula.Text,
                                    txtNombreCompleto.Text,
                                    txtEmail.Text,
                                    txtTelefono.Text,
                                    ((OpcionCombo)cbxEstado.SelectedItem).Valor.ToString(),
                                    ((OpcionCombo)cbxEstado.SelectedItem).Texto.ToString(),

                    });
                    LimpiarTextBox();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            //Metodo Editar
            {
                bool resultado = new NegocioCliente().EditarCliente(cliente, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["dgvIdCliente"].Value = txtId.Text;
                    row.Cells["dgvCedula"].Value = txtCedula.Text;
                    row.Cells["dgvNombreCompleto"].Value = txtNombreCompleto.Text;
                    row.Cells["dgvEmail"].Value = txtEmail.Text;
                    row.Cells["dgvTelefono"].Value = txtTelefono.Text;
                    row.Cells["dgvEstadoValor"].Value = ((OpcionCombo)cbxEstado.SelectedItem).Valor.ToString();
                    row.Cells["dgvEstado"].Value = ((OpcionCombo)cbxEstado.SelectedItem).Texto.ToString();

                    LimpiarTextBox();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }

        private void LimpiarTextBox()
        {
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtCedula.Text = "";
            txtNombreCompleto.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            cbxEstado.SelectedIndex = 0;

            txtCedula.Select();
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

                e.Graphics.DrawImage(Properties.Resources.check20, new Rectangle(x, y, width, height));
                e.Handled = true;
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Seleccionar usuario con el boton
            if (dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                //Pregunta si hay un usuario seleccionado y pone los datos del usuario en formulario
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvData.Rows[indice].Cells["dgvIdCliente"].Value.ToString();
                    txtCedula.Text = dgvData.Rows[indice].Cells["dgvCedula"].Value.ToString();
                    txtNombreCompleto.Text = dgvData.Rows[indice].Cells["dgvNombreCompleto"].Value.ToString();
                    txtEmail.Text = dgvData.Rows[indice].Cells["dgvEmail"].Value.ToString();
                    txtTelefono.Text = dgvData.Rows[indice].Cells["dgvTelefono"].Value.ToString();

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Eliminar si hay elemento seleccionado
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                //MessageBox para confirmar si desea eliminar
                if (MessageBox.Show("Desea eliminar el cliente seleccionado?",
                                    "Mensaje",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Cliente cliente = new Cliente()
                    {
                        idCliente = Convert.ToInt32(txtId.Text)
                    };

                    bool respuesta = new NegocioCliente().EliminarCliente(cliente, out mensaje);
                    //Eliminar de DataGridView
                    if (respuesta)
                    {
                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        LimpiarTextBox();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbxBusqueda.SelectedItem).Valor.ToString();
            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row
                        .Cells[columnaFiltro].Value.ToString().Trim().ToUpper()
                            .Contains(txtBuscar.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = string.Empty;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarTextBox();
        }
    }
}
