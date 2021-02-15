using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Contracts
{
   
        public static class ApiRoutes
        {
            public const string Root = "api";
            public const string Version = "v1";
            public const string Base = Root + "/" + Version;

            public static class Productos
            {
                public const string GetAll = Base + "/productos";
                public const string Create = Base + "/productos";
                public const string Get = Base + "/productos/{productoId}";
                public const string Update = Base + "/productos/{productoId}";
                public const string Delete = Base + "/productos/{productoId}";
            }

            public static class Clientes
            {
                public const string GetAll = Base + "/clientes";
                public const string Create = Base + "/clientes";
                public const string Get = Base + "/clientes/{clienteId}";
                public const string Update = Base + "/clientes/{clienteId}";
                public const string Delete = Base + "/clientes/{clienteId}";
            }

            public static class DetalleVentas
            {
                public const string GetAll = Base + "/detalleventas";
                public const string Create = Base + "/detalleventas";
                public const string Get = Base + "/detalleventas/{detalleId}";
                public const string Update = Base + "/detalleventas/{detalleId}";
                public const string Delete = Base + "/detalleventas/{detalleId}";
            }


    }
    
}