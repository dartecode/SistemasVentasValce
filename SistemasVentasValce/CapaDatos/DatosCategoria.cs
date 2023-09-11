using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DatosCategoria
    {
        public List<Categoria> Listar()
        {
            List<Categoria> listaCategoria = new List<Categoria>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT idCategoria, descripcion, estado FROM Categoria");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;

                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaCategoria.Add(new Categoria()
                            {
                                idCategoria = Convert.ToInt32(reader["idCategoria"]),
                                descripcion = reader["descripcion"].ToString(),
                                estado = Convert.ToBoolean(reader["estado"])
                            });
                        }
                    }

                }
                catch (Exception)
                {
                    listaCategoria = new List<Categoria>();
                }
            }
            return listaCategoria;
        }

        public int RegistrarCategoria(Categoria categoria, out string mensaje)
        {
            int idResultado = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
                {
                    //Ejecutar Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SPRegistrarCategoria", conexion);
                    //Parametros de entrada de Procedimiento Almacenado
                    cmd.Parameters.AddWithValue("descripcion", categoria.descripcion);
                    cmd.Parameters.AddWithValue("estado", categoria.estado);
                    //Parametros de salida de Procedimiento Almacenado
                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();

                    cmd.ExecuteNonQuery();

                    idResultado = Convert.ToInt32(cmd.Parameters["resultado"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                idResultado = 0;
                mensaje = ex.Message;
                throw;
            }
            return idResultado;
        }

        public bool EditarCategoria(Categoria categoria, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
                {
                    //Ejecutar Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SPEditarCategoria", conexion);
                    //Parametros de entrada de Procedimiento Almacenado
                    cmd.Parameters.AddWithValue("idCategoria", categoria.idCategoria);
                    cmd.Parameters.AddWithValue("descripcion", categoria.descripcion);
                    cmd.Parameters.AddWithValue("estado", categoria.estado);
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

        public bool EliminarCategoria(Categoria categoria, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
                {
                    //Ejecutar Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SPEliminarCategoria", conexion);
                    //Parametros de entrada de Procedimiento Almacenado
                    cmd.Parameters.AddWithValue("idCategoria", categoria.idCategoria);
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