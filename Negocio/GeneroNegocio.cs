using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using accesoDatos;
using Dominio;

namespace Negocio
{
    public class GeneroNegocio
    {
        public List<Genero> ListarGenero()
        {
            List<Genero> lista = new List<Genero>();
            ConexionDB marcas = new ConexionDB();
            marcas.setearConsulta("select Id,IdGenero,a.Descripcion DescripcionSubGenero,b.Descripcion DescripcionGenero from SubGeneros A join Generos B on A.IdGenero = B.Id;");
            marcas.ejecutarLectura();
            try
            {
                while (marcas.Lector.Read())
                {
                    Genero aux = new Genero();
                    aux.Id = (int)marcas.Lector["IdGenero"];
                    aux.IdSubgenero = (int)marcas.Lector["Id"];
                    aux.DescripcionGenero = (string)marcas.Lector["DescripcionGenero"];
                    aux.DescripcionSubGenero = (string)marcas.Lector["DescripcionSubGenero"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
