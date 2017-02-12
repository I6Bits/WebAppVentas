using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppVentas.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaID { get; set; }
        [Required(ErrorMessage = "{0} requerido")]
        public String Nombre { get; set; }
        public virtual ICollection<Libro> Libros { get; set; }
    }
}