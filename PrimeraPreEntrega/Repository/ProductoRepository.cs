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
    internal class ProductoRepository : GenericDB
    {

        public List<Producto> GetProductos()
        {
            string cmdText = "SELECT * FROM Producto";
            List<Producto> products = new List<Producto>();

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
                                Producto producto = new Producto();

                                producto.Id = Convert.ToInt64(dataReader["Id"]);
                                producto.Descripciones = dataReader["Descripciones"].ToString();
                                producto.Costo = Convert.ToDecimal(dataReader["Costo"]);
                                producto.PrecioVenta = Convert.ToDecimal(dataReader["PrecioVenta"]);
                                producto.Stock = Convert.ToInt32(dataReader["Stock"]);
                                producto.IdUsuario = Convert.ToInt64(dataReader["IdUsuario"]);

                                products.Add(producto);
                            }
                        }
                    }
                }
            }
            return products;
        }

        public List<Producto> GetProductosByIdUser(int idUsuario)
        {
            string cmdText = "SELECT * FROM Producto WHERE IdUsuario = @idUsuario;";
            List<Producto> _productos = new List<Producto>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection))
                {

                    sqlCommand.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.VarChar, 20)).Value = idUsuario;


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
