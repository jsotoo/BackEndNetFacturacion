﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Contracts.V1.Requests
{
    public class CreateDetalleVentaRequest
    {
       
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int? Cantidad { get; set; }
        public int? Precio { get; set; }
    }
}