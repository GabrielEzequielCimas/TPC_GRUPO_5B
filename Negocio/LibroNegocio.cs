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
                datos.setearConsulta("select a.Id as IdLibro,Codigo,Titulo,A.Descripcion,E.Descripcion Editorial,IdEditorial,UrlImagen,Paginas,Stock,Precio,F.Id IdSubGenero,G.Id IdGenero,f.Descripcion DescripcionSubGenero,G.Descripcion DescripcionGenero,case when a.DeletedAt is null then 'Activo' else 'Inactivo' end as Estado  from Libros A join Editoriales E on E.Id = A.IdEditorial join SubGeneros F on A.IdSubGenero = F.Id join Generos  G on F.IdGenero = g.Id");
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
                    aux.Estado = (string)datos.Lector["Estado"];
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

        public List<Libro> ListarPaginado(int skip, int take)
        {
            List<Libro> lista = new List<Libro>();
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta(@" SELECT a.Id AS IdLibro, Codigo, Titulo, A.Descripcion, E.Descripcion AS Editorial, IdEditorial, UrlImagen, Paginas, Stock, Precio, F.Id AS IdSubGenero, G.Id AS IdGenero, F.Descripcion AS DescripcionSubGenero, G.Descripcion AS DescripcionGenero
                                        FROM Libros A
                                        JOIN Editoriales E ON E.Id = A.IdEditorial
                                        JOIN SubGeneros F ON A.IdSubGenero = F.Id
                                        JOIN Generos G ON F.IdGenero = G.Id
                                        ORDER BY Titulo
                                        OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY");
                datos.setearParametro("Skip", skip);
                datos.setearParametro("Take", take);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Libro aux = new Libro();
                    aux.Id = (int)datos.Lector["IdLibro"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Paginas = (int)datos.Lector["Paginas"];
                    aux.Stock = (int)datos.Lector["Stock"];
                    aux.Imagen = (string)datos.Lector["UrlImagen"];

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

                    // Cargar autores
                    AutorNegocio Autor = new AutorNegocio();
                    aux.Autores = Autor.ListarAutores(aux.Id);

                    lista.Add(aux);
                }
                return lista;
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

        public int ContarLibros()
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Libros");
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                    return (int)datos.Lector[0];
                return 0;
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

        public void Activar(int id)
        {
            ConexionDB datos = new ConexionDB();
            datos.setearConsulta("UPDATE Libros SET DeletedAt = null WHERE Id = @id");
            datos.setearParametro("@id", id);
            datos.ejecutarAccion();
        }
        public void Desactivar(int id)
        {
            ConexionDB datos = new ConexionDB();
            datos.setearConsulta("update Libros set DeletedAt = SYSDATETIME() WHERE Id = @id");
            datos.setearParametro("@id", id);
            datos.ejecutarAccion();
        }
        public int Validar(int id, string codigo, string titulo, int idEditorial)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                string consulta = @"
                SELECT 
                    CASE 
                        WHEN Codigo = @Codigo and Id <> @Id THEN 1 
                        WHEN Titulo = @Titulo AND IdEditorial = @IdEditorial and Id <> @Id THEN 2 
                    END AS Respuesta 
                FROM Libros 
                WHERE (Codigo = @Codigo OR (Titulo = @Titulo AND IdEditorial = @IdEditorial)) 
                ORDER BY 1 DESC";

                datos.setearConsulta(consulta);

                datos.setearParametro("@Id", id);
                datos.setearParametro("@Codigo", codigo);
                datos.setearParametro("@Titulo", titulo);
                datos.setearParametro("@IdEditorial", idEditorial);

                datos.ejecutarLectura();
                if (datos.Lector.Read() && !datos.Lector.IsDBNull(0))
                {
                    return Convert.ToInt32(datos.Lector["Respuesta"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return 0;
        }
        public void Agregar(Libro libro)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta(@"
                    INSERT INTO Libros 
                    (Codigo, Titulo, Descripcion, IdSubGenero, IdEditorial, UrlImagen, Paginas, Precio, Stock)
                    VALUES 
                    (@Codigo, @Titulo, @Descripcion, @IdSubGenero, @IdEditorial, @UrlImagen, @Paginas, @Precio, @Stock);
                    SELECT SCOPE_IDENTITY();
                ");

                datos.setearParametro("@Codigo", libro.Codigo);
                datos.setearParametro("@Titulo", libro.Titulo);
                datos.setearParametro("@Descripcion", libro.Descripcion);
                datos.setearParametro("@IdSubGenero", libro.Genero.IdSubgenero);
                datos.setearParametro("@IdEditorial", libro.Editorial.Id);
                datos.setearParametro("@UrlImagen", libro.Imagen);
                datos.setearParametro("@Paginas", libro.Paginas);
                datos.setearParametro("@Precio", libro.Precio);
                datos.setearParametro("@Stock", libro.Stock);
                int idLibro = Convert.ToInt32(datos.ejecutarScalar());

                // Insertar en tabla intermedia Libros_Autores
                foreach (var autor in libro.Autores)
                {
                    datos.setearConsulta("INSERT INTO AutoresLibro (IdLibro, IdAutor) VALUES (@IdLibro, @IdAutor)");
                    datos.setearParametro("@IdLibro", idLibro);
                    datos.setearParametro("@IdAutor", autor.Id);
                    datos.ejecutarAccion();
                }
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
        public void Modificar(Libro libro)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta(@"
            UPDATE Libros
            SET Codigo = @Codigo,
                Titulo = @Titulo,
                Descripcion = @Descripcion,
                IdSubGenero = @IdSubGenero,
                IdEditorial = @IdEditorial,
                UrlImagen = @UrlImagen,
                Paginas = @Paginas,
                Precio = @Precio,
                Stock = @Stock
                WHERE Id = @Id
            ");

                datos.setearParametro("@Id", libro.Id);
                datos.setearParametro("@Codigo", libro.Codigo);
                datos.setearParametro("@Titulo", libro.Titulo);
                datos.setearParametro("@Descripcion", libro.Descripcion);
                datos.setearParametro("@IdSubGenero", libro.Genero.IdSubgenero);
                datos.setearParametro("@IdEditorial", libro.Editorial.Id);
                datos.setearParametro("@UrlImagen", libro.Imagen);
                datos.setearParametro("@Paginas", libro.Paginas);
                datos.setearParametro("@Precio", libro.Precio);
                datos.setearParametro("@Stock", libro.Stock);

                datos.ejecutarAccion();

                // Limpiar autores anteriores
                datos.setearConsulta("DELETE FROM AutoresLibro WHERE IdLibro = @IdLibro");
                datos.setearParametro("@IdLibro", libro.Id);
                datos.ejecutarAccion();

                // Insertar nuevos autores
                foreach (var autor in libro.Autores)
                {
                    datos.setearConsulta("INSERT INTO AutoresLibro (IdLibro, IdAutor) VALUES (@IdLibro, @IdAutor)");
                    datos.setearParametro("@IdLibro", libro.Id);
                    datos.setearParametro("@IdAutor", autor.Id);
                    datos.ejecutarAccion();
                }
                datos.cerrarConexion();
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
