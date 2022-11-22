using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Cinemoi
{
    public partial class Pago : Form
    {
        public Pago(double total)
        {
            InitializeComponent();
            Label_Total.Text = $"Total: {Convert.ToString(total += total * 0.13)}";
        }

        private void Pagar_Click(object sender, EventArgs e)
        {
            if (Mascara1.MaskCompleted && Mascara2.MaskCompleted && Mascara3.MaskCompleted)
            {
                MessageBox.Show("Has Pagado con EXITO");
            }
            else
            {
                MessageBox.Show("ERROR Una de las casillas esta vacia");
            }
        }
    }
}
