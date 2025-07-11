using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accesoDatos;
using Dominio;

namespace Negocio
{
    public class DireccionNegocio
    {

        public List<Direccion> ListarPorCliente(int idCliente)
        {
            List<Direccion> direcciones = new List<Direccion>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta(@"
                    SELECT 
                        DC.Id,
                        DC.IdCliente,
                        DC.IdProvincia,
                        DC.IdLocalidad,
                        P.Provincia,
                        L.Localidad,
                        L.CP,
                        DC.Calle,
                        DC.Numero
                    FROM DireccionesCliente DC
                    JOIN Localidades L ON DC.IdLocalidad = L.Id
                    join Provincias P on P.Id = L.IDProvincia
                    WHERE DC.IdCliente = @idCliente
                ");
                datos.setearParametro("@idCliente", idCliente);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Direccion dir = new Direccion
                    {
                        IdDireccion = (int)datos.Lector["Id"],
                        IdCliente = (int)datos.Lector["IdCliente"],
                        IdProvincia = (int)datos.Lector["IdProvincia"],
                        IdLocalidad = (int)datos.Lector["IdLocalidad"],
                        Provincia = datos.Lector["Provincia"]?.ToString() ?? "",
                        Localidad = datos.Lector["Localidad"]?.ToString() ?? "",
                        CP = datos.Lector["CP"]?.ToString() ?? "",
                        Calle = datos.Lector["Calle"]?.ToString() ?? "",
                        Numero = (int)datos.Lector["Numero"]
                    };

                    direcciones.Add(dir);
                }

                return direcciones;
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

        public void AgregarDireccion(Direccion nueva)
        {
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta(@"
                    INSERT INTO DireccionesCliente (IdCliente, IdProvincia, IdLocalidad, Calle, Numero)
                    VALUES (@idCliente, @idProvincia, @idLocalidad, @Calle, @Numero)
                ");

                datos.setearParametro("@idCliente", nueva.IdCliente);
                datos.setearParametro("@idProvincia", nueva.IdProvincia);
                datos.setearParametro("@idLocalidad", nueva.IdLocalidad);
                datos.setearParametro("@Calle", nueva.Calle);
                datos.setearParametro("@Numero", nueva.Numero);

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

        public List<Provincia> ListarProvincias()
        {
            List<Provincia> provincias = new List<Provincia>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT Id, Provincia FROM Provincias");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    provincias.Add(new Provincia
                    {
                        Id = (int)datos.Lector["Id"],
                        Nombre = datos.Lector["Provincia"].ToString()
                    });
                }

                return provincias;
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


        public List<Localidad> ListarLocalidadesPorProvincia(int idProvincia)
        {
            List<Localidad> lista = new List<Localidad>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT Id, Localidad, CP FROM Localidades WHERE IDProvincia = @idProvincia");
                datos.setearParametro("@idProvincia", idProvincia);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(new Localidad
                    {
                        Id = (int)datos.Lector["Id"],
                        Nombre = datos.Lector["Localidad"].ToString(),
                        CP = datos.Lector["CP"].ToString()
                    });
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
        public void ActualizarDireccion(Direccion direccion)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta(@"
            UPDATE DireccionesCliente 
            SET 
                IdProvincia = @idProvincia,
                IdLocalidad = @idLocalidad,
                Calle = @calle,
                Numero = @numero
            WHERE Id = @idDireccion
        ");

                datos.setearParametro("@idProvincia", direccion.IdProvincia);
                datos.setearParametro("@idLocalidad", direccion.IdLocalidad);
                datos.setearParametro("@calle", direccion.Calle);
                datos.setearParametro("@numero", direccion.Numero);
                datos.setearParametro("@idDireccion", direccion.IdDireccion);

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

    public class Localidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CP { get; set; }
    }
    public class Provincia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
