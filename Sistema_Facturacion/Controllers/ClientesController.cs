using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Sistema_Facturacion.Contracts;
using Sistema_Facturacion.Contracts.V1.Requests;
using Sistema_Facturacion.Contracts.V1.Responses;
using Sistema_Facturacion.Models;

namespace Sistema_Facturacion.Controllers
{
    public class ClientesController : ApiController
    {
        private DB_FacturacionEntities db = new DB_FacturacionEntities();

        // GET: api/Clientes
        [Route(ApiRoutes.Clientes.GetAll)]
        public IHttpActionResult GetClientes()
        {

            var productos = from cliente in db.Clientes
                            select new ClienteReponse
                            {
                                Id =  cliente.id_cli,
                                Nombres = cliente.nombres_cli,
                                Apellidos = cliente.apellidos_cli,
                                Direccion = cliente.direccion_cli,
                                Telefono = cliente.telefono_cli,
                                Email = cliente.email
                            };


            return Ok(productos);

        }


        // GET: api/Clientes/5
        [Route(ApiRoutes.Clientes.Get)]
        public IHttpActionResult GetCliente(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(new ClienteReponse
            {
                Id = cliente.id_cli,
                Nombres = cliente.nombres_cli,
                Apellidos = cliente.apellidos_cli,
                Direccion = cliente.direccion_cli,
                Telefono = cliente.telefono_cli,
                Email = cliente.email
            });
        }
        // PUT: api/Clientes/5

        public IHttpActionResult PutProducto([FromBody] UpdateClienteRequest cliente)
        {
            Cliente cli = db.Clientes.Find(cliente.id);
            cli.id_cli = cliente.id;
            cli.nombres_cli = cliente.Nombres;
            cli.apellidos_cli = cliente.Apellidos;
            cli.direccion_cli = cliente.direccion;
            cli.telefono_cli = cliente.telefono;
            cli.email = cliente.email;

            db.Entry(cli).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(cli);

        }

        // POST: api/Clientes
        [Route(ApiRoutes.Clientes.Create)]
        public IHttpActionResult PostCliente([FromBody] CreateClienteRequest clienteCreate)
        {
            var cli = new Cliente
            {

                nombres_cli = clienteCreate.Nombres,
                apellidos_cli = clienteCreate.Apellidos,
                direccion_cli = clienteCreate.direccion,
                telefono_cli = clienteCreate.telefono,
                email = clienteCreate.email

            };

            Cliente result = db.Clientes.Add(cli);
            db.SaveChanges();

            var response = Request.CreateResponse(HttpStatusCode.Created);

            CreatedAtRoute(ApiRoutes.Clientes.Create, new { id = result.id_cli }, result);

            return Ok(result);



        }

        // DELETE: api/Clientes/5
        [Route(ApiRoutes.Clientes.Delete)]
        public IHttpActionResult DeleteProducto([FromUri] int clienteId)
        {
            Cliente cliente = db.Clientes.Find(clienteId);



            if (cliente == null)
            {
                return NotFound();
            }

            db.Clientes.Remove(cliente);
            db.SaveChanges();

            return Ok(cliente);
        }



        private bool ClienteExists(int id)
        {
            return db.Clientes.Count(e => e.id_cli == id) > 0;
        }
    }
}