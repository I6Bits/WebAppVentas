using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppVentas.Models
{
    public class Venta_Detalle_Tmp
    {
        [Key]
        public int Venta_Detalle_Tmp_ID { get; set; }

        [Required(ErrorMessage = "{0} requerida")]
        public int Cantidad { get; set; }
        public int ClienteID { get; set; }
        public int LibroID { get; set; }
        public virtual Libro Libro { get; set; }
        public virtual Cliente Cliente { get; set; }
        [NotMapped]
        public String Subtotal { get { return (Cantidad * Libro.Precio)+""; } }
    }
}