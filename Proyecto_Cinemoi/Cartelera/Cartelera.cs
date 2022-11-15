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
    public partial class Cartelera : Form
    {
        Boletos FormBoletos = new Boletos();
        Pago FormPago = new Pago();
        InfoPeliculas FormInfoPelis = new InfoPeliculas();

        public Cartelera()
        {
            InitializeComponent();
        }

        private void Cartelera_Load(object sender, EventArgs e)
        {

        }

        private void ProviBTN_Boletos_Click(object sender, EventArgs e)
        {
            FormBoletos.Show();
        }

        private void ProviBTN_Pago_Click(object sender, EventArgs e)
        {
            FormPago.Show();
        }

        private void ProviBTN_Infopeli_Click(object sender, EventArgs e)
        {
            FormInfoPelis.Show();
        }
    }
}
