using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppVentas.Models
{
    public class Venta_Detalle
    {
        [Key]
        public int Venta_Detalle_ID { get; set; }
        public int cantidad { get; set; }
        public int LibroID { get; set; }
        public int VentaID { get; set; }
        public virtual Venta Ventas { get; set; }
        public virtual Libro Libros { get; set; }
    }
}