using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Libros
    {
        int Id { get; set; }
        string Codigo { get; set; }
        string Nombre { get; set; }
        string Descripcion { get; set; }
        Editorial editorial { get; set; }
        Genero genero { get; set; }
        Imagen imagen { get; set; }
        int StockActual { get; set; }
        int StockMinimo { get; set; }
        float PorcentajeGanancia { get; set; }
    }
}
