using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Contracts.V1.Responses
{
    public class DetalleVentaDetalladoResponse
    {
        public int DetalleId { get; set; }
        public int VentaId { get; set; }
        public string Producto { get; set; }
        public int? Cantidad { get; set; }
        public int? Precio { get; set; }

    }
}