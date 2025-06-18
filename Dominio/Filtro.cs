using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Filtro
    {
        public int IdAutor {  get; set; }
        public float PrecioMin { get; set; }
        public float PrecioMax { get; set; }
        public int IdGenero { get; set; }
        public int IdSubGenero { get; set; }
    }
}
