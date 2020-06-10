using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;

namespace Mula
{
    public partial class FrmPrincipal : Form
    {
        List<string> productos = new List<string>();
        ProductoService serviceProducto = new ProductoService();
        MovimientoService serviceMovimiento = new MovimientoService();
        
        Movimiento movimiento = new Movimiento();
        public FrmPrincipal()
        {
            InitializeComponent();
             
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in serviceProducto.ConsultarProducto())
            {
                cmbProducto.Items.Add(item.NombreProducto);
            }
            
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void LbCantidad_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
         
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }
        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            //PrincipalService ServicePrincipal = new PrincipalService();
            //productos = ServicePrincipal.nomConsultar();
            //AutoCompleteStringCollection colecion = new AutoCompleteStringCollection();
            //foreach (string item in productos)
            //{
            //    colecion.Add(item);
            //}
            //txtProducto.AutoCompleteCustomSource = colecion;
            //txtProducto.AutoCompleteMode = AutoCompleteMode.Suggest;
            //txtProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;
          
            
             
        }
        private void obsionesDeProduductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProducto producto = new FrmProducto();
            producto.ShowDialog();
        }
        DialogResult dialog;
        private void bttSale_Click(object sender, EventArgs e)
        {
            movimiento.CodigoProducto = serviceProducto.BuscarCodigoXNombre(cmbProducto.Text);
            movimiento.Tipo = "Sale";
            movimiento.Cantidad=int.Parse(txtCantidad.Text);
            movimiento.Fecha = DateTime.Now;
            dialog=MessageBox.Show($"Desea registrar la Salida del producto {cmbProducto.Text}?", "Salida", MessageBoxButtons.YesNo);
            if (dialog==DialogResult.Yes)
            {
                serviceProducto.CambioExitencia(movimiento.CodigoProducto, movimiento.Cantidad, movimiento.Tipo);
                string mensaje = serviceMovimiento.Guardar(movimiento);
                MessageBox.Show(mensaje, "Modifico");

            }
            else if (dialog==DialogResult.No)
            {
                MessageBox.Show("NO Modifico");
            }
        }

        private void bttEntra_Click(object sender, EventArgs e)
        {
            if (cmbProducto.Text!=null)
            {

            }
            movimiento.CodigoProducto = serviceProducto.BuscarCodigoXNombre(cmbProducto.Text);
            movimiento.Tipo = "Entra";
            movimiento.Cantidad= int.Parse(txtCantidad.Text);
            movimiento.Fecha = DateTime.Now;
            dialog = MessageBox.Show($"Desea registrar la entrada del producto {cmbProducto.Text}?", "Entrarda", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                serviceProducto.CambioExitencia(movimiento.CodigoProducto,movimiento.Cantidad, movimiento.Tipo);
                string mensaje = serviceMovimiento.Guardar(movimiento);
                MessageBox.Show(mensaje, "Modifico");
            }
            else if (dialog==DialogResult.No)
            {
                MessageBox.Show("NO Modifico");
            }
}

        private void movimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMovimiento frmMovimiento = new FrmMovimiento();
            frmMovimiento.ShowDialog();
        }
        

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
