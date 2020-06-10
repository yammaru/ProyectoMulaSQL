using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
namespace BLL
{
    public class MovimientoService
    {
        ConnectionSQL connection = new ConnectionSQL();
        MovimientoRepository RepositorioMovimiento;
        public MovimientoService()
        {
            RepositorioMovimiento = new MovimientoRepository(connection.ConeXXXion());
        }
        public string Guardar(Movimiento movimiento)
        {
            try
            {
                connection.abrir();
                RepositorioMovimiento.GuardarMovimiento(movimiento);
                connection.Cerrar();
                return $"el producto {movimiento.CodigoProducto}, Se modifico.";
            }
            catch (Exception e)
            {
                connection.Cerrar();
                return "Error en Bases de datos al modificar::: " + e.Message;
            }
            


        }
        public List<Movimiento> MostrarMovimiento()
        {
            try
            {
                connection.abrir();
                List<Movimiento> movimientos = RepositorioMovimiento.ConsultarMovimiento();

                connection.Cerrar();
                return movimientos;
            }
            catch (Exception )
            {
                connection.Cerrar();
                return null;
            }
        }
        public List<Movimiento> Buscar(string tipo, string  code , DateTime fecha)
        {

            connection.abrir();
            List<Movimiento> movimientos = RepositorioMovimiento.ConsultarMovimiento();

            connection.Cerrar();
           
                return movimientos.Where(M=>M.Tipo.Equals(tipo)||M.CodigoProducto.Equals(code)||M.Fecha.Equals(fecha)).ToList();
            
        }
    }
}
