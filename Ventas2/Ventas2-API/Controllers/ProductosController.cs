using LogicaNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Ventas2_API.Controllers
{
    public class ProductosController : ApiController
    {
        LogicaProductos productos = new LogicaProductos();
        // GET: Productos
        public IHttpActionResult Get()
        {
            return Ok(productos.ListarProductos());
        }
    }
}