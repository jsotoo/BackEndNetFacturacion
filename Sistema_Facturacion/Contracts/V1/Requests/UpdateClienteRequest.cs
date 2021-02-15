using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Contracts.V1.Requests
{
    public class UpdateClienteRequest
    {
        public int id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public string email { get; set; }
    }
}