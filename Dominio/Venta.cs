using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public int IdLibro { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public DateTime FechaCompra { get; set; }
    }
}
