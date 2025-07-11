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
        public int IdCliente { get; set; }
        public int IdProvincia { get; set; }
        public int IdLocalidad { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string CP { get; set; }
    }
}
