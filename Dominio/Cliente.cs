using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Cliente
    {
        int Id { get; set; }
        int Documento { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        string Email { get; set; }
        string Direccion { get; set; }
        string Ciudad { get; set; }
        //localidad clase, ciudad tambien ver si pueden tener mas
        string CP { get; set; }
    }
}
