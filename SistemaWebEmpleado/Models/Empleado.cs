using SistemaWebEmpleado.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaWebEmpleado.Models
{
    [Table("Empleado")]
    public class Empleado
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        public int DNI { get; set; }
        [Required]
        [RegularExpression("[A-Z]{1}[0-9]{5}")]
        public string Legajo { get; set; }
        [CheckValidYearAttribute]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public string Titulo { get; set; }
    }
}
