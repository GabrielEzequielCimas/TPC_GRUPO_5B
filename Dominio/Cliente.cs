using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente
    {
        int Id { get; set; }
        int Documento { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        string Email { get; set; }
        public List<Direccion> Direccion { get; set; }
    }
}
