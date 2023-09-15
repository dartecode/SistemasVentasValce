using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class NegocioProducto
    {
        private DatosProducto datosProducto = new DatosProducto();
        public List<Producto> Listar()
        {
            return datosProducto.Listar();
        }

        public int RegistrarProducto(Producto producto, out string mensaje)
        {
            mensaje = string.Empty;

            if (producto.codigo == "")
            {
                mensaje += "Es necesario el codigo del Producto \n";
            }
            if (producto.nombreProducto == "")
            {
                mensaje += "Es necesario el nombre del Producto \n";
            }
            if (producto.descripcion == "")
            {
                mensaje += "Es necesario la descripcion del Producto \n";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return datosProducto.RegistrarProducto(producto, out mensaje);
            }
        }

        public bool EditarProducto(Producto producto, out string mensaje)
        {
            mensaje = string.Empty;

            if (producto.codigo == "")
            {
                mensaje += "Es necesario el codigo del Producto \n";
            }
            if (producto.nombreProducto == "")
            {
                mensaje += "Es necesario el nombre del Producto \n";
            }
            if (producto.descripcion == "")
            {
                mensaje += "Es necesario la descripcion del Producto \n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return datosProducto.EditarProducto(producto, out mensaje);
            }
        }

        public bool EliminarProducto(Producto producto, out string mensaje)
        {
            return datosProducto.EliminarProducto(producto, out mensaje);
        }
    }
}