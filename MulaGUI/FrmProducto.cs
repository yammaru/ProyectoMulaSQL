using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entity;
namespace Mula
{
    public partial class FrmProducto : Form
    {
        Producto producto = new Producto();
        ProductoService service = new ProductoService();
        MovimientoService movimientoService = new MovimientoService();
        Movimiento movimiento = new Movimiento();
        public FrmProducto()
        {
            InitializeComponent();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = service.ConsultarProducto();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {

        }
        DialogResult dialog;
        private void BttGuardar_Click(object sender, EventArgs e)
        {
            producto.CodigoProducto = txtIDProducto.Text;
            producto.NombreProducto = txtNombreProducto.Text;
            producto.Existencia = int.Parse(txtCantidad.Text);
            producto.Referencia = txtReferencia.Text;
            producto.Marca = txtMarca.Text;
            movimiento.Cantidad = int.Parse(txtCantidad.Text);
            movimiento.Fecha = DateTime.Now;
            movimiento.Tipo = "Entra";
            movimiento.CodigoProducto = txtIDProducto.Text;
            dialog = MessageBox.Show($"Desea registrar la entrada del producto {txtNombreProducto.Text}?", "Entrarda", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                movimientoService.Guardar(movimiento);
                string mensaje = service.GuardarProducto(producto);
                MessageBox.Show(mensaje, "Guardo");
            }
            else if (dialog == DialogResult.No)
            {
                MessageBox.Show("NO guardo");
            }
          
        }

        private void BttConsultar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = service.ConsultarProducto();
        }

        private void BttRegreso_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }
    }
}
