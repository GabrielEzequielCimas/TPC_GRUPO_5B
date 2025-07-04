using accesoDatos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public Usuario Loguear(string username, string password)
        {
            ConexionDB datos = new ConexionDB();
            Usuario usuario = null;

            try
            {
                datos.setearConsulta(@"
            SELECT 
                U.Id AS UsuarioId,
                U.Username,
                U.Pass,
                U.Rol,
                C.Id AS ClienteId,
                C.Documento,
                C.Nombre,
                C.Apellido,
                C.Email
            FROM Usuarios U
            LEFT JOIN Clientes C ON U.IdCliente = C.Id
            WHERE U.Username = @username AND U.Pass = @password
        ");
                datos.setearParametro("@username", username);
                datos.setearParametro("@password", password);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    usuario = new Usuario
                    {
                        Id = (int)datos.Lector["UsuarioId"],
                        User = (string)datos.Lector["Username"],
                        Password = (string)datos.Lector["Pass"],
                        TipoUsuario = (datos.Lector["Rol"].ToString() == "Administrador") ? TipoUsuario.ADMIN : TipoUsuario.CLIENTE,
                        Cliente = datos.Lector["ClienteId"] != DBNull.Value ? new Cliente
                        {
                            Id = Convert.ToInt32(datos.Lector["ClienteId"]),
                            Documento = datos.Lector["Documento"] != DBNull.Value ? Convert.ToInt32(datos.Lector["Documento"]) : 0,
                            Nombre = datos.Lector["Nombre"] != DBNull.Value ? datos.Lector["Nombre"].ToString() : string.Empty,
                            Apellido = datos.Lector["Apellido"] != DBNull.Value ? datos.Lector["Apellido"].ToString() : string.Empty,
                            Email = datos.Lector["Email"] != DBNull.Value ? datos.Lector["Email"].ToString() : string.Empty
                        } : null
                    };
                }
                return usuario;
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

        public void Registrar(Usuario nuevo)
        {
            ConexionDB datos = new ConexionDB();

            try
            {
                string rolTexto = nuevo.TipoUsuario == TipoUsuario.ADMIN ? "Administrador" : "Cliente";

                datos.setearConsulta("INSERT INTO Usuarios (Username, Pass, Rol) VALUES (@user, @pass, @rol)");
                datos.setearParametro("@user", nuevo.User);
                datos.setearParametro("@pass", nuevo.Password);
                datos.setearParametro("@rol", rolTexto);
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

        public bool ExisteUsuario(string email)
        {
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT Id FROM Usuarios WHERE Username = @user");
                datos.setearParametro("@user", email);
                datos.ejecutarLectura();

                return datos.Lector.Read();
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
