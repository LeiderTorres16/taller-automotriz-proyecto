using System;
using Entidad;

namespace proyecto.models
{
    public class ProductoInputModel
    {
       
        public string Nombre { get; set; } 
        public int Cantidad { get; set; } 
        public double  Precio  { get; set; } 
    }
    public class ProductoViewModel : ProductoInputModel
    {
        public int Id {get ; set; }
        public ProductoViewModel(Producto producto )
        {
            Id= producto.Id;
            Nombre = producto.Nombre ;
            Cantidad = producto.Cantidad;
            Precio  =producto.Precio;
        }
    }
}
