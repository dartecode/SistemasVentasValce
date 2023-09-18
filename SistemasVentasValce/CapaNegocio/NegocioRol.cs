using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

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
