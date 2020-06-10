using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Movimiento
    {
       public string CodigoProducto { set; get; }
        public string Tipo { set; get; }
        public DateTime Fecha { set; get; }
        public int Cantidad { set; get; }
        public override string ToString()
        {
            return $"{CodigoProducto};{Tipo};{Fecha};{Cantidad}";
        }
       
    
    }
}
