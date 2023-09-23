using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CNegocio
    {
        private DatosNegocio datosNegocio = new DatosNegocio();

        public Negocio ObtenerDatos()
        {
            return datosNegocio.ObtenerDatos();
        }
        
        public byte[] ObtenerLogo(out bool obtenido)
        {
             return datosNegocio.ObtenerLogo(out obtenido);
        }

        public bool ActualizarLogo(byte[] imagen,out string mensaje)
        {
            return datosNegocio.ActualizarLogo(imagen, out mensaje);
        }

    }
}