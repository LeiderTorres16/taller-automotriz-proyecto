using System;
using Entidad;

namespace proyecto.models
{
    public class ServicioInputModel
    {
       
        public string Nombre { get; set; } 
        public double  Precio  { get; set; } 
    }
    public class ServicioViewModel : ServicioInputModel
    { 
        public int Id {get ; set; }
        public ServicioViewModel(Servicio servicio)
        {
            Id = servicio.Id;
            Nombre = servicio.Nombre;
            Precio  =servicio.Precio;
        }
    }
}
