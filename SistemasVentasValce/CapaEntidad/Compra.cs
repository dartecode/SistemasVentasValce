using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Compra
    {
        public int idCompra { get; set; }
        public Usuario usuario { get; set; }
        public Proveedor proveedor{ get; set; }
        public string tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public decimal montoTotal { get; set; }
        public List<DetalleCompra> detalleCompra { get; set; }
        public string fechaRegistro { get; set; }

    }
}
