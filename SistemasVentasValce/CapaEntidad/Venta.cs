using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Venta
    {
        public int idVenta {  get; set; }
        public Usuario idUsuario { get; set;}
        public string tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string cedulaCliente { get; set; }
        public string nombreCliente { get; set; }
        public decimal montoPago { get; set; }
        public decimal montoCambio { get; set; }
        public decimal montoTotal { get; set; }
        public List<DetalleVenta> detalleVenta { get; set; }
        public string fechaRegistro { get; set; }
    }
}
