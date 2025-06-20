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
        public bool Login(string email, string password, out Usuario usuario)
        {
            usuario = null;
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT Id, Username, Pass, Rol FROM Usuarios WHERE Username = @user AND Pass = @pass");
                datos.setearParametro("@user", email);
                datos.setearParametro("@pass", password);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    string rolTexto = datos.Lector["Rol"].ToString();
                    TipoUsuario tipo = rolTexto == "Administrador" ? TipoUsuario.ADMIN : TipoUsuario.CLIENTE;

                    usuario = new Usuario(
                        datos.Lector["Username"].ToString(),
                        datos.Lector["Pass"].ToString(),
                        tipo
                    )
                    {
                        Id = (int)datos.Lector["Id"]
                    };

                    return true;
                }

                return false;
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
