using AccesoDatos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace API_SOA
{
    /// <summary>
    /// Descripción breve de ServiciosClientes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiciosClientes : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Cliente> Clientes()
        {
            ClienteNegocio datos = new ClienteNegocio();
            List<Cliente> lista = datos.ListarClientes();
            return lista;
        }
    }
}
