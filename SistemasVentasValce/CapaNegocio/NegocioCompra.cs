using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;
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

        public Compra ObtenerCompra(string numeroDocumento)
        {
            Compra compra = datosCompra.ObtenerCompra(numeroDocumento);

            if (compra.idCompra != 0)
            {
                List<DetalleCompra> listaDetalleCompra = 
                    datosCompra
                    .ObtenerDetalleCompra(compra.idCompra);

                compra.detalleCompra = listaDetalleCompra;

            }
            return compra;
        }

    }
}
