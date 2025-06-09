using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ItemCarrito
    {
        public Libro Libro { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio => Libro != null ? Libro.Precio * Cantidad : 0;
    }
}
