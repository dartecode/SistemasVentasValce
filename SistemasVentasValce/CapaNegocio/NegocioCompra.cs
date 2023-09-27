using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocio
{
    public class NegocioCompra
    {
        private DatosCompra datosCompra = new DatosCompra();

        public int ObtenerCorrelativo()
        {
            return datosCompra.ObtenerCorrelativo();
        }

        public bool Registrar(Compra compra, DataTable dtDetalleCompra, out string mensaje)
        {
            return datosCompra.Registrar(compra, dtDetalleCompra, out mensaje);
        }

    }
}
