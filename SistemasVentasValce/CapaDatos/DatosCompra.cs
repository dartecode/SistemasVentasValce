using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
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
                catch (Exception)
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

        public Compra ObtenerCompra(string numeroDocumento)
        {
            Compra compra = new Compra();

            using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
            {
                try
                {
                    StringBuilder query =  new StringBuilder();
                    query.AppendLine("SELECT c.idCompra, u.nombreCompleto, p.cedula, p.razonSocial,");
                    query.AppendLine("c.tipoDocumento, c.numeroDocumento, c.montoTotal,");
                    query.AppendLine("CONVERT(char(10), c.fechaRegistro, 103)[fechaRegistro]");
                    query.AppendLine("FROM Compra c");
                    query.AppendLine("INNER JOIN Usuario u");
                    query.AppendLine("ON u.idUsuario = c.idUsuario");
                    query.AppendLine("INNER JOIN Proveedor p");
                    query.AppendLine("ON p.idProveedor = c.idProveedor");
                    query.AppendLine("WHERE c.numeroDocumento = @numero");


                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@numero", numeroDocumento);
                    cmd.CommandType = CommandType.Text;

                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            compra = new Compra()
                            {
                                idCompra = Convert.ToInt32(reader["idCompra"]),
                                usuario = new Usuario() { nombreCompleto = reader["nombreCompleto"].ToString() },
                                proveedor = new Proveedor() { cedula = reader["cedula"].ToString(), 
                                                              razonSocial = reader["razonSocial"].ToString() },
                                tipoDocumento = reader["tipoDocumento"].ToString(),
                                numeroDocumento = reader["numeroDocumento"].ToString(),
                                montoTotal = Convert.ToDecimal(reader["montoTotal"].ToString()),
                                fechaRegistro = reader["fechaRegistro"].ToString()
                            };
                        }
                    }   
                }
                catch (Exception)
                {
                    compra = null;
                }
            }
            
            return compra;
        }

        public List<DetalleCompra> ObtenerDetalleCompra(int idCompra)
        {
            List<DetalleCompra> listaDetalleCompra = new List<DetalleCompra>();

            try
            {
            using (SqlConnection conexion = new SqlConnection(Conexion.cadenaConexion))
                {
                    conexion.Open();

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT p.nombreProducto, dc.precioCompra, dc.cantidad, dc.montoTotal");
                    query.AppendLine("FROM DetalleCompra dc");
                    query.AppendLine("INNER JOIN Producto p");
                    query.AppendLine("ON p.idProducto = dc.idProducto");
                    query.AppendLine("WHERE dc.idCompra = @idCompra");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@idCompra", idCompra);
                    cmd.CommandType = CommandType.Text;

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaDetalleCompra.Add(new DetalleCompra()
                            {
                                producto = new Producto() { nombreProducto = reader["nombreProducto"].ToString() },
                                precioCompra = Convert.ToDecimal(reader["precioCompra"].ToString()),
                                cantidad = Convert.ToInt32(reader["cantidad"].ToString()),
                                montoTotal = Convert.ToDecimal(reader["montoTotal"].ToString())
                            });
                        }
                    }

                }

            }
            catch (Exception)
            {
                listaDetalleCompra = new List<DetalleCompra>();
            }
            return listaDetalleCompra;
        }

    }
}