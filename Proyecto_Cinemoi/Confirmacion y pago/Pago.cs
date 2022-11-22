using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Cinemoi
{
    public partial class Pago : Form
    {
        public static LinkedList<string> Asientos;

        public Pago(double total, LinkedList<string> asientos)
        {
            InitializeComponent();
            Asientos = asientos;
            Label_Total.Text = $"Total: ${Convert.ToString(total += total * 0.13)}";
        }

        private void Pagar_Click(object sender, EventArgs e)
        {
            TextWriter asientosArchivo = new StreamWriter("Asientos.txt");
            string[] asientoMatriz = Asientos.ToArray();

            asientosArchivo.WriteLine("Los boletos seleccionados son:\n ");

            for (int i = 0; i < asientoMatriz.Length; i++)
            {
                asientosArchivo.Write(asientoMatriz[i] + ",");
            }
            asientosArchivo.Close();


            if (Mascara1.MaskCompleted && Mascara2.MaskCompleted && Mascara3.MaskCompleted)
            {
               var mensaje = MessageBox.Show("¿Estás seguro de realizar la transacción?", "Espera un momento...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(mensaje == DialogResult.Yes)
                {
                    MessageBox.Show("Has Pagado con exito! Tus boletos se han sido registrados", "Transacción exitosa.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Una o más casillas no han sido llenadas en su totalidad", "Ha ocurrido un error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
