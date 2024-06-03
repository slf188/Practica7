using AccesoDatos;
using LogicaNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Ventas2_SOAP
{
    /// <summary>
    /// Descripción breve de serviceVentas2
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class serviceVentas2 : System.Web.Services.WebService
    {
        LogicaProductos productos = new LogicaProductos();

        [WebMethod]
        public List<Productos> ListarProductos()
        {
            return productos.ListarProductos();
        }
    }
}
