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
                datos.setearConsulta("select a.Id as IdLibro,Codigo,Titulo,A.Descripcion,E.Descripcion Editorial,IdEditorial,UrlImagen,Paginas,Stock,Precio,F.Id IdSubGenero,G.Id IdGenero,f.Descripcion DescripcionSubGenero,G.Descripcion DescripcionGenero  from Libros A join Editoriales E on E.Id = A.IdEditorial join SubGeneros F on A.IdSubGenero = F.Id join Generos  G on F.IdGenero = g.Id");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    //---------Libro
                    Libro aux = new Libro();
                    aux.Id = (int)datos.Lector["IdLibro"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Paginas = (int)datos.Lector["Paginas"];
                    aux.Stock = (int)datos.Lector["Stock"];
                    //---------Autor
                    AutorNegocio Autor = new AutorNegocio();
                    aux.Autores = Autor.ListarAutores(aux.Id);
                    //---------Imagen
                    aux.Imagen = (string)datos.Lector["UrlImagen"];
                    //----------Editorial
                    aux.Editorial = new Editorial
                    {
                        Id = (int)datos.Lector["IdEditorial"],
                        Descripcion = (string)datos.Lector["Editorial"]
                    };
                    aux.Genero = new Genero
                    {
                        Id = (int)datos.Lector["IdGenero"],
                        IdSubgenero = (int)datos.Lector["IdSubGenero"],
                        DescripcionGenero = (string)datos.Lector["DescripcionGenero"],
                        DescripcionSubGenero = (string)datos.Lector["DescripcionSubGenero"]
                    };
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
        //public bool Validar(Libro nuevo)
        //{
        //    try
        //    {
        //        if nuevo.
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public List<Libro> Listar(string filtro)
        {
            List<Libro> lista = new List<Libro>();
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("select a.Id as IdLibro,Codigo,Titulo,A.Descripcion,E.Descripcion Editorial,IdEditorial,UrlImagen,Paginas,Stock,Precio,F.Id IdSubGenero,G.Id IdGenero,f.Descripcion DescripcionSubGenero,G.Descripcion DescripcionGenero  from Libros A join Editoriales E on E.Id = A.IdEditorial join SubGeneros F on A.IdSubGenero = F.Id join Generos  G on F.IdGenero = g.Id where lower(Titulo) like @filtro;");
                datos.setearParametro("@filtro", "%" + filtro.ToLower() + "%");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    //---------Libro
                    Libro aux = new Libro();
                    aux.Id = (int)datos.Lector["IdLibro"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Paginas = (int)datos.Lector["Paginas"];
                    aux.Stock = (int)datos.Lector["Stock"];
                    //---------Autor
                    AutorNegocio Autor = new AutorNegocio();
                    aux.Autores = Autor.ListarAutores(aux.Id);
                    //---------Imagen
                    aux.Imagen = (string)datos.Lector["UrlImagen"];
                    //----------Editorial
                    aux.Editorial = new Editorial
                    {
                        Id = (int)datos.Lector["IdEditorial"],
                        Descripcion = (string)datos.Lector["Editorial"]
                    };
                    aux.Genero = new Genero
                    {
                        Id = (int)datos.Lector["IdGenero"],
                        IdSubgenero = (int)datos.Lector["IdSubGenero"],
                        DescripcionGenero = (string)datos.Lector["DescripcionGenero"],
                        DescripcionSubGenero = (string)datos.Lector["DescripcionSubGenero"]
                    };
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

        public void Agregar(Libro nuevo)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                //datos.setearConsulta("insert into articulos (Codigo, Nombre, Descripcion) values ('" + nuevo.codigo + "','" + nuevo.nombre + "','" + nuevo.descripcion + "');");
                //datos.setearConsulta("insert into articulos (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) values ('" + nuevo.codigo + "','" + nuevo.nombre + "','" + nuevo.descripcion + "'," + nuevo.marca.idMarca + "," + nuevo.categoria.idCategoria + "," + nuevo.precio + ")");
                datos.setearConsulta("insert into libros (Codigo, Titulo, Descripcion, IdSubGenero, Paginas) values (@Codigo,@Titulo,@Descripcion,@IdSubGenero,@Paginas)");
                datos.setearParametro("Codigo", nuevo.Codigo);
                datos.setearParametro("Titulo", nuevo.Titulo);
                datos.setearParametro("Descripcion", nuevo.Descripcion);
                datos.setearParametro("IdSubgenero", nuevo.Genero.IdSubgenero);
                datos.setearParametro("Paginas", nuevo.Paginas);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
