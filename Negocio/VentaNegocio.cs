using accesoDatos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Negocio
{
    public class VentaNegocio
    {
        public bool RegistrarVenta(string nombre, string apellido, string email, int documento, string direccion, string metodoPago, List<ItemCarrito> carrito)
        {
            int idCliente = obtenerIdCliente(email, nombre, apellido, documento);

            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("INSERT INTO Ventas (Fecha, IdCliente, NumeroFactura) OUTPUT INSERTED.ID VALUES (GETDATE(), @IdCliente, @NumeroFactura)");
                datos.setearParametro("@IdCliente", idCliente); 
                datos.setearParametro("@NumeroFactura", generarNumeroFactura());

                int idVenta = (int)datos.ejecutarScalar();

                foreach (var item in carrito)
                {
                    datos.setearConsulta("INSERT INTO DetalleVenta (IdVenta, IdLibro, Cantidad, Precio) VALUES (@IdVenta, @IdLibro, @Cantidad, @Precio)");
                    datos.setearParametro("@IdVenta", idVenta);
                    datos.setearParametro("@IdLibro", item.Libro.Id);
                    datos.setearParametro("@Cantidad", item.Cantidad);
                    datos.setearParametro("@Precio", item.Libro.Precio);
                    datos.ejecutarAccion();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public int obtenerIdCliente(string email, string nombre, string apellido, int documento)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                // Verificar si existe
                datos.setearConsulta("SELECT Id, Documento FROM Clientes WHERE Email = @Email");
                datos.setearParametro("@Email", email);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int idExistente = (int)datos.Lector["Id"];

                    // Si Documento esta vacio o en cero, actualizamos datos del cliente
                    if (datos.Lector["Documento"] == DBNull.Value || Convert.ToInt32(datos.Lector["Documento"]) == 0)
                    {
                        datos.cerrarConexion();
                        datos.setearConsulta("UPDATE Clientes SET Nombre = @Nombre, Apellido = @Apellido, Documento = @Documento WHERE Id = @Id");
                        datos.setearParametro("@Nombre", nombre);
                        datos.setearParametro("@Apellido", apellido);
                        datos.setearParametro("@Documento", documento);
                        datos.setearParametro("@Id", idExistente);
                        datos.ejecutarAccion();
                    }

                    return idExistente;
                }
                datos.cerrarConexion();

                // Si no existe, lo insertamos
                datos.setearConsulta("INSERT INTO Clientes (Nombre, Apellido, Email, Documento) OUTPUT INSERTED.Id VALUES (@Nombre, @Apellido, @Email, @Documento)");
                datos.setearParametro("@Nombre", nombre);
                datos.setearParametro("@Apellido", apellido);
                datos.setearParametro("@Email", email);
                datos.setearParametro("@Documento", documento);
                int nuevoId = (int)datos.ejecutarScalar();
                return nuevoId;
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

        public string generarNumeroFactura()
        {
            return "FAC-" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }
    }
}
