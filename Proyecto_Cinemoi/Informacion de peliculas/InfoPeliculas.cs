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
    public partial class InfoPeliculas : Form
    {
        public int seleccion { get; set; }


        public InfoPeliculas()
        {
            InitializeComponent();

        }

        private void ABoletos()
        {
            Boletos blt = (Boletos)this.MdiChildren.FirstOrDefault(x => x is Boletos);

            if (blt!= null)
            {
                blt.Show();
                return;
            }

            blt = new Boletos();
            blt.Show();
        }

        private DialogResult AgotadoBtns()
        {
            return MessageBox.Show("La función seleccionada se encuentra actualmente no disponible, debido a que todos los boletos estan agotados. \n\nSelecciona otra función.", "Ha ocurrido un error");
        }


        //Botones disponibles

        private void Disponible16_btn_Click(object sender, EventArgs e)
        {
            ABoletos();
        }

        private void Disponible1_btn_Click(object sender, EventArgs e)
        {
            ABoletos();
        }

        private void Disponible2_btn_Click(object sender, EventArgs e)
        {
            ABoletos();
        }

        private void Disponible3_btn_Click(object sender, EventArgs e)
        {
            ABoletos();
        }

        private void Disponible4_btn_Click(object sender, EventArgs e)
        {
            ABoletos();
        }

        private void Disponible5_btn_Click(object sender, EventArgs e)
        {
            ABoletos();
        }

        private void Disponible6_btn_Click(object sender, EventArgs e)
        {
            ABoletos();
        }

        private void Disponible7_btn_Click(object sender, EventArgs e)
        {
            ABoletos();
        }

        private void Disponible8_btn_Click(object sender, EventArgs e)
        {
            ABoletos();
        }

        private void Disponible10_btn_Click(object sender, EventArgs e)
        {
            ABoletos();
        }

        private void Disponible11_btn_Click(object sender, EventArgs e)
        {
            ABoletos();
        }

        private void Disponible12_btn_Click(object sender, EventArgs e)
        {
            ABoletos();
        }

        private void Disponible13_btn_Click(object sender, EventArgs e)
        {
            ABoletos();
        }

        private void Disponible14_btn_Click(object sender, EventArgs e)
        {
            ABoletos();
        }

        private void Disponible15_btn_Click(object sender, EventArgs e)
        {
            ABoletos();
        }

        private void Disponible_btn_Click(object sender, EventArgs e)
        {
            ABoletos();
        }

        private void Disponible17_btn_Click(object sender, EventArgs e)
        {
            ABoletos();
        }

        private void Agotado_btn_Click(object sender, EventArgs e)
        {

        }

        //Botones de agotado

        private void Agotado1_btn_Click(object sender, EventArgs e)
        {
            AgotadoBtns();
        }

        private void Agotado2_btn_Click(object sender, EventArgs e)
        {
            AgotadoBtns();
        }

        private void Agotado3_btn_Click(object sender, EventArgs e)
        {
            AgotadoBtns();
        }

        private void Agotado4_btn_Click(object sender, EventArgs e)
        {
            AgotadoBtns();
        }

        private void Agotado5_btn_Click(object sender, EventArgs e)
        {
            AgotadoBtns();
        }

        private void Agotado6_btn_Click(object sender, EventArgs e)
        {
            AgotadoBtns();
        }

        private void Agotado7_btn_Click(object sender, EventArgs e)
        {
            AgotadoBtns();
        }

        private void Agotado8_btn_Click(object sender, EventArgs e)
        {
            AgotadoBtns();
        }

        private void Agotado9_btn_Click(object sender, EventArgs e)
        {
            AgotadoBtns();
        }
    }
}
