using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class ProductosTiendaMil
    {
        public int idProducto {  get; set; }
        public string nombre { get; set; }
        public bool iva {  get; set; }
        public double precio_unitario { get; set; }

        public ProductosTiendaMil() { }

        public ProductosTiendaMil(string datoJson)
        {
            JObject dato = JObject.Parse(datoJson);
            idProducto = (int) dato["idProducto"];
            nombre = (string) dato["nombre"];
            iva = (bool)dato["iva"];
            precio_unitario = (double)dato["precio_unitario"];
        }
    }
}
