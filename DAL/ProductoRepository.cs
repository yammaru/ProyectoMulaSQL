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
    public class ProductoRepository
    {
        SqlConnection Connection;
        SqlDataReader Reader;
        List<Producto> productos;
        public ProductoRepository(SqlConnection connection)
        {
            Connection = connection;
            productos = new List<Producto>();
        }
        
        public void Guardar(Producto producto)
        {
            using (var Comando = Connection.CreateCommand())
            {
                Comando.CommandText = "insert into Producto(CodigoProducto,NombreProducto,Existencia,Referencia,Marca)" +
                    "values(@CodigoProducto,@NombreProducto,@Existencia,@Referencia,@Marca); ";
                Comando.Parameters.AddWithValue("@CodigoProducto",producto.CodigoProducto);
                Comando.Parameters.AddWithValue("@NombreProducto", producto.NombreProducto);
                Comando.Parameters.AddWithValue("@Existencia", producto.Existencia);
                Comando.Parameters.AddWithValue("@Referencia", producto.Referencia);
                Comando.Parameters.AddWithValue("@Marca", producto.Marca);
                Comando.ExecuteNonQuery();
            }
        }
        public List<Producto> Consultar()
        {
            productos.Clear();
            using (var Comando = Connection.CreateCommand())
            {
                Comando.CommandText = "select * from Producto";
                Reader = Comando.ExecuteReader();
                while (Reader.Read())
                {
                    Producto producto = new Producto();
                    producto = Map(Reader);
                    productos.Add(producto);
                }
            }
            return productos;
        }
        public Producto Map(SqlDataReader reader)
        {
            
            Producto producto = new Producto();
            producto.CodigoProducto = (string)reader["CodigoProducto"];
            producto.NombreProducto = (string)reader["NombreProducto"];
            producto.Existencia = (int)reader["Existencia"];
            producto.Referencia = (string)reader["Referencia"];
            producto.Marca = (string)reader["Marca"];
            return producto;
        }
        public Producto BuscarXNombre(string nn) 
        {
            productos.Clear();
            productos = Consultar();
            return productos.Find(P => P.NombreProducto.Equals(nn)); 
        }
        public Producto BuscarXCodigo(string nn)
        {
            productos.Clear();
            productos = Consultar();
            return productos.Find(P => P.CodigoProducto.Equals(nn));
        }
        public string BuscaCodigoXNombre(string nombre) 
        {
           Producto producto= BuscarXNombre(nombre);
            return  producto.CodigoProducto; 
        }
        public void ActualizaExistencia(int existencia,string CodigoProducto)
        {
            using (var Comando = Connection.CreateCommand())
            {
                Comando.CommandText = "UPDATE Producto set Existencia=@Existencia WHERE CodigoProducto=@CodigoProducto";
                Comando.Parameters.AddWithValue("@CodigoProducto", CodigoProducto);
                Comando.Parameters.AddWithValue("@Existencia", existencia);
                Comando.ExecuteNonQuery();
            }
        }
        public void EliminarProducto(string producto)
        {
            using (var Comando =Connection.CreateCommand())
            {
                Comando.CommandText = "DELETE FROM Producto WHERE CodigoProducto=@CodigoProducto";
                Comando.Parameters.AddWithValue("@CodigoProducto", producto);
                Comando.ExecuteNonQuery();
            }
        }
    }
}
