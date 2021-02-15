using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Contracts.V1.Requests
{
    public class CreateProductoRequest
    {
        public string Nombre { get; set; }
        public int? Precio { get; set; }
        public int? stock { get; set; }
    }
}