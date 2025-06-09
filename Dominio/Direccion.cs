using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Direccion
    {
        string Calle { get; set; }
        int Numero { get; set; }
        string Ciudad { get; set; }
        int? Piso { get; set; }
        string CP { get; set; }
    }
}
