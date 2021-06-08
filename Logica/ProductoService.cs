using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    public class ProductoService
    {
        private readonly TallerContext _context;
        public ProductoService(TallerContext context)
        {
            _context = context;
        }
          public GuardarProductoResponse GuardarProducto(Producto producto)
        {
            try
            {
                _context.Productos.Add(producto);
                _context.SaveChanges();
                return new GuardarProductoResponse(producto);
            }
            catch (Exception e)
            {
                return new GuardarProductoResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }
           public ConsultaProductoResponse Consultar()
        {
            try
            {
                List<Producto> productos = _context.Productos.ToList();
                if(productos == null){
                    return new ConsultaProductoResponse(productos);
                }
                return new ConsultaProductoResponse(productos);
            }
            catch (Exception e)
            {
                return new ConsultaProductoResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }
    }
        public class GuardarProductoResponse
    {
        public Producto Producto { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public GuardarProductoResponse(Producto producto)
        {
            Producto = producto;
            Error = false;
        }

        public GuardarProductoResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
      public class ConsultaProductoResponse
    {
        public List<Producto> Productos { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public ConsultaProductoResponse(List<Producto> productos)
        {
            Productos = productos;
            Error = false;
        }

        public ConsultaProductoResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
