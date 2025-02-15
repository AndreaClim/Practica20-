using System.ComponentModel.DataAnnotations;
namespace Practica.Models
{
    public class autores
    {
        [Key]
        public int autorId { get; set; }
        public string nombre { get; set; }
        public string nacionalidad { get; set; }
    }
}

