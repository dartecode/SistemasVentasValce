using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegocioRol
    {
        private DatosRol datosRol = new DatosRol();
        public List<Rol> Listar()
        {
            return datosRol.Listar();
        }
    }
}
