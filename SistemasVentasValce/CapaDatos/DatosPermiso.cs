using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Text;

namespace CapaDatos
{
    public class DatosPermiso
    {
        public List<Permiso> Listar(int idUsuario)
        {
            List<Permiso> listaPermisos = new List<Permiso>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
            {
                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT p.idRol, p.nombremenu FROM Permiso p");
                    query.AppendLine("INNER JOIN Rol r ON r.idRol = p.idRol");
                    query.AppendLine("INNER JOIN Usuario u ON u.idRol = p.idRol");
                    query.AppendLine("WHERE u.idUsuario = @idUsuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.CommandType = CommandType.Text;

                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaPermisos.Add(new Permiso()
                            {
                                idRol = new Rol() { idRol = Convert.ToInt32(reader["idRol"]) },
                                nombreMenu = reader["nombreMenu"].ToString()
                            });
                        }
                    }

                }
                catch (Exception)
                {
                    listaPermisos = new List<Permiso>();
                }
            }
            return listaPermisos;
        }
    }
}
