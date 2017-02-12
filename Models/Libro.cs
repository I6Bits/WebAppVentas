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
        public String Titulo { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public int CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Venta_Detalle_Tmp> Venta_Detalle_Tmps { get; set; }
        public virtual ICollection<Venta_Detalle> Venta_Detalles { get; set; }
    }
}