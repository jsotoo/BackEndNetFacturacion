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
    public class DetalleVentaController : ApiController
    {
        private DB_FacturacionEntities db = new DB_FacturacionEntities();

        // GET: api/Clientes
        [Route(ApiRoutes.DetalleVentas.GetAll)]
        public IHttpActionResult GetDetallesVentas()
        {

            var productos = from Detalle_Venta in db.Detalle_Venta
                            join producto in db.Productos
                            on Detalle_Venta.id_producto equals producto.id_prod
                            select new DetalleVentaDetalladoResponse
                            {
                                DetalleId = Detalle_Venta.id_detalle,
                                VentaId = Detalle_Venta.id_venta,
                                Producto = producto.nom_prod,
                                Cantidad = Detalle_Venta.cantidad,
                                Precio = Detalle_Venta.precio
                            };


            return Ok(productos);

        }


        // GET: api/Clientes/5
        [Route(ApiRoutes.DetalleVentas.Get)]
        public IHttpActionResult GetDetalleVenta(int id)
        {
            Detalle_Venta detalle_Venta = db.Detalle_Venta.Find(id);
            if (detalle_Venta == null)
            {
                return NotFound();
            }

            return Ok(new DetalleVentaReponse
            {
                DetalleId = detalle_Venta.id_detalle,
                VentaId = detalle_Venta.id_venta,
                ProductoId = detalle_Venta.id_producto,
                Cantidad = detalle_Venta.cantidad,
                Precio = detalle_Venta.precio
            });
        }
        // PUT: api/Clientes/5

        public IHttpActionResult PutDetalleVenta([FromBody] UpdateDetalleVentaRequest detalle)
        {
            Detalle_Venta det = db.Detalle_Venta.Find(detalle.DetalleId);
            det.id_detalle = detalle.DetalleId;
            det.id_venta = detalle.VentaId;
            det.id_producto = detalle.ProductoId;
            det.cantidad = detalle.Cantidad;
            det.precio = detalle.Precio;
           

            db.Entry(det).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(det);

        }

        // POST: api/Clientes
        [Route(ApiRoutes.DetalleVentas.Create)]
        public IHttpActionResult PostCliente([FromBody] CreateDetalleVentaRequest detalle)
        {
            var det = new Detalle_Venta
            {
                id_venta = detalle.VentaId,
                id_producto = detalle.ProductoId,
                cantidad = detalle.Cantidad,
                precio = detalle.Precio

            };

            Detalle_Venta result = db.Detalle_Venta.Add(det);
            db.SaveChanges();

            var response = Request.CreateResponse(HttpStatusCode.Created);

            CreatedAtRoute(ApiRoutes.DetalleVentas.Create, new { id = result.id_detalle }, result);

            return Ok(result);



        }

        // DELETE: api/Clientes/5
        [Route(ApiRoutes.DetalleVentas.Delete)]
        public IHttpActionResult DeleteProducto([FromUri] int detalleId)
        {
            Detalle_Venta detalle = db.Detalle_Venta.Find(detalleId);



            if (detalle == null)
            {
                return NotFound();
            }

            db.Detalle_Venta.Remove(detalle);
            db.SaveChanges();

            return Ok(detalle);
        }



        private bool DetalleVentaExists(int id)
        {
            return db.Detalle_Venta.Count(e => e.id_detalle == id) > 0;
        }






    }
}
