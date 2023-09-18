using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace CapaDatos
{
    public class DatosProveedor
    {
        public List<Proveedor> Listar()
        {
            List<Proveedor> listaProveedores = new List<Proveedor>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT idProveedor, cedula, razonSocial, email, telefono, estado");
                    query.AppendLine("FROM Proveedor p");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;

                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaProveedores.Add(new Proveedor()
                            {
                                idProveedor = Convert.ToInt32(reader["idProveedor"]),
                                cedula = reader["cedula"].ToString(),
                                razonSocial = reader["razonSocial"].ToString(),
                                email = reader["email"].ToString(),
                                telefono = reader["telefono"].ToString(),
                                estado = Convert.ToBoolean(reader["estado"]),
                            });
                        }
                    }

                }
                catch (Exception)
                {
                    listaProveedores = new List<Proveedor>();
                }
            }
            return listaProveedores;
        }

        public int RegistrarProveedor(Proveedor proveedor, out string mensaje)
        {
            int idProveedorGenerado = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
                {
                    //Ejecutar Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SPRegistrarProveedor", conexion);
                    //Parametros de entrada de Procedimiento Almacenado
                    cmd.Parameters.AddWithValue("cedula", proveedor.cedula);
                    cmd.Parameters.AddWithValue("razonSocial", proveedor.razonSocial);
                    cmd.Parameters.AddWithValue("email", proveedor.email);
                    cmd.Parameters.AddWithValue("telefono", proveedor.telefono);
                    cmd.Parameters.AddWithValue("estado", proveedor.estado);
                    //Parametros de salida de Procedimiento Almacenado
                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();

                    cmd.ExecuteNonQuery();

                    idProveedorGenerado = Convert.ToInt32(cmd.Parameters["resultado"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                idProveedorGenerado = 0;
                mensaje = ex.Message;
                throw;
            }
            return idProveedorGenerado;
        }

        public bool EditarProveedor(Proveedor proveedor, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
                {
                    //Ejecutar Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SPEditarProveedor", conexion);
                    //Parametros de entrada de Procedimiento Almacenado
                    cmd.Parameters.AddWithValue("idProveedor", proveedor.idProveedor);
                    cmd.Parameters.AddWithValue("cedula", proveedor.cedula);
                    cmd.Parameters.AddWithValue("razonSocial", proveedor.razonSocial);
                    cmd.Parameters.AddWithValue("email", proveedor.email);
                    cmd.Parameters.AddWithValue("telefono", proveedor.telefono);
                    cmd.Parameters.AddWithValue("estado", proveedor.estado);
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

        public bool EliminarProveedor(Proveedor proveedor, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
                {
                    //Ejecutar Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SPEliminarProveedor", conexion);
                    //Parametros de entrada de Procedimiento Almacenado
                    cmd.Parameters.AddWithValue("idProveedor", proveedor.idProveedor);
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

    }
}