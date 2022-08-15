using PrimeraPreEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraPreEntrega.Repository
{
    internal class ProductoVendidoRepository : GenericDB
    {

        public List<ProductoVendido> GetProductosVendidos()
        {
            string cmdText = "SELECT * FROM ProductoVendido";
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductoVendido productovendido = new ProductoVendido();

                                productovendido.Id = Convert.ToInt64(dataReader["Id"]);
                                productovendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                productovendido.IdProducto = Convert.ToInt64(dataReader["IdProducto"]);
                                productovendido.IdVenta = Convert.ToInt64(dataReader["IdVenta"]);

                                productosVendidos.Add(productovendido);

                            }

                        }

                    }
                }
            }

            return productosVendidos;

        }
        public List<Producto> GetProductosVendidosByIdUser(int idUsuario)
        {

            string cmdText = "SELECT * from Producto as P " +
                " inner join ProductoVendido as PV" +
                " on PV.IdProducto = P.id" +
                " where P.idUsuario = @idUsuario;";

            List<Producto> _productos = new List<Producto>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection))
                {

                    sqlCommand.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.BigInt)).Value = idUsuario;


                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Producto producto = new Producto();

                                producto.Id = Convert.ToInt64(dataReader["Id"]);
                                producto.Descripciones = dataReader["Descripciones"].ToString();
                                producto.Costo = Convert.ToDecimal(dataReader["Costo"]);
                                producto.PrecioVenta = Convert.ToDecimal(dataReader["PrecioVenta"]);
                                producto.Stock = Convert.ToInt32(dataReader["Stock"]);
                                producto.IdUsuario = Convert.ToInt64(dataReader["IdUsuario"]);

                                _productos.Add(producto);
                            }
                        }
                    }
                }
            }

            return _productos;
        }



    }
}
