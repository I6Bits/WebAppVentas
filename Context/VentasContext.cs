using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAppVentas.Models;

namespace WebAppVentas.Context
{
    public class VentasContext:DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<WebAppVentas.Models.Libro> Libroes { get; set; }

        public System.Data.Entity.DbSet<WebAppVentas.Models.Venta_Detalle_Tmp> Venta_Detalle_Tmp { get; set; }
    }
}