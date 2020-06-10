using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Producto
    {
        public string CodigoProducto { set; get; }
        public string NombreProducto { set; get; }
        public int Existencia { set; get; }      
        public string Referencia { set; get; }
        public string Marca { set; get; }

        List<Movimiento> movimientos = new List<Movimiento>();
        public Producto()
        {
           
        }

        public Producto(string codigoProducto, string nombreProducto, int cantidad,string referencia,string marca)
        {
            CodigoProducto = codigoProducto;
            NombreProducto = nombreProducto;
            Existencia = cantidad;
            Referencia = Referencia;
            Marca = marca;
            
        }

        public override string ToString()
        {
            return $"{CodigoProducto};{NombreProducto};{Existencia};{Referencia};{Marca}";
        }
        //public void CalculaExistencia(Movimiento movimiento)
        //{
        //    Existencia = (movimiento.Tipo == "Entra") ? Existencia += movimiento.Cantidad : Existencia -= movimiento.Cantidad;
        //}


    }
}
