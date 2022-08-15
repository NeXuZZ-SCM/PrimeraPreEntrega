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
    internal class VentaRepository : GenericDB
    {
        public List<Venta> GetVentas()
        {
            string cmdText = "SELECT * FROM Venta";
            List<Venta> ventas = new List<Venta>();

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
                                Venta venta = new Venta();

                                venta.Id = Convert.ToInt64(dataReader["Id"]);
                                venta.Comentarios = dataReader["Comentarios"].ToString();

                                ventas.Add(venta);

                            }
                        }
                    }
                }
            }
            return ventas;  
        }

        public List<Venta> GetVentasByIdUser(int idUsuario)
        {

            string cmdText = "SELECT DISTINCT VE.id, VE.Comentarios from Producto as P" +
                " inner join ProductoVendido as PV" +
                " on PV.IdProducto = P.id" +
                " inner join Venta as VE" +
                " on VE.id = PV.idVenta" +
                " where P.idUsuario = 1;";

            List<Venta> _ventas = new List<Venta>();

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
                                Venta venta = new Venta();

                                venta.Id = Convert.ToInt64(dataReader["id"]);
                                venta.Comentarios = dataReader["Comentarios"].ToString();

                                _ventas.Add(venta);
                            }
                        }
                    }
                }
            }

            return _ventas;
        }

    }
}
