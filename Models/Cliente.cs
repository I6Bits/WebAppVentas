using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppVentas.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }

        public virtual ICollection<Venta> Ventas { get; set; }
        public virtual ICollection<Venta_Detalle_Tmp> Venta_Detalle_Tmps { get; set; }
    }
}