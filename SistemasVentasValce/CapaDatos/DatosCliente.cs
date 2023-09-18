using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace CapaDatos
{
    public class DatosCliente
    {
        public List<Cliente> Listar()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT idCliente, cedula, nombreCompleto, email, telefono, estado");
                    query.AppendLine("FROM Cliente;");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;

                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaClientes.Add(new Cliente()
                            {
                                idCliente = Convert.ToInt32(reader["idCliente"]),
                                cedula = reader["cedula"].ToString(),
                                nombreCompleto = reader["nombreCompleto"].ToString(),
                                email = reader["email"].ToString(),
                                telefono = reader["telefono"].ToString(),
                                estado = Convert.ToBoolean(reader["estado"]),
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    listaClientes = new List<Cliente>();
                }
            }
            return listaClientes;
        }

        public int RegistrarCliente(Cliente cliente, out string mensaje)
        {
            int idClienteGenerado = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
                {
                    //Ejecutar Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SPRegistrarCliente", conexion);
                    //Parametros de entrada de Procedimiento Almacenado
                    cmd.Parameters.AddWithValue("cedula", cliente.cedula);
                    cmd.Parameters.AddWithValue("nombreCompleto", cliente.nombreCompleto);
                    cmd.Parameters.AddWithValue("email", cliente.email);
                    cmd.Parameters.AddWithValue("telefono", cliente.telefono);
                    cmd.Parameters.AddWithValue("estado", cliente.estado);
                    //Parametros de salida de Procedimiento Almacenado
                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();

                    cmd.ExecuteNonQuery();

                    idClienteGenerado = Convert.ToInt32(cmd.Parameters["resultado"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                idClienteGenerado = 0;
                mensaje = ex.Message;
                throw;
            }
            return idClienteGenerado;
        }

        public bool EditarCliente(Cliente cliente, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
                {
                    //Ejecutar Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SPEditarCliente", conexion);
                    //Parametros de entrada de Procedimiento Almacenado
                    cmd.Parameters.AddWithValue("idCliente", cliente.idCliente);
                    cmd.Parameters.AddWithValue("cedula", cliente.cedula);
                    cmd.Parameters.AddWithValue("nombreCompleto", cliente.nombreCompleto);
                    cmd.Parameters.AddWithValue("email", cliente.email);
                    cmd.Parameters.AddWithValue("telefono", cliente.telefono);
                    cmd.Parameters.AddWithValue("estado", cliente.estado);
                    //Parametros de salida de Procedimiento Almacenado
                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["resultado"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = ex.Message;
                throw;
            }
            return respuesta;
        }

        public bool EliminarCliente(Cliente cliente, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
                {
                    SqlCommand cmd = 
                        new SqlCommand("DELETE FROM Cliente WHERE idCliente = @idCliente", conexion);
                    cmd.Parameters.AddWithValue("@idCliente", cliente.idCliente);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();

                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;

                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = ex.Message;
                throw;
            }
            return respuesta;
        }
    }
}