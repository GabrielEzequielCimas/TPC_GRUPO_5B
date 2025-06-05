using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accesoDatos;
using Dominio;

namespace Negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> ListarImagenes(int idArticulo)
        {
            List<Imagen> lista = new List<Imagen>();
            ConexionDB imagenes = new ConexionDB();
            //imagenes.setearConsulta("select ImagenUrl from Imagenes where IdArticulo = " + idArticulo + ";");
            imagenes.setearConsulta("select Id,UrlImagen from Imagenes where IdLibro = @IdLibro;");
            imagenes.setearParametro("IdLibro", idArticulo);
            imagenes.ejecutarLectura();
            try
            {
                //int contador = 0;
                while (imagenes.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.IdImagen = (int)imagenes.Lector["Id"];
                    aux.url = (string)imagenes.Lector["UrlImagen"];
                    aux.IdLibro = idArticulo;
                    //aux.numeroImagen = contador += 1;
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
