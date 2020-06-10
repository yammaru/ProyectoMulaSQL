using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
   public class MovimientoRepository
   {
        SqlDataReader Reader;
        SqlConnection Connection;
       
        List<Movimiento> movimientos;
        public MovimientoRepository(SqlConnection connection)
        {
            Connection = connection;
            movimientos = new List<Movimiento>();
        }
        
        public void GuardarMovimiento(Movimiento movimiento)
        {
            using (var Comando = Connection.CreateCommand())
            {
                Comando.CommandText = "insert into Movimiento(CodigoProducto,Tipo,Fecha,Cantidad)" +
                    "values(@CodigoProducto,@Tipo,@Fecha,@Cantidad);";
                Comando.Parameters.AddWithValue("@CodigoProducto",movimiento.CodigoProducto);
                Comando.Parameters.AddWithValue("@Tipo", movimiento.Tipo);
                Comando.Parameters.AddWithValue("@Fecha", movimiento.Fecha);
                Comando.Parameters.AddWithValue("@Cantidad",movimiento.Cantidad);
                Comando.ExecuteNonQuery();
            }
        }
        public List<Movimiento> ConsultarMovimiento()
        {
            using (var Comando = Connection.CreateCommand())
            {
                Comando.CommandText = "select * from Movimiento";
                Reader = Comando.ExecuteReader();
                while (Reader.Read())
                {
                    Movimiento movimiento = new Movimiento();
                    movimiento =MapMovimiento(Reader);
                    movimientos.Add(movimiento);
                }
            }
            return movimientos;

        }
        public Movimiento MapMovimiento(SqlDataReader reader)
        {
            
            Movimiento movimiento = new Movimiento();
            movimiento.CodigoProducto = (string)reader["CodigoProducto"];
            movimiento.Tipo = (string)reader["Tipo"];
            movimiento.Fecha = (DateTime)reader["Fecha"];
            movimiento.Cantidad = (int)reader["cantidad"];

            return movimiento;
        }
     
    }
}
