using PrimeraPreEntrega.Models;
using System;
using System.Collections.Generic;
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
    }
}
