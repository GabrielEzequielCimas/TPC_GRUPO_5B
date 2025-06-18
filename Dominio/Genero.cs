using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Genero
    {
        public int Id { get; set; }
        public int IdSubgenero { get; set; }
        public string DescripcionGenero { get; set; }
        public string DescripcionSubGenero { get; set; }
    }
}
