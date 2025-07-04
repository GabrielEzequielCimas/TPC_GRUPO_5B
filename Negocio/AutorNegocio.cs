using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accesoDatos;
using Dominio;

namespace Negocio
{
    public class AutorNegocio
    {
        public List<Autor> ListarAutor()
        {
            List<Autor> lista = new List<Autor>();
            ConexionDB marcas = new ConexionDB();
            marcas.setearConsulta("select Id,Nombre,CASE WHEN DeletedAt IS NULL THEN 'Activo' ELSE 'Inactivo' END AS Estado from autores;");
            marcas.ejecutarLectura();
            try
            {
                while (marcas.Lector.Read())
                {
                    Autor aux = new Autor();
                    aux.Id = (int)marcas.Lector["Id"];
                    aux.Nombre = (string)marcas.Lector["Nombre"];
                    aux.Estado = (string)marcas.Lector["Estado"];
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
                imagenes.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Autor> ListarAutor(string filtro)
        {
            List<Autor> lista = new List<Autor>();
            ConexionDB marcas = new ConexionDB();
            marcas.setearConsulta("select Id, Nombre,CASE WHEN DeletedAt IS NULL THEN 'Activo' ELSE 'Inactivo' END AS Estado from Autores where lower(Nombre) like @filtro;");
            marcas.setearParametro("@filtro", "%" + filtro.ToLower() + "%");
            marcas.ejecutarLectura();
            try
            {
                while (marcas.Lector.Read())
                {
                    Autor aux = new Autor();
                    aux.Id = (int)marcas.Lector["Id"];
                    aux.Nombre = (string)marcas.Lector["Nombre"];
                    aux.Estado = (string)marcas.Lector["Estado"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Modificar(int id, string Nombre)
        {
            ConexionDB datos = new ConexionDB();
            datos.setearConsulta("UPDATE Autores SET Nombre = @desc, UpdatedAt = SYSDATETIME() WHERE Id = @id and @desc not in (select Nombre from Autores)");
            datos.setearParametro("@desc", Nombre);
            datos.setearParametro("@id", id);
            datos.ejecutarAccion();
        }
        public void Desactivar(int id)
        {
            ConexionDB datos = new ConexionDB();
            datos.setearConsulta("update Autores set DeletedAt = SYSDATETIME() WHERE Id = @id");
            datos.setearParametro("@id", id);
            datos.ejecutarAccion();
        }
        public void Agregar(string Nombre)
        {
            ConexionDB datos = new ConexionDB();
            datos.setearConsulta("INSERT INTO Autores (Nombre, CreatedAt) VALUES (@desc, SYSDATETIME())");
            datos.setearParametro("@desc", Nombre);
            datos.ejecutarAccion();
        }
        public int Existe(string Nombre)
        {
            ConexionDB datos = new ConexionDB();
            datos.setearConsulta("SELECT max(Id)IdAutor FROM Autores where LOWER(TRIM(Nombre)) = @desc");
            datos.setearParametro("@desc", Nombre);
            datos.ejecutarLectura();
            if (datos.Lector.Read())
                return (int)datos.Lector["IdAutor"];
            return 0;
        }
        public void Activar(int id)
        {
            ConexionDB datos = new ConexionDB();
            datos.setearConsulta("UPDATE Autores SET DeletedAt = null WHERE Id = @id");
            datos.setearParametro("@id", id);
            datos.ejecutarAccion();
        }
        public bool Validar(int id, string Nombre)
        {
            ConexionDB datos = new ConexionDB();
            datos.setearConsulta("SELECT 1 FROM Autores WHERE Id <> @id AND Nombre = @Nombre");
            datos.setearParametro("@id", id);
            datos.setearParametro("@Nombre", Nombre);
            datos.ejecutarLectura();
            if (datos.Lector.Read() && !datos.Lector.IsDBNull(0))
            {
                return false;
            }
            return true;
        }
    }
}
