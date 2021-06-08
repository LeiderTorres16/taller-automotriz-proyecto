using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Servicio
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get ; set; }  
        public string Nombre {get; set;} 
        public double Precio { get; set; }
    }
}
