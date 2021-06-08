using System;
using Entidad;

namespace proyecto.models
{
    public class EmpleadoInputModel
    {
         public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
    }
    public class EmpleadoViewModel : EmpleadoInputModel
    {
        public EmpleadoViewModel(Empleado empleado)
        {
            Identificacion= empleado.Identificacion;
            Nombre= empleado.Nombre;
            Apellido= empleado.Apellido;
            Edad = empleado.Edad;
            Telefono = empleado.Telefono;
            Sexo= empleado.Sexo;
        }
    }
}
