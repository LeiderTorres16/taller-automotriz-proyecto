using System;
using Entidad;

namespace proyecto.models
{
    public class VehiculoInputModel
    { 
        public string Placa {get;set;}
        public ClienteInputModel Cliente { get; set; } = new ClienteInputModel();
        public string Tipo { get; set; }  
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string Marca { get; set; }
    }

    public class VehiculoViewModel : VehiculoInputModel
    {
        public VehiculoViewModel(Vehiculo vehiculo) 
        {
            Placa = vehiculo.Placa;
            Cliente.Identificacion = vehiculo.cliente.Identificacion;
            Cliente.Nombre = vehiculo.cliente.Nombre;
            Cliente.Apellido = vehiculo.cliente.Apellido;
            Cliente.Edad = vehiculo.cliente.Edad;
            Cliente.Telefono = vehiculo.cliente.Telefono;
            Cliente.Sexo = vehiculo.cliente.Sexo;
            Tipo = vehiculo.Tipo;
            Modelo = vehiculo.Modelo; 
            Color = vehiculo.Color;
            Marca = vehiculo.Marca;
        }
    }
    public class SoloVehiculoInputModel
    {
        public string Placa { get; set; }
        public string ClienteId { get; set; }
        public string Tipo { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string Marca { get; set; }
        public SoloVehiculoInputModel(){}
    }
}
