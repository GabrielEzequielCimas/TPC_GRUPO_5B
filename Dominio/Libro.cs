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
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public List<Autor> Autores { get; set; }
        public Editorial Editorial { get; set; }
        public Genero Genero { get; set; }
        public string Imagen { get; set; }
        public int Paginas { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
    }
}
