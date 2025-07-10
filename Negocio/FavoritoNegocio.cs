using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accesoDatos;
using Dominio;

namespace Negocio
{
    public class FavoritoNegocio
    {
        public List<Favoritos> ListarFavoritos(int IdCliente)
        {
            List<Favoritos> lista = new List<Favoritos>();
            ConexionDB marcas = new ConexionDB();
            marcas.setearConsulta("select * from Favoritos where IdCliente = @IdCliente;");
            marcas.setearParametro("@IdCliente",IdCliente);
            marcas.ejecutarLectura();
            try
            {
                while (marcas.Lector.Read())
                {
                    Favoritos aux = new Favoritos();
                    aux.Id = (int)marcas.Lector["Id"];
                    aux.IdCliente = (int)marcas.Lector["IdCliente"];
                    aux.IdLibro = (int)marcas.Lector["IdLibro"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Existe(int IdCliente, int IdLibro)
        {
            ConexionDB marcas = new ConexionDB();
            marcas.setearConsulta("SELECT TOP 1 1 FROM Favoritos WHERE IdCliente = @IdCliente AND IdLibro = @IdLibro;");
            marcas.setearParametro("@IdCliente", IdCliente);
            marcas.setearParametro("@IdLibro", IdLibro);
            marcas.ejecutarLectura();

            if (marcas.Lector.Read())
            {
                return true;
            }
            return false;
        }
        public void SetearFav(int  IdCliente, int IdLibro)
        {
            List<Favoritos> lista = new List<Favoritos>();
            ConexionDB marcas = new ConexionDB();
            if (!Existe(IdCliente, IdLibro))
            {
                marcas.setearConsulta("insert into Favoritos (IdCliente,IdLibro)  values (@IdCliente,@IdLibro);");
                marcas.setearParametro("@IdCliente", IdCliente);
                marcas.setearParametro("@IdLibro", IdLibro);
                marcas.ejecutarAccion();
            }
            else
            {
                marcas.setearConsulta("DELETE FROM Favoritos WHERE IdCliente = @IdCliente AND IdLibro = @IdLibro;");
                marcas.setearParametro("@IdCliente", IdCliente);
                marcas.setearParametro("@IdLibro", IdLibro);
                marcas.ejecutarAccion();
            }
        }
    }
}
