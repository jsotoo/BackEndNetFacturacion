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
using Sistema_Facturacion.Models.ViewModels;
using System.Web.Http.Cors;

namespace Sistema_Facturacion.Controllers
{
    [EnableCors(origins: "http://localhost:4200",headers:"*", methods:"*")]
    public class ProductosController : ApiController
    {
        private DB_FacturacionEntities db = new DB_FacturacionEntities();

        // GET: api/Productos
        [Route(ApiRoutes.Productos.GetAll)]
        public IHttpActionResult GetProductos()
        {

            var productos = from producto in db.Productos
                             select new ProductoResponse
                             {
                                 Id = producto.id_prod,
                                 Nombre = producto.nom_prod,
                                 Precio = producto.precio_prod,
                                 stock = producto.stock

                             };


            return Ok(productos);

        }



          

        // GET: api/Productos/5
        [Route(ApiRoutes.Productos.Get)]
        public IHttpActionResult GetProducto(int id)
        {
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return NotFound();
            }

            return Ok(new ProductoResponse
            {
                Id = producto.id_prod,
                Nombre = producto.nom_prod,
                Precio = producto.precio_prod,
                stock = producto.stock
            });
        }

        // PUT: api/Productos/5
      //  [Route(ApiRoutes.Productos.Update)]
        public IHttpActionResult PutProducto([FromBody] UpdateProductoRequest producto)
        {
            Producto prod = db.Productos.Find(producto.id);
            prod.id_prod = producto.id;
            prod.nom_prod = producto.Nombre;
            prod.precio_prod = producto.Precio;
            prod.stock = producto.stock;

            db.Entry(prod).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(prod);

        }

        // POST: api/Productos
        [Route(ApiRoutes.Productos.Create)]
        public IHttpActionResult PostProducto([FromBody] CreateProductoRequest productoCreate)
        {
            var prod = new Producto
            {

                nom_prod = productoCreate.Nombre,
                precio_prod = productoCreate.Precio,
                stock = productoCreate.stock

            };

            Producto result = db.Productos.Add(prod);
            db.SaveChanges();

            var response = Request.CreateResponse(HttpStatusCode.Created);

            CreatedAtRoute(ApiRoutes.Productos.Create, new { id = result.id_prod }, result);

            return Ok(result);



        }

        // DELETE: api/Producto/5
        [Route(ApiRoutes.Productos.Delete)]
        public IHttpActionResult DeleteProducto([FromUri] int productoId)
        {
            Producto producto = db.Productos.Find(productoId);



            if (producto == null)
            {
                return NotFound();
            }

            db.Productos.Remove(producto);
            db.SaveChanges();

            return Ok(producto);
        }
        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        */
        private bool ProductoExists(int id)
        {
            return db.Productos.Count(e => e.id_prod == id) > 0;
        }
    }
}