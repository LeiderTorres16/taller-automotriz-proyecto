using System;
using Entidad;

namespace proyecto.models
{
    public class CitaInputModel
    { 
        public ClienteInputModel cliente { get; set; } 
        public DateTime fecha { get; set;}
        public SoloVehiculoInputModel vehiculo { get ; set;}
    }

    public class CitaViewModel :CitaInputModel
    {

        public CitaViewModel(Cita cita)
        {
            cliente = new ClienteInputModel()
            {
            Identificacion = cita.cliente.Identificacion,
            Nombre = cita.cliente.Nombre,
            Apellido = cita.cliente.Apellido,
            Edad = cita.cliente.Edad,
            Telefono = cita.cliente.Telefono,
            Sexo = cita.cliente.Sexo
            };
            vehiculo = new SoloVehiculoInputModel(){
                Placa = cita.Vehiculo.Placa,
                ClienteId = cita.cliente.Identificacion,
                Tipo = cita.Vehiculo.Tipo,
                Modelo = cita.Vehiculo.Modelo,
                Color = cita.Vehiculo.Color,
                Marca = cita.Vehiculo.Marca
            };
            fecha = cita.fecha;
        }
    }
    
}
