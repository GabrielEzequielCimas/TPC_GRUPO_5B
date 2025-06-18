using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accesoDatos;
using Dominio;

namespace Negocio
{
    internal class AutorNegocio
    {
        public List<Autor> ListarAutor()
        {
            List<Autor> lista = new List<Autor>();
            ConexionDB marcas = new ConexionDB();
            marcas.setearConsulta("select Id,Descripcion from autores;");
            marcas.ejecutarLectura();
            try
            {
                while (marcas.Lector.Read())
                {
                    Autor aux = new Autor();
                    aux.Id = (int)marcas.Lector["Id"];
                    aux.Nombre = (string)marcas.Lector["Nombre"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Autor> ListarAutores(int idLibro)
        {
            List<Autor> lista = new List<Autor>();
            ConexionDB imagenes = new ConexionDB();
            //imagenes.setearConsulta("select ImagenUrl from Imagenes where IdArticulo = " + idArticulo + ";");
            imagenes.setearConsulta("select IdAutor,Nombre from AutoresLibro A join Autores B on a.IdAutor = b.Id where IdLibro = @IdLibro;");
            imagenes.setearParametro("IdLibro", idLibro);
            imagenes.ejecutarLectura();
            try
            {
                //int contador = 0;
                while (imagenes.Lector.Read())
                {
                    Autor aux = new Autor();
                    aux.Id = (int)imagenes.Lector["IdAutor"];
                    aux.Nombre = (string)imagenes.Lector["Nombre"];
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
