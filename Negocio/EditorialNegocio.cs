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
        public List<Editorial> ListarGenero()
        {
            List<Editorial> lista = new List<Editorial>();
            ConexionDB marcas = new ConexionDB();
            marcas.setearConsulta("select Id,Descripcion from generos;");
            marcas.ejecutarLectura();
            try
            {
                while (marcas.Lector.Read())
                {
                    Editorial aux = new Editorial();
                    aux.Id = (int)marcas.Lector["Id"];
                    aux.Descripcion = (string)marcas.Lector["Descripcion"];
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

