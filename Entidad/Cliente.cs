using System;
using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    public class Cliente
    {
        [Key]
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
    }
}
