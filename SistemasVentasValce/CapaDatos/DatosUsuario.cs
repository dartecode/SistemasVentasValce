using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CapaEntidad;

namespace CapaDatos
{
    public class DatosUsuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT u.idUsuario, u.cedula, u.nombreCompleto, u.email, u.clave, u.estado, r.idRol, r.descripcion");
                    query.AppendLine("FROM Usuario u");
                    query.AppendLine("INNER JOIN Rol r ON r.idRol = u.idRol");

                    SqlCommand cmd = new SqlCommand(query.ToString(),conexion);
                    cmd.CommandType = CommandType.Text;

                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaUsuarios.Add(new Usuario()
                            {
                                idUsuario = Convert.ToInt32(reader["idUsuario"]),
                                cedula = reader["cedula"].ToString(),
                                nombreCompleto = reader["nombreCompleto"].ToString(),
                                email = reader["email"].ToString(),
                                clave = reader["clave"].ToString(),
                                estado = Convert.ToBoolean(reader["estado"]),
                                rol = new Rol() { idRol = Convert.ToInt32(reader["idRol"]),
                                                    descripcion = reader["descripcion"].ToString(),
                                }
                            });
                        }
                    }

                }
                catch (Exception)
                {
                    listaUsuarios = new List<Usuario>();
                }
            }
            return listaUsuarios;
        }
        
        public int RegistrarUsuario(Usuario usuario, out string mensaje)
        {
            int idUsuarioGenerado = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
                {
                    //Ejecutar Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SPRegistrarUsuario", conexion);
                    //Parametros de entrada de Procedimiento Almacenado
                    cmd.Parameters.AddWithValue("cedula", usuario.cedula);
                    cmd.Parameters.AddWithValue("nombreCompleto", usuario.nombreCompleto);
                    cmd.Parameters.AddWithValue("email", usuario.email);
                    cmd.Parameters.AddWithValue("clave", usuario.clave);
                    cmd.Parameters.AddWithValue("idrol", usuario.rol.idRol);
                    cmd.Parameters.AddWithValue("estado", usuario.estado);
                    //Parametros de salida de Procedimiento Almacenado
                    cmd.Parameters.Add("idUsuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();

                    cmd.ExecuteNonQuery();

                    idUsuarioGenerado = Convert.ToInt32(cmd.Parameters["idUsuarioResultado"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                idUsuarioGenerado = 0;
                mensaje = ex.Message;
                throw;
            }
            return idUsuarioGenerado;
        }

        public bool EditarUsuario(Usuario usuario, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
                {
                    //Ejecutar Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SPEditarUsuario", conexion);
                    //Parametros de entrada de Procedimiento Almacenado
                    cmd.Parameters.AddWithValue("idUsuario", usuario.idUsuario);
                    cmd.Parameters.AddWithValue("cedula", usuario.cedula);
                    cmd.Parameters.AddWithValue("nombreCompleto", usuario.nombreCompleto);
                    cmd.Parameters.AddWithValue("email", usuario.email);
                    cmd.Parameters.AddWithValue("clave", usuario.clave);
                    cmd.Parameters.AddWithValue("idrol", usuario.rol.idRol);
                    cmd.Parameters.AddWithValue("estado", usuario.estado);
                    //Parametros de salida de Procedimiento Almacenado
                    cmd.Parameters.Add("respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["respuesta"].Value);
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

        public bool EliminarUsuario(Usuario usuario, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
                {
                    //Ejecutar Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SPEliminarUsuario", conexion);
                    //Parametros de entrada de Procedimiento Almacenado
                    cmd.Parameters.AddWithValue("idUsuario", usuario.idUsuario);
                    //Parametros de salida de Procedimiento Almacenado
                    cmd.Parameters.Add("respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["respuesta"].Value);
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