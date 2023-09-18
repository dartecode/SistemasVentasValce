using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegocioCliente
    {
        private DatosCliente datosCliente = new DatosCliente();
        public List<Cliente> Listar()
        {
            return datosCliente.Listar();
        }

        public int RegistrarCliente(Cliente cliente, out string mensaje)
        {
            mensaje = string.Empty;

            if (cliente.cedula == "")
            {
                mensaje += "Es necesario la cedula del Cliente \n";
            }
            if (cliente.nombreCompleto == "")
            {
                mensaje += "Es necesario el nombre completo del Cliente \n";
            }
            if (cliente.email == "")
            {
                mensaje += "Es necesario el email del Cliente \n";
            }
            if (cliente.telefono == "")
            {
                mensaje += "Es necesario el numero de telefono del Cliente \n";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return datosCliente.RegistrarCliente(cliente, out mensaje);
            }
        }

        public bool EditarCliente(Cliente cliente, out string mensaje)
        {
            mensaje = string.Empty;

            if (cliente.cedula == "")
            {
                mensaje += "Es necesario la cedula del Cliente \n";
            }
            if (cliente.nombreCompleto == "")
            {
                mensaje += "Es necesario el nombre completo del Cliente \n";
            }
            if (cliente.telefono == "")
            {
                mensaje += "Es necesario el numero del Cliente \n";
            }
            if (cliente.email == "")
            {
                mensaje += "Es necesario el email del Cliente \n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return datosCliente.EditarCliente(cliente, out mensaje);
            }
        }

        public bool EliminarCliente(Cliente cliente, out string mensaje)
        {
            return datosCliente.EliminarCliente(cliente, out mensaje);
        }
    }
}