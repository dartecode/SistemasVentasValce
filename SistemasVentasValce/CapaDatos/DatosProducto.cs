using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Reflection;

namespace CapaDatos
{
    public class DatosProducto
    {
        public List<Producto> Listar()
        {
            List<Producto> listaProductos = new List<Producto>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT p.idProducto, p.codigo, p.nombreProducto, p.descripcion, c.idCategoria,");
                    query.AppendLine("c.descripcion[descripcionCategoria], p.stock, p.precioCompra, p.precioVenta, p.estado");
                    query.AppendLine("FROM Producto p");
                    query.AppendLine("INNER JOIN Categoria c");
                    query.AppendLine("ON c.idCategoria = p.idCategoria;");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;

                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaProductos.Add(new Producto()
                            {
                                idProducto = Convert.ToInt32(reader["idProducto"]),
                                codigo = reader["codigo"].ToString(),
                                nombreProducto = reader["nombreProducto"].ToString(),
                                descripcion = reader["descripcion"].ToString(),
                                categoria = new Categoria()
                                {
                                    idCategoria = Convert.ToInt32(reader["idCategoria"]),
                                    descripcion = reader["descripcionCategoria"].ToString() 
                                },
                                stock = Convert.ToInt32(reader["stock"]),
                                precioCompra =  Convert.ToDecimal(reader["precioCompra"]),
                                precioVenta = Convert.ToDecimal(reader["precioVenta"]),
                                estado = Convert.ToBoolean(reader["estado"]),
                            });
                        }
                    }

                }
                catch (Exception)
                {
                    listaProductos = new List<Producto>();
                }
            }
            return listaProductos;
        }

        public int RegistrarProducto(Producto producto, out string mensaje)
        {
            int idProductoGenerado = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
                {
                    //Ejecutar Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SPRegistrarProducto", conexion);
                    //Parametros de entrada de Procedimiento Almacenado
                    cmd.Parameters.AddWithValue("codigo", producto.codigo);
                    cmd.Parameters.AddWithValue("nombreProducto", producto.nombreProducto);
                    cmd.Parameters.AddWithValue("descripcion", producto.descripcion);
                    cmd.Parameters.AddWithValue("idCategoria", producto.categoria.idCategoria);
                    cmd.Parameters.AddWithValue("estado", producto.estado);
                    //Parametros de salida de Procedimiento Almacenado
                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();

                    cmd.ExecuteNonQuery();

                    idProductoGenerado = Convert.ToInt32(cmd.Parameters["resultado"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                idProductoGenerado = 0;
                mensaje = ex.Message;
                throw;
            }
            return idProductoGenerado;
        }

        public bool EditarProducto(Producto producto, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
                {
                    //Ejecutar Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SPEditarProducto", conexion);
                    //Parametros de entrada de Procedimiento Almacenado
                    cmd.Parameters.AddWithValue("idProducto", producto.idProducto);
                    cmd.Parameters.AddWithValue("codigo", producto.codigo);
                    cmd.Parameters.AddWithValue("nombreProducto", producto.nombreProducto);
                    cmd.Parameters.AddWithValue("descripcion", producto.descripcion);
                    cmd.Parameters.AddWithValue("idCategoria", producto.categoria.idCategoria);
                    cmd.Parameters.AddWithValue("estado", producto.estado);
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

        public bool EliminarProducto(Producto producto, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
                {
                    //Ejecutar Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SPEliminarProducto", conexion);
                    //Parametros de entrada de Procedimiento Almacenado
                    cmd.Parameters.AddWithValue("idProducto", producto.idProducto);
                    //Parametros de salida de Procedimiento Almacenado
                    cmd.Parameters.Add("respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

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
