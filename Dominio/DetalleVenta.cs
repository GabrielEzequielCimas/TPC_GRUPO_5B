using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DetalleVenta
    {
        public Libro Libro { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
