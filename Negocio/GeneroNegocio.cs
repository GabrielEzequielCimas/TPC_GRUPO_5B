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
            marcas.setearConsulta("select Id,Descripcion from generos;");
            marcas.ejecutarLectura();
            try
            {
                while (marcas.Lector.Read())
                {
                    Genero aux = new Genero();
                    aux.Id = (int)marcas.Lector["Id"];
                    aux.Descripcion = (string)marcas.Lector["Descripcion"];
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
