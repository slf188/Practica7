using LogicaNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace APIRESTVentas2
{
    public class ServicioProductos: ApiController
    {
        LogicaProductos logicaProductos = new LogicaProductos();
        public IHttpActionResult Get()
        {
            var productos = logicaProductos.ListarProductos();
            return Ok(productos);
        }
    }
}