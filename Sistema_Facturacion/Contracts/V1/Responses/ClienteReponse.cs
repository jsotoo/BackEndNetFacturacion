using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Contracts.V1.Responses
{
    public class ClienteReponse
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public int? Telefono { get; set; }
        public string Email { get; set; }
    }
}