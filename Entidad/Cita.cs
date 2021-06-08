using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Cita
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        [Required]
        public string clienteId { get; set;}
        public Cliente cliente { get; set; }
        
        [Required]
        public string vehiculoPlaca { get; set;}
        public Vehiculo Vehiculo { get; set; }
        //public List<Servicio> servicios { get; set;} 
        public DateTime fecha { get; set;}
    }
}
