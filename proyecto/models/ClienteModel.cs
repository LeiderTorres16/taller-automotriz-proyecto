using System;
using Entidad;

namespace proyecto.models
{
    public class ClienteInputModel
    {
         public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
    }

    public class ClienteViewModel: ClienteInputModel
    {
        public ClienteViewModel(Cliente cliente)
        {
            Identificacion= cliente.Identificacion;
            Nombre= cliente.Nombre;
            Apellido= cliente.Apellido;
            Edad = cliente.Edad;
            Telefono = cliente.Telefono;
            Sexo= cliente.Sexo;
        }
    }
}
