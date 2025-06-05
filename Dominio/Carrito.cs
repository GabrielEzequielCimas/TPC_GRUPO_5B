using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Carrito
    {
        public List<Libro> libros;
        public int Cantidad { get; set; }
        public float Subtotal { get; set; }
    }
}
