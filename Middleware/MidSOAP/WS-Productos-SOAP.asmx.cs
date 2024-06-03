using Datos.DTO;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MidSOAP
{
    /// <summary>
    /// Descripción breve de WS_Productos_SOAP
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_Productos_SOAP : System.Web.Services.WebService
    {
        MiddlewareProductos mdSoap = new MiddlewareProductos();

        [WebMethod]
        public List<DTOProducto> AllProductos()
        {
            return mdSoap.ListaProductosSOAP();
        }
    }
}
