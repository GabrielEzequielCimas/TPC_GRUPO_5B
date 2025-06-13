using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accesoDatos;
using Dominio;

namespace Negocio
{
    internal class ClienteNegocio
    {
        public List<Cliente> ListarCliente()
        {
            List<Cliente> lista = new List<Cliente>();
            ConexionDB marcas = new ConexionDB();
            marcas.setearConsulta("select Id,Descripcion from generos;");
            marcas.ejecutarLectura();
            try
            {
                while (marcas.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.Id = (int)marcas.Lector["Id"];
                    aux.Email = (string)marcas.Lector["Descripcion"];
                    aux.Nombre = (string)marcas.Lector["Descripcion"];
                    aux.Apellido = (string)marcas.Lector["Descripcion"];
                    aux.Documento = (int)marcas.Lector["Descripcion"];
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
