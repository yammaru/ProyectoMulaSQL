using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace BLL
{
    class ConnectionSQL
    {
        string cadena = @"Data Source=USUARIO\SQLEXPRESS;Initial Catalog=Mula;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection connection = new SqlConnection();
        public ConnectionSQL()
        {
            connection.ConnectionString = cadena;
        }
        public SqlConnection ConeXXXion() 
        { 
            return connection; 
        }
        public void abrir()
        {
                connection.Open();
        }
        public void Cerrar() 
        { 
            connection.Close(); 
        }
    }
}
