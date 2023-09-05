using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace CapaDatos
{
    public class DatosRol
    {
        public List<Rol> Listar()
        {
            List<Rol> listaRol = new List<Rol>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT idRol, descripcion FROM Rol");
                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;

                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaRol.Add(new Rol()
                            {
                                idRol = Convert.ToInt32(reader["idRol"]),
                                descripcion = reader["descripcion"].ToString()
                            });
                        }
                    }

                }
                catch (Exception)
                {
                    listaRol = new List<Rol>();
                }
            }
            return listaRol;
        }
    }
}
