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
        //public List<Genero> ListarGenero()
        //{
        //    List<Genero> lista = new List<Genero>();
        //    ConexionDB marcas = new ConexionDB();
        //    marcas.setearConsulta("select Id,IdGenero,a.Descripcion DescripcionSubGenero,b.Descripcion DescripcionGenero from SubGeneros A join Generos B on A.IdGenero = B.Id;");
        //    marcas.ejecutarLectura();
        //    try
        //    {
        //        while (marcas.Lector.Read())
        //        {
        //            Genero aux = new Genero();
        //            aux.Id = (int)marcas.Lector["IdGenero"];
        //            aux.IdSubgenero = (int)marcas.Lector["Id"];
        //            aux.DescripcionGenero = (string)marcas.Lector["DescripcionGenero"];
        //            aux.DescripcionSubGenero = (string)marcas.Lector["DescripcionSubGenero"];
        //            lista.Add(aux);
        //        }
        //        return lista;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        public List<Genero> ListarGenero()
        {
            List<Genero> lista = new List<Genero>();
            ConexionDB marcas = new ConexionDB();
            marcas.setearConsulta("select Id, Descripcion,CASE WHEN DeletedAt IS NULL THEN 'Activo' ELSE 'Inactivo' END AS Estado from Generos");
            marcas.ejecutarLectura();
            try
            {
                while (marcas.Lector.Read())
                {
                    Genero aux = new Genero();
                    aux.Id = (int)marcas.Lector["Id"];
                    aux.DescripcionGenero = (string)marcas.Lector["Descripcion"];
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
        public List<Genero> ListarSubGenero(int IdGenero)
        {
            List<Genero> lista = new List<Genero>();
            ConexionDB marcas = new ConexionDB();
            marcas.setearConsulta("select IdGenero, Descripcion, Id from SubGeneros where IdGenero = @IdGenero");
            marcas.setearParametro("@IdGenero", IdGenero);
            marcas.ejecutarLectura();
            try
            {
                while (marcas.Lector.Read())
                {
                    Genero aux = new Genero();
                    aux.Id = (int)marcas.Lector["IdGenero"];
                    aux.DescripcionSubGenero = (string)marcas.Lector["Descripcion"];
                    aux.IdSubgenero = (int)marcas.Lector["Id"];
                    //aux.Estado = (string)marcas.Lector["Estado"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Genero> ListarSubGenero()
        {
            List<Genero> lista = new List<Genero>();
            ConexionDB marcas = new ConexionDB();
            marcas.setearConsulta("select IdGenero, Descripcion, Id from SubGeneros");
            marcas.ejecutarLectura();
            try
            {
                while (marcas.Lector.Read())
                {
                    Genero aux = new Genero();
                    aux.Id = (int)marcas.Lector["IdGenero"];
                    aux.DescripcionSubGenero = (string)marcas.Lector["Descripcion"];
                    aux.IdSubgenero = (int)marcas.Lector["Id"];
                    //aux.Estado = (string)marcas.Lector["Estado"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Genero> ListarGenero(string filtro)
        {
            List<Genero> lista = new List<Genero>();
            ConexionDB marcas = new ConexionDB();
            marcas.setearConsulta("select Id, Descripcion,CASE WHEN DeletedAt IS NULL THEN 'Activo' ELSE 'Inactivo' END AS Estado from Generos where lower(Descripcion) like @filtro;");
            marcas.setearParametro("@filtro", "%" + filtro.ToLower() + "%");
            marcas.ejecutarLectura();
            try
            {
                while (marcas.Lector.Read())
                {
                    Genero aux = new Genero();
                    aux.Id = (int)marcas.Lector["Id"];
                    aux.DescripcionGenero = (string)marcas.Lector["Descripcion"];
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

        public void Modificar(int id, string descripcion)
        {
            ConexionDB datos = new ConexionDB();
            datos.setearConsulta("UPDATE Generos SET Descripcion = @desc, UpdatedAt = SYSDATETIME() WHERE Id = @id and @desc not in (select descripcion from Generos)");
            datos.setearParametro("@desc", descripcion);
            datos.setearParametro("@id", id);
            datos.ejecutarAccion();
        }
        public void Desactivar(int id)
        {
            ConexionDB datos = new ConexionDB();
            datos.setearConsulta("update Generos set DeletedAt = SYSDATETIME() WHERE Id = @id");
            datos.setearParametro("@id", id);
            datos.ejecutarAccion();
        }
        public void Agregar(string descripcion)
        {
            ConexionDB datos = new ConexionDB();
            datos.setearConsulta("INSERT INTO Generos (Descripcion, CreatedAt) VALUES (@desc, SYSDATETIME())");
            datos.setearParametro("@desc", descripcion);
            datos.ejecutarAccion();
        }
        public bool Existe(string descripcion)
        {
            ConexionDB datos = new ConexionDB();
            datos.setearConsulta("SELECT cast(max(CASE WHEN LOWER(TRIM(Descripcion)) = @desc THEN 1 ELSE 0 END) as bit) AS Existe FROM Generos");
            datos.setearParametro("@desc", descripcion);
            datos.ejecutarLectura();
            if (datos.Lector.Read())
                return (bool)datos.Lector["Existe"];
            return false;
        }
        public void Activar(int id)
        {
            ConexionDB datos = new ConexionDB();
            datos.setearConsulta("UPDATE Generos SET DeletedAt = null WHERE Id = @id");
            datos.setearParametro("@id", id);
            datos.ejecutarAccion();
        }
    }
}
