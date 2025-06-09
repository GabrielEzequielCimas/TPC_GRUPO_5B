using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Libro
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Autor Autor { get; set; }
        public Editorial Editorial { get; set; }
        public Genero Genero { get; set; }
        public List<Imagen> Imagenes { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
    }
}
