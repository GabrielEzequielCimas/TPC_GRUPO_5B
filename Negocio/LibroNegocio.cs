using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using accesoDatos;
using System.Text.RegularExpressions;

namespace Negocio
{
    public class LibroNegocio
    {
        public List<Libro> Listar()
        {
            List<Libro> lista = new List<Libro>();
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("select a.Id,Codigo,a.Nombre,a.Descripcion,b.Id as IdEditorial,b.Descripcion as Editorial,c.Id as IdGenero,c.Descripcion as Genero,d.Id as IdAutor,d.Nombre as NombreAutor,Stock,Precio from Libros a join Editoriales b on a.IdEditorial = b.Id join Generos c on a.IdEditorial = c.Id join Autores d on d.Id = a.IdAutor");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Libro aux = new Libro();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Genero = new Genero();
                    aux.Genero.Id = (int)datos.Lector["IdGenero"];
                    aux.Editorial = new Editorial();
                    aux.Editorial.Id = (int)datos.Lector["IdEditorial"];
                    aux.Editorial.Descripcion = (string)datos.Lector["Editorial"];
                    aux.Autor = new Autor();
                    aux.Autor.Id = (int)datos.Lector["IdAutor"];
                    aux.Autor.Nombre = (string)datos.Lector["NombreAutor"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    ImagenNegocio imagen = new ImagenNegocio();
                    aux.Imagenes = imagen.ListarImagenes(aux.Id);
                    lista.Add(aux);
                }
                datos.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
