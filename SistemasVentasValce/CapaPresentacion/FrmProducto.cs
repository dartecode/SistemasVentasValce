using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmProducto : Form
    {
        public FrmProducto()
        {
            InitializeComponent();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            //Llenar ComboBoxEstado
            cbxEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cbxEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cbxEstado.DisplayMember = "Texto";
            cbxEstado.ValueMember = "Valor";
            cbxEstado.SelectedIndex = 0;

            //Llenar ComboBoxCategoria mediante consulta de base de datos
            List<Categoria> listaCategoria = new NegocioCategoria().Listar();

            foreach (Categoria item in listaCategoria)
            {
                cbxCategoria.Items.Add(new OpcionCombo() { Valor = item.idCategoria, Texto = item.descripcion });
            }
            cbxCategoria.DisplayMember = "Texto";
            cbxCategoria.ValueMember = "Valor";
            cbxCategoria.SelectedIndex = 0;

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

            //Mostrar Productos en el DataGridView con datos de la DB
            List<Producto> listaProducto = new NegocioProducto().Listar();

            foreach (Producto item in listaProducto)
            {
                dgvData
                .Rows
                .Add(new object[] { "",
                                    item.idProducto,
                                    item.codigo,
                                    item.nombreProducto,
                                    item.descripcion,
                                    item.categoria.idCategoria,
                                    item.categoria.descripcion,
                                    item.stock,
                                    item.precioCompra,
                                    item.precioVenta,
                                    item.estado == true ? 1 : 0,
                                    item.estado == true ? "Activo" : "No Activo",
                });
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String mensaje = string.Empty;
            //Crear un objeto de clase Usuario para almacenar datos que queremos insertar a base de datos
            Producto producto = new Producto()
            {
                idProducto = Convert.ToInt32(txtId.Text),
                codigo = txtCodigo.Text,
                nombreProducto = txtNombreProducto.Text,
                descripcion = txtDescripcion.Text,
                categoria = new Categoria() { idCategoria = Convert.ToInt32(((OpcionCombo)cbxCategoria.SelectedItem).Valor) },
                estado = Convert.ToInt32(((OpcionCombo)cbxEstado.SelectedItem).Valor) == 1 ? true : false
            };

            if (producto.idProducto == 0)
            {
                //Metodo Agregar
                int idProductoGenerado = new NegocioProducto().RegistrarProducto(producto, out mensaje);

                if (idProductoGenerado != 0)
                {
                    //Agregar Datos al DataGridView
                    dgvData
                    .Rows
                    .Add(new object[] { 
                            "",
                            idProductoGenerado,
                            txtCodigo.Text,
                            txtNombreProducto.Text,
                            txtDescripcion.Text,
                            ((OpcionCombo)cbxCategoria.SelectedItem).Valor.ToString(),
                            ((OpcionCombo)cbxCategoria.SelectedItem).Texto.ToString(),
                            "0",
                            "0.00",
                            "0.00",
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
                bool resultado = new NegocioProducto().EditarProducto(producto, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["dgvIdProducto"].Value = txtId.Text;
                    row.Cells["dgvCodigo"].Value = txtCodigo.Text;
                    row.Cells["dgvNombreProducto"].Value = txtNombreProducto.Text;
                    row.Cells["dgvDescripcion"].Value = txtDescripcion.Text;
                    row.Cells["dgvIdCategoria"].Value = ((OpcionCombo)cbxCategoria.SelectedItem).Valor.ToString();
                    row.Cells["dgvCategoria"].Value = ((OpcionCombo)cbxCategoria.SelectedItem).Texto.ToString();
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
            txtCodigo.Text = "";
            txtNombreProducto.Text = "";
            txtDescripcion.Text = "";
            cbxEstado.SelectedIndex = 0;
            cbxCategoria.SelectedIndex = 0;

            txtCodigo.Select();
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
                    txtId.Text = dgvData.Rows[indice].Cells["dgvIdProducto"].Value.ToString();
                    txtCodigo.Text = dgvData.Rows[indice].Cells["dgvCodigo"].Value.ToString();
                    txtNombreProducto.Text = dgvData.Rows[indice].Cells["dgvNombreProducto"].Value.ToString();
                    txtDescripcion.Text = dgvData.Rows[indice].Cells["dgvDescripcion"].Value.ToString();

                    //Para poner el valor del usuario en el comboboxRol del formulario
                    foreach (OpcionCombo opcion in cbxCategoria.Items)
                    {
                        if (Convert.ToInt32(opcion.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["dgvIdCategoria"].Value))
                        {
                            int indiceCombo = cbxCategoria.Items.IndexOf(opcion);
                            cbxCategoria.SelectedIndex = indiceCombo;
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Eliminar si hay elemento seleccionado
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                //MessageBox para confirmar si desea eliminar
                if (MessageBox.Show("Desea eliminar el producto seleccionado?",
                                    "Mensaje",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Producto producto = new Producto()
                    {
                        idProducto = Convert.ToInt32(txtId.Text)
                    };

                    bool respuesta = new NegocioProducto().EliminarProducto(producto, out mensaje);
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

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            //Comprobar si hay productos
            if (dgvData.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", 
                                "Mensaje", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                //Crear DataTable
                DataTable dataTable = new DataTable();

                //Solo agregar las columnas visibles del DataGridView
                foreach (DataGridViewColumn column in dgvData.Columns)
                {
                    if (column.HeaderText != "" && column.Visible)
                        dataTable.Columns.Add(column.HeaderText, typeof(string));
                }

                //Agregar las filas al DataTable
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Visible)
                        dataTable.Rows.Add(new Object[]
                        {
                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                            row.Cells[4].Value.ToString(),
                            row.Cells[6].Value.ToString(),
                            row.Cells[7].Value.ToString(),
                            row.Cells[8].Value.ToString(),
                            row.Cells[9].Value.ToString(),
                            row.Cells[11].Value.ToString()
                        });
                }

                //Dialogo de como querer guardar el archivo
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = 
                    string.Format("ReporteProducto_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                saveFile.Filter = "Excel Files | *.xlsx";


                if(saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dataTable, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(saveFile.FileName);

                        MessageBox.Show("Reporte generado",
                                        "Mensaje",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    catch 
                    {
                        MessageBox.Show("Error al generar reporte",
                                        "Mensaje",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                        
                    }
                }
            }
        }
    }
}