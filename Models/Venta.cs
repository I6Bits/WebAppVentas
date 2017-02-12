using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppVentas.Models
{
    public class Venta
    {
        [Key]
        public int VentaID { get; set; }
        public DateTime F_Compra { get; set; }
        public int UsuarioID { get; set; }
        public float Subtotal { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Venta_Detalle> Venta_Detalles { get; set; }
    }
}