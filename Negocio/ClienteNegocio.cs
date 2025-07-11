using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accesoDatos;
using Dominio;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT Id, Documento, Nombre, Apellido, Email FROM Clientes");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente c = new Cliente
                    {
                        Id = (int)datos.Lector["Id"],
                        Documento = datos.Lector["Documento"] != DBNull.Value ? (int?)Convert.ToInt32(datos.Lector["Documento"]) : null,
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Apellido = datos.Lector["Apellido"].ToString(),
                        Email = datos.Lector["Email"].ToString()
                    };

                    lista.Add(c);
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

        public Cliente BuscarPorId(int id)
        {
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT Id, Documento, Nombre, Apellido, Email FROM Clientes WHERE Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return new Cliente
                    {
                        Id = (int)datos.Lector["Id"],
                        Documento = datos.Lector["Documento"] != DBNull.Value ? (int?)Convert.ToInt32(datos.Lector["Documento"]) : null,
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Apellido = datos.Lector["Apellido"].ToString(),
                        Email = datos.Lector["Email"].ToString()
                    };
                }

                return null;
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

        public void Agregar(Cliente nuevo)
        {
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("INSERT INTO Clientes (Documento, Nombre, Apellido, Email) VALUES (@documento, @nombre, @apellido, @email)");
                datos.setearParametro("@documento", nuevo.Documento.HasValue ? (object)nuevo.Documento : DBNull.Value);
                datos.setearParametro("@nombre", nuevo.Nombre ?? "");
                datos.setearParametro("@apellido", nuevo.Apellido ?? "");
                datos.setearParametro("@email", nuevo.Email ?? "");

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

        public void Modificar(Cliente cliente)
        {
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("UPDATE Clientes SET Documento = @documento, Nombre = @nombre, Apellido = @apellido, Email = @email WHERE Id = @id");
                datos.setearParametro("@documento", cliente.Documento.HasValue ? (object)cliente.Documento : DBNull.Value);
                datos.setearParametro("@nombre", cliente.Nombre ?? "");
                datos.setearParametro("@apellido", cliente.Apellido ?? "");
                datos.setearParametro("@email", cliente.Email ?? "");
                datos.setearParametro("@id", cliente.Id);

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

        public void Eliminar(int id)
        {
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("DELETE FROM Clientes WHERE Id = @id");
                datos.setearParametro("@id", id);
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