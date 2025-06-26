using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public int IdCliente {  get; set; }
        public Carrito Carrito { get; set; }
        public DateTime FechaCompra { get; set; }
        //
    }
}
