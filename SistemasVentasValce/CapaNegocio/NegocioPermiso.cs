using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class NegocioPermiso
    {
        private DatosPermiso datosPermiso = new DatosPermiso();
        public List<Permiso> Listar(int idUsuario)
        {
            return datosPermiso.Listar(idUsuario);
        }
    }
}
