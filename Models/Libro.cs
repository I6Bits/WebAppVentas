using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppVentas.Models
{
    public class Libro
    {
        [Key]
        public int LibroID { get; set; }
        [Required(ErrorMessage = "{0} requerido")]
        public String Titulo { get; set; }
        [Required(ErrorMessage = "{0} requerido")]
        public int Stock { get; set; }
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Categoria requerida")]
        public int CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Venta_Detalle_Tmp> Venta_Detalle_Tmps { get; set; }
        public virtual ICollection<Venta_Detalle> Venta_Detalles { get; set; }
    }
}