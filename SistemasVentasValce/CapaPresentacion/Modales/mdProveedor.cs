using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    public partial class mdProveedor : Form
    {
        public Proveedor _proveedor { get; set; }

        public mdProveedor()
        {
            InitializeComponent();
        }

        private void mdProveedor_Load(object sender, EventArgs e)
        {
            //Llenar ComboBoxBusqueda con las columnas del DataGridView
            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                if (columna.Visible == true)
                {
                    cbxBusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbxBusqueda.DisplayMember = "Texto";
            cbxBusqueda.ValueMember = "Valor";
            cbxBusqueda.SelectedIndex = 0;

            //Mostrar Cliente en el DataGridView con datos de la DB
            List<Proveedor> listaProveedor = new NegocioProveedor().Listar();

            foreach (Proveedor item in listaProveedor)
            {
                dgvData
                .Rows
                .Add(new object[] { item.idProveedor,
                                    item.cedula,
                                    item.razonSocial,
                });
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Seleccionar Fila y Columna
            int iRow = e.RowIndex;
            int iCol = e.ColumnIndex;

            if(iRow >= 0 && iCol > 0 )
            {
                //Enviar Objeto desde Modal al Formulario
                _proveedor = new Proveedor()
                {
                    idProveedor = Convert.ToInt32(dgvData.Rows[iRow].Cells["dgvIdProveedor"].Value.ToString()),
                    cedula = dgvData.Rows[iRow].Cells["dgvCedula"].Value.ToString(),
                    razonSocial = dgvData.Rows[iRow].Cells["dgvRazonSocial"].Value.ToString()
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
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
    }
}