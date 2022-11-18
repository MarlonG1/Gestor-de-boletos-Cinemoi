using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Cinemoi
{
    public partial class InfoPeliculas : Form
    {
        private static string seleccion;

        public InfoPeliculas(string Seleccion)
        {
            InitializeComponent();
            seleccion = Seleccion;
            Informacion();
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
            return MessageBox.Show("La función seleccionada no se encuentra actualmente disponible, debido a que todos los boletos estan agotados. \n\nSelecciona otra función.", "Ha ocurrido un error");
        }

        private void Informacion()
        {
            switch (seleccion)
            {
                case "BlackPanter":
                    PictureBox_Poster.Image = Proyecto_Cinemoi.Properties.Resources.poster_BlackPanter;
                    Calificacion4.Image = Proyecto_Cinemoi.Properties.Resources.EstrellaVacia;
                    Calificacion5.Image = Proyecto_Cinemoi.Properties.Resources.EstrellaVacia;
                    Label_Titulo.Text = "Black Panter";
                    Label_Mincaracteristicas.Text = "2022 | AA | 2h 55min";
                    Label_Sinopsis.Text = "La reina Ramonda, Shuri, M Baku, Okoye y las Dora Milaje luchan \npor proteger a su nacion de las potencias mundiales que intervienen \ntras la muerte del Rey T Challa.";
                    break;
                case "Avengers":
                    PictureBox_Poster.Image = Proyecto_Cinemoi.Properties.Resources.Avenger_endgame;
                    Calificacion4.Image = Proyecto_Cinemoi.Properties.Resources.EstrellaLlenita;
                    Calificacion5.Image = Proyecto_Cinemoi.Properties.Resources.EstrellaLlenita;
                    Label_Titulo.Text = "Avengers: Endgame";
                    Label_Mincaracteristicas.Text = "2019 | AA | 3h 2min";
                    Label_Sinopsis.Text = "Los Vengadores restantes deben encontrar una manera de recuperar \na sus aliados para un enfrentamiento épico con Thanos, el malvado \nque diezmó el planeta y el universo.";
                    break;
                case "Mario":
                    PictureBox_Poster.Image = Proyecto_Cinemoi.Properties.Resources.Super_mario_encartelera;
                    Calificacion4.Image = Proyecto_Cinemoi.Properties.Resources.EstrellaLlenita;
                    Calificacion5.Image = Proyecto_Cinemoi.Properties.Resources.EstrellaVacia;
                    Label_Titulo.Text = "Mario the movie";
                    Label_Mincaracteristicas.Text = "2022 | A | 2h 15min";
                    Label_Sinopsis.Text = "Mario y Luigi, dos hermanos viajan a un mundo oculto para \nrescatar a la Princesa Peach, capturada por el malvado Rey Bowser.\nLas cosas, sin embargo no serán sencillas.";
                    break;
            }
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

        //Botones de agotado
        private void Agotado_btn_Click(object sender, EventArgs e)
        {
            AgotadoBtns();
        }

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
