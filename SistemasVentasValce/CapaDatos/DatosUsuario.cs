using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                    string query = 
                        "select idUsuario, cedula, nombreCompleto, correo, clave, estado from Usuario";
                    SqlCommand cmd = new SqlCommand(query,conexion);
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
                                correo = reader["correo"].ToString(),
                                clave = reader["clave"].ToString(),
                                estado = Convert.ToBoolean(reader["estado"])
                            });
                        }
                    }

                }
                catch (Exception)
                {
                    listaUsuarios=new List<Usuario>();
                }
            }
            return listaUsuarios;
        }
    }
}
