using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accesoDatos;
using Dominio;

namespace Negocio
{
    public class EditorialNegocio
    {
        public List<Editorial> ListarEditorial()
        {
            List<Editorial> lista = new List<Editorial>();
            ConexionDB marcas = new ConexionDB();
            marcas.setearConsulta("select Id,Descripcion,CASE WHEN DeletedAt IS NULL THEN 'Activo' ELSE 'Inactivo' END AS Estado from Editoriales;");
            marcas.ejecutarLectura();
            try
            {
                while (marcas.Lector.Read())
                {
                    Editorial aux = new Editorial();
                    aux.Id = (int)marcas.Lector["Id"];
                    aux.Descripcion = (string)marcas.Lector["Descripcion"];
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
        public List<Editorial> ListarEditorial(string filtro)
        {
            List<Editorial> lista = new List<Editorial>();
            ConexionDB marcas = new ConexionDB();
            marcas.setearConsulta("select Id, Descripcion,CASE WHEN DeletedAt IS NULL THEN 'Activo' ELSE 'Inactivo' END AS Estado from Editoriales where lower(Descripcion) like @filtro;");
            marcas.setearParametro("@filtro", "%" + filtro.ToLower() + "%");
            marcas.ejecutarLectura();
            try
            {
                while (marcas.Lector.Read())
                {
                    Editorial aux = new Editorial();
                    aux.Id = (int)marcas.Lector["Id"];
                    aux.Descripcion = (string)marcas.Lector["Descripcion"];
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
            datos.setearConsulta("UPDATE Editoriales SET Descripcion = @desc, UpdatedAt = SYSDATETIME() WHERE Id = @id and @desc not in (select descripcion from Editoriales)");
            datos.setearParametro("@desc", descripcion);
            datos.setearParametro("@id", id);
            datos.ejecutarAccion();
        }
        public void Desactivar(int id)
        {
            ConexionDB datos = new ConexionDB();
            datos.setearConsulta("delete from Editoriales WHERE Id = @id");
            datos.setearParametro("@id", id);
            datos.ejecutarAccion();
        }
        public void Agregar(string descripcion)
        {
            ConexionDB datos = new ConexionDB();
            datos.setearConsulta("INSERT INTO Editoriales (Descripcion, CreatedAt) VALUES (@desc, SYSDATETIME())");
            datos.setearParametro("@desc", descripcion);
            datos.ejecutarAccion();
        }
        public bool Existe(string descripcion)
        {
            ConexionDB datos = new ConexionDB();
            datos.setearConsulta("SELECT cast(max(CASE WHEN LOWER(TRIM(Descripcion)) = @desc THEN 1 ELSE 0 END) as bit) AS Existe FROM Editoriales");
            datos.setearParametro("@desc", descripcion);
            datos.ejecutarLectura();
            if (datos.Lector.Read())
                return (bool)datos.Lector["Existe"];
            return false;
        }
        public void Activar(int id)
        {
            ConexionDB datos = new ConexionDB();
            datos.setearConsulta("UPDATE Editoriales SET DeletedAt = null WHERE Id = @id");
            datos.setearParametro("@id", id);
            datos.ejecutarAccion();
        }
    }
}

