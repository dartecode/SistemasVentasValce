using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class NegocioProveedor
    {
        private DatosProveedor datosProveedor = new DatosProveedor();
        public List<Proveedor> Listar()
        {
            return datosProveedor.Listar();
        }

        public int RegistrarProveedor(Proveedor proveedor, out string mensaje)
        {
            mensaje = string.Empty;

            if (proveedor.cedula == "")
            {
                mensaje += "Es necesario la cedula del Proveedor \n";
            }
            if (proveedor.razonSocial == "")
            {
                mensaje += "Es necesario la razon Social del Proveedor \n";
            }
            if (proveedor.email == "")
            {
                mensaje += "Es necesario el email del Proveedor \n";
            }
            if (proveedor.telefono == "")
            {
                mensaje += "Es necesario el numero de telefono del Proveedor \n";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return datosProveedor.RegistrarProveedor(proveedor, out mensaje);
            }

        }

        public bool EditarProveedor(Proveedor proveedor, out string mensaje)
        {
            mensaje = string.Empty;

            if (proveedor.cedula == "")
            {
                mensaje += "Es necesario la cedula del Proveedor \n";
            }
            if (proveedor.razonSocial == "")
            {
                mensaje += "Es necesario la razon Social del Proveedor \n";
            }
            if (proveedor.email == "")
            {
                mensaje += "Es necesario el email del Proveedor \n";
            }
            if (proveedor.telefono == "")
            {
                mensaje += "Es necesario el numero de telefono del Proveedor \n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return datosProveedor.EditarProveedor(proveedor, out mensaje);
            }

        }

        public bool EliminarProveedor(Proveedor proveedor, out string mensaje)
        {
            return datosProveedor.EliminarProveedor(proveedor, out mensaje);
        }
    }
}