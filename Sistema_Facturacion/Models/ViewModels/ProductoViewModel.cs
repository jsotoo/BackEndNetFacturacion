using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Models.ViewModels
{
    public class ProductoViewModel
    {
        public string Nombre { get; set; }
        public int? Precio { get; set; }
        public int? stock { get; set; }
    }
}