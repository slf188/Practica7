using AccesoDatos;
using LogicaNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ApiVentas2.Controllers
{
    public class ProductosController : ApiController
    {
        LogicaProductos logicaProductos = new LogicaProductos();
        // GET: Productos
        public List<Productos> Get()
        {
            return logicaProductos.ListarProductos();
        }

        
    }
}
