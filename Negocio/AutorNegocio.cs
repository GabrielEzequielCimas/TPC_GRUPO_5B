using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accesoDatos;
using Dominio;

namespace Negocio
{
    internal class AutorNegocio
    {
        public List<Autor> ListarGenero()
        {
            List<Autor> lista = new List<Autor>();
            ConexionDB marcas = new ConexionDB();
            marcas.setearConsulta("select Id,Descripcion from autores;");
            marcas.ejecutarLectura();
            try
            {
                while (marcas.Lector.Read())
                {
                    Autor aux = new Autor();
                    aux.Id = (int)marcas.Lector["Id"];
                    aux.Nombre = (string)marcas.Lector["Nombre"];
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
