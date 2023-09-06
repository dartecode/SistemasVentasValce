using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class NegocioUsuario
    {
        private DatosUsuario datosUsuario = new DatosUsuario();
        public List<Usuario> Listar()
        {
            return datosUsuario.Listar();
        }

        public int RegistrarUsuario (Usuario usuario, out string mensaje)
        {
            mensaje = string.Empty;

            if (usuario.cedula == "")
            {
                mensaje += "Es necesario la cedula del usuario \n";
            }
            if (usuario.nombreCompleto == "")
            {
                mensaje += "Es necesario el nombre completo del usuario \n";
            }
            if (usuario.clave == "")
            {
                mensaje += "Es necesario la clave del usuario \n";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return datosUsuario.RegistrarUsuario(usuario, out mensaje);
            }
            
        }

        public bool EditarUsuario(Usuario usuario, out string mensaje)
        {
            mensaje = string.Empty;

            if (usuario.cedula == "")
            {
                mensaje += "Es necesario la cedula del usuario \n";
            }
            if (usuario.nombreCompleto == "")
            {
                mensaje += "Es necesario el nombre completo del usuario \n";
            }
            if (usuario.clave == "")
            {
                mensaje += "Es necesario la clave del usuario \n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return datosUsuario.EditarUsuario(usuario, out mensaje);
            }
            
        }

        public bool EliminarUsuario(Usuario usuario, out string mensaje)
        {
            return datosUsuario.EliminarUsuario(usuario, out mensaje);
        }
        
    }
}
