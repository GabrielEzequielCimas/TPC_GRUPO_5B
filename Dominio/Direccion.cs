using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Direccion
    {
        public int IdDireccion { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public int? Piso { get; set; }
        public string CP { get; set; }
    }
}
