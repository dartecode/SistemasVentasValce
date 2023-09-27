using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class DatosCompra
    {
        public int ObtenerCorrelativo()
        {
            int idCorrelativo = 0;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) +1 FROM Compra");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();

                    idCorrelativo = Convert.ToInt32(cmd.ExecuteScalar());

                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return idCorrelativo;
        }

        public bool Registrar(Compra compra, DataTable dtDetalleCompra, out string mensaje)
        {
            bool respuesta = false;
            mensaje = String.Empty;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SPRegistrarCompra", conexion);
                    cmd.Parameters.AddWithValue("idUsuario", compra.usuario.idUsuario);
                    cmd.Parameters.AddWithValue("idProveedor", compra.proveedor.idProveedor);
                    cmd.Parameters.AddWithValue("tipoDocumento", compra.tipoDocumento);
                    cmd.Parameters.AddWithValue("numeroDocumento", compra.numeroDocumento);
                    cmd.Parameters.AddWithValue("montoTotal", compra.montoTotal);
                    cmd.Parameters.AddWithValue("DetalleCompra", dtDetalleCompra);
                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    conexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["resultado"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();

                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                    respuesta = false; ;
                }
            }
            return respuesta;
        }

    }
}