using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Mvc;
using proyecto.models;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class ProductoController : ControllerBase
    {
        private ProductoService productoservice;
        public ProductoController(TallerContext context)
        {
            productoservice = new ProductoService(context); 
        }
        [HttpPost]
        public ActionResult<ProductoViewModel> PostProducto(ProductoInputModel productoInput)
        {
            var producto = MapearProducto(productoInput);
            var response = productoservice.GuardarProducto(producto);
            if (!response.Error)
            {
                var ProductoViewModel = new ProductoViewModel(producto);
                return Ok(ProductoViewModel);
            }
            return BadRequest(response.Mensaje);
        }


        [HttpGet]
        public ActionResult<IEnumerable<ProductoViewModel>> GetProducto()
        {
            var response = productoservice.Consultar();
            if (!response.Error)
            {
                var ProductoViewModels = response.Productos.Select(p => new ProductoViewModel(p));
                return Ok(ProductoViewModels);
            }
            return BadRequest(response.Mensaje);
        }

        private Producto MapearProducto(ProductoInputModel productoInput)
        {
            var producto = new Producto()
            {
                Nombre = productoInput.Nombre,
                Cantidad = productoInput.Cantidad,
                Precio = productoInput.Precio,
            };
            return producto;
        }
    }
}
