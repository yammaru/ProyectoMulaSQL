using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;using Entity;using BLL;

namespace Mula
{
    public partial class FrmMovimiento : Form
    {
        
        MovimientoService service = new MovimientoService();
        
        public FrmMovimiento()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void FrmMovimiento_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = service.MostrarMovimiento();
            if ((service.MostrarMovimiento()) == null)
            {
                MessageBox.Show("No hay Movimientos");
            }
        }

        private void bttTodosLosMovimientos_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = service.MostrarMovimiento();
            if ((service.MostrarMovimiento())==null)
            {
                MessageBox.Show("No hay Movimientos");
            }
        }

        private void bttBuscar_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
            dataGridView1.DataSource =service.Buscar( CmbTipo.Text,txtCodigo.Text,DtpFecha.Value);
            
            if ((service.Buscar( CmbTipo.Text, txtCodigo.Text, DtpFecha.Value)) == null)
            {
                MessageBox.Show("No hay Movimientos");
            }
        }
    }
}
