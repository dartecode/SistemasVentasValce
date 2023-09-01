using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegocioUsuario
    {
        private DatosUsuario datosUsuario = new DatosUsuario();
        public List<Usuario> Listar()
        {
            return datosUsuario.Listar();
        }
    }
}
