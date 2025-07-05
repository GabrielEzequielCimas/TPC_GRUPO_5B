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
                datos.setearConsulta("INSERT INTO Ventas (Fecha, IdCliente, NumeroFactura, DireccionEntrega, Estado) OUTPUT INSERTED.ID VALUES (GETDATE(), @IdCliente, @NumeroFactura, @DireccionEntrega, @Estado)");
                datos.setearParametro("@IdCliente", idCliente);
                datos.setearParametro("@NumeroFactura", generarNumeroFactura());
                datos.setearParametro("@DireccionEntrega", direccion);
                datos.setearParametro("@Estado", "Pendiente");

                int idVenta = (int)datos.ejecutarScalar();

                foreach (var item in carrito)
                {
                    int stockActual = ObtenerStock(item.Libro.Id);
                    if (item.Cantidad > stockActual)
                    {
                        throw new Exception($"Stock insuficiente del libro '{item.Libro.Titulo}'. Disponible: {stockActual}, solicitado: {item.Cantidad}.");
                    }

                    datos.setearConsulta("INSERT INTO DetalleVenta (IdVenta, IdLibro, Cantidad, Precio) VALUES (@IdVenta, @IdLibro, @Cantidad, @Precio)");
                    datos.setearParametro("@IdVenta", idVenta);
                    datos.setearParametro("@IdLibro", item.Libro.Id);
                    datos.setearParametro("@Cantidad", item.Cantidad);
                    datos.setearParametro("@Precio", item.Libro.Precio);
                    datos.ejecutarAccion();

                    datos.setearConsulta("UPDATE Libros SET Stock = Stock - @Cantidad WHERE Id = @IdLibro");
                    datos.setearParametro("@Cantidad", item.Cantidad);
                    datos.setearParametro("@IdLibro", item.Libro.Id);
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

                if (documento == 0)
                {
                    datos.setearParametro("@Documento", DBNull.Value);
                }
                else
                {
                    datos.setearParametro("@Documento", documento);
                }

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

        private int ObtenerStock(int idLibro)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("SELECT Stock FROM Libros WHERE Id = @Id");
                datos.setearParametro("@Id", idLibro);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                    return (int)datos.Lector["Stock"];
                else
                    return 0;
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

        public List<Venta> ListarVentas()
        {
            List<Venta> lista = new List<Venta>();
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta(@"SELECT v.Id, v.Fecha, v.NumeroFactura, v.DireccionEntrega, v.Estado, c.Nombre, c.Apellido, c.Email FROM Ventas v INNER JOIN Clientes c ON v.IdCliente = c.Id ORDER BY v.Fecha DESC");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta v = new Venta
                    {
                        Id = (int)datos.Lector["Id"],
                        Fecha = (DateTime)datos.Lector["Fecha"],
                        NumeroFactura = datos.Lector["NumeroFactura"].ToString(),
                        DireccionEntrega = datos.Lector["DireccionEntrega"].ToString(),
                        Estado = datos.Lector["Estado"].ToString(),
                        Cliente = new Cliente
                        {
                            Nombre = datos.Lector["Nombre"].ToString(),
                            Apellido = datos.Lector["Apellido"].ToString(),
                            Email = datos.Lector["Email"].ToString()
                        }
                    };
                    lista.Add(v);
                }
                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void CambiarEstado(int idVenta, string nuevoEstado)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("UPDATE Ventas SET Estado = @Estado WHERE Id = @IdVenta");
                datos.setearParametro("@Estado", nuevoEstado);
                datos.setearParametro("@IdVenta", idVenta);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<DetalleVenta> ListarDetalleVenta(int idVenta)
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta(@"SELECT d.IdLibro, l.Titulo, d.Cantidad, d.Precio FROM DetalleVenta d INNER JOIN Libros l ON d.IdLibro = l.Id WHERE d.IdVenta = @IdVenta");
                datos.setearParametro("@IdVenta", idVenta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    DetalleVenta d = new DetalleVenta
                    {
                        Libro = new Libro
                        {
                            Id = (int)datos.Lector["IdLibro"],
                            Titulo = datos.Lector["Titulo"].ToString()
                        },
                        Cantidad = (int)datos.Lector["Cantidad"],
                        Precio = (decimal)datos.Lector["Precio"]
                    };
                    lista.Add(d);
                }
                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
