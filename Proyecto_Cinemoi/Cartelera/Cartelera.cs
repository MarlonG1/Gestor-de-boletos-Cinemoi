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
        public string Seleccion { get; set; }

        public Cartelera()
        {
            InitializeComponent();
        }

        private void AFormInfoPelis()
        {
            Form frm = this.MdiChildren.FirstOrDefault(x => x is InfoPeliculas);

            if (frm != null)
            {
                frm.Show();
                return;
            }

            frm = new InfoPeliculas();
            frm.Show();
        }

        //Botones de "Saber mas"
        private void Pelicula1_btn_Click(object sender, EventArgs e)
        {
            Seleccion = "Avengers";
            AFormInfoPelis();
        }

        private void Pelicula2_btn_Click(object sender, EventArgs e)
        {
            Seleccion = "Mario";
            AFormInfoPelis();
        }

        private void Pelicula3_btn_Click(object sender, EventArgs e)
        {
            Seleccion = "BlackPanter";
            AFormInfoPelis();
        }

        //Click en los posters

        private void AvengerPicturebox_Click(object sender, EventArgs e)
        {
            Seleccion = "Avengers";
            AFormInfoPelis();
        }

        private void SuperMariopicturebox_Click(object sender, EventArgs e)
        {
            Seleccion = "Mario";
            AFormInfoPelis();
        }

        private void BlackPanterPictureBox_Click(object sender, EventArgs e)
        {
            Seleccion = "BlackPanter";
            AFormInfoPelis();
        }

        //Click en poster grande

        private void PictureBox_Pelicula3_Click(object sender, EventArgs e)
        {
            Seleccion = "BlackPanter";
            AFormInfoPelis();
        }
    }
}
