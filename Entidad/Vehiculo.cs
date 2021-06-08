using System;
using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    public class Vehiculo
    {
        [Key]
        public string Placa {get;set;}
        public string ClienteId {get; set; }
        public Cliente cliente { get; set; }
        public string Tipo { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string Marca { get; set; }
    }
}
