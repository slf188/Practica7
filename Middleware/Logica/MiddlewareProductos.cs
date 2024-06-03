using Datos.DTO;
using Datos.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class MiddlewareProductos
    {
        // referencia a los servicios SOAP de cada base de datos
        servicioTienda.WebServiceVentas webTiendaMil = new servicioTienda.WebServiceVentas();
        serviceSuperX.serviceVentas2 webSuperX = new serviceSuperX.serviceVentas2();

        //Listado de los productos de la base de datos servicios
        public List<servicioTienda.Producto> ListaTiendaMil()
        {
            return webTiendaMil.ListarProductos().ToList();
        }
        //Listado de los productos de a base de datos ventasBD
        public List<serviceSuperX.Productos> ListarSuperX()
        {
            return webSuperX.ListarProductos().ToList();   
        }
        // Integramos los datos de cada una de las listas SOAP
        public List<DTOProducto> ListaProductosSOAP()
        {
            List<DTOProducto> lista = new List<DTOProducto>();
            foreach (var item in ListaTiendaMil())
            {
                DTOProducto datoProducto = new DTOProducto();
                datoProducto.Id = item.idProducto;
                datoProducto.Name = item.nombre;
                datoProducto.Price = (double) item.precio_unitario;
                if(item.iva == 1)
                    datoProducto.Iva = true;
                else datoProducto.Iva = false;
                datoProducto.Tienda = "Tienda Mil";
                lista.Add(datoProducto);
            }
            foreach (var item in ListarSuperX())
            {
                DTOProducto datoProducto = new DTOProducto();
                datoProducto.Id = item.id;
                datoProducto.Name = item.name;
                datoProducto.Price = (double) item.pvp;
                if (item.impuesto == "1") 
                    datoProducto.Iva = true;
                else 
                    datoProducto.Iva= false;
                datoProducto.Tienda = "SuperX";
                lista.Add(datoProducto);
            }

            return lista;
        }

        // listado de productos de la base de datos VentasBD (REST)
        public List<ProductosSuperX> listarProductosSuperX()
        {
            string url = "http://localhost:50571/api/productos";
            WebClient respuesta = new WebClient();
            string get = respuesta.DownloadString(new Uri(url));
            List<ProductosSuperX> listaSuperX = JsonConvert.DeserializeObject<List<ProductosSuperX>>(get);
            return listaSuperX;
        }

        // listado de productos de la base de datos servicios (REST)
        public List<ProductosTiendaMil> listarProductosTiendaMil()
        {
            string url = "http://localhost:53365/api/Productos";
            WebClient respuesta = new WebClient();
            string get = respuesta.DownloadString(new Uri(url));
            List<ProductosTiendaMil> listaTiendaMil = JsonConvert.DeserializeObject<List<ProductosTiendaMil>>(get);
            return listaTiendaMil;
        }

        // Integramos los datos de cada una de las listas REST

        public List<DTOProducto>ListaProductosREST() {
            List<DTOProducto> listaProductos = new List<DTOProducto>();

            foreach (var item in listarProductosSuperX())
            {
                DTOProducto producto = new DTOProducto();
                producto.Id = item.id;
                producto.Name = item.name;
                producto.Price = item.pvp;
                if(item.impuesto=="1")
                    producto.Iva = true;
                else 
                    producto.Iva = false;
                producto.Tienda = "Super X";
                listaProductos.Add(producto);
            }
            foreach (var item in listarProductosTiendaMil())
            {
                DTOProducto producto = new DTOProducto();
                producto.Id = item.idProducto;
                producto.Name = item.nombre;
                producto.Price = item.precio_unitario;
                producto.Iva = item.iva;
                producto.Tienda = "Tienda Mil";
                listaProductos.Add(producto);
            }
            return listaProductos;
        }


        public List<DTOProducto> FindByNombre(string nombre)
        {
            List<DTOProducto> listaProductos = new List<DTOProducto>();
            listaProductos = ListaProductosREST().Find(c == );
            return listaProductos;
        }
    }
}
