using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class DatosNegocio
    {
        public Negocio ObtenerDatos()
        {
            Negocio negocio = new Negocio();

            try
            {
                using(SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion) )
                {
                    conexion.Open();

                    string query 
                        = "SELECT idNegocio, nombreNegocio, ruc, direccion FROM Negocio WHERE idNegocio = 1";

                    SqlCommand cmd = new SqlCommand(query, conexion);   
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read())
                        {
                            negocio = new Negocio()
                            {
                                idNegocio = int.Parse(reader["idNegocio"].ToString()),
                                nombreNegocio = reader["nombreNegocio"].ToString(),
                                ruc = reader["ruc"].ToString(),
                                direccion = reader["direccion"].ToString()
                            };
                        }
                    }

                }

            }
            catch (Exception)
            {
                negocio = new Negocio();
            }

            return negocio;
        }

        public byte[] ObtenerLogo(out bool obtenido)
        {
            obtenido = true;
            byte[] logoBytes = new byte[0];

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
                {
                    conexion.Open();

                    string query
                        = "SELECT logo FROM Negocio WHERE idNegocio = 1";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            logoBytes = (byte[])reader["logo"];
                        }
                    }

                }

            }
            catch (Exception)
            {
                obtenido = false;
                logoBytes = new byte[0];
            }   
            return logoBytes;
        }

        public bool ActualizarLogo(byte[] image, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
                {
                    conexion.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Negocio");
                    query.AppendLine("SET logo = @imagen");
                    query.AppendLine("WHERE idNegocio = 1");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@imagen", image);
                    cmd.CommandType = CommandType.Text;

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudo actualizar el logo";
                        respuesta = false;
                    }
                }

            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }

    }
}