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
    public partial class Boletos : Form
    {
        public static int contAsientos, contBoletos, contAdul, contNinos, cont3era;
        public static double subTotal;
        public static string seleccion;

        public Boletos(string Seleccion)
        {
            InitializeComponent();
            seleccion = Seleccion;
        }

        private void Boletos_Load(object sender, EventArgs e)
        {
            switch (seleccion)
            {
                case "BlackPanter": PictureBox_Entrada.Image = Proyecto_Cinemoi.Properties.Resources.poster_BlackPanter; break;
                case "Mario": PictureBox_Entrada.Image = Proyecto_Cinemoi.Properties.Resources.Super_mario_encartelera; break;
                case "Avengers": PictureBox_Entrada.Image = Proyecto_Cinemoi.Properties.Resources.Avenger_endgame; break;
            }
        }

        private void Atras_btn_Click(object sender, EventArgs e)
        {
            Panel_boletos.Visible = true;
        }

        private void Siguiente_btn_Click(object sender, EventArgs e)
        {
            contBoletos = contAdul + contNinos + cont3era;

            if (contBoletos != 0)
            {
                Panel_boletos.Visible = false;
                Label_TusEntradas.Text = Convert.ToString(contBoletos);
            }
            else
            {
                MessageBox.Show("Reserva al menos un boleto", "Ha ocurrido un error");
            }
        }

        private void Siguiente1_btn_Click(object sender, EventArgs e)
        {
            if (contAsientos > contBoletos)
            {
                MessageBox.Show("¡No puedes seleccionar más asientos de los que has reservado anteriormente!" +
                    $"\n\nEstas seleccionando {contAsientos} asientos y has reservado anteriormente {contBoletos}", "Ha ocurrido un error");
            }
            else
            {
                if (contAsientos < contBoletos)
                {
                    MessageBox.Show("¡No puedes seleccionar menos asientos de los que has reservado anteriormente!" +
                    $"\n\nEstas seleccionando {contAsientos} asientos y has reservado anteriormente {contBoletos}", "Ha ocurrido un error");
                }
                else
                {
                    Form frm = this.MdiChildren.FirstOrDefault(x => x is Pago);
                    if (frm != null)
                    {
                        frm.Show();
                        return;
                    }
                    frm = new Pago();
                    frm.Show();
                }
            }
        }

        private void CambioDeColor(Button btn)
        {
            if (btn.BackColor == Color.White)
            {
                contAsientos++;
                btn.BackColor = Color.DarkGreen;
                btn.ForeColor = Color.White;
            }
            else if (btn.BackColor == Color.DarkRed)
            {
                AsientoOcupado();
            }
            else
            {
                contAsientos--;
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
            }
        }

        private void AumenAdulto_btn_Click(object sender, EventArgs e)
        {
            if (contAdul != 20)
            {
                contAdul++;
                subTotal += 4.50;

                Label_Boletos1.Text = Convert.ToString(contAdul);
                Label_Subtotal.Text = $"Sub total: ${subTotal}";
            }
            else
            {
                MsjMuchosBoletos();
            }
        }

        private void DismiAdulto_btn_Click(object sender, EventArgs e)
        {
            if (contAdul != 0)
            {
                contAdul--;
                subTotal -= 4.50;


                Label_Boletos1.Text = Convert.ToString(contAdul);
                Label_Subtotal.Text = $"Sub total: ${subTotal}";
            }
            else
            {
                MsjCeroBoletos("Adultos");
            }
        }

        private void AumenNiños_btn_Click(object sender, EventArgs e)
        {
            if (contNinos != 20)
            {
                contNinos++;
                subTotal += 3.50;


                Label_Boletos2.Text = Convert.ToString(contNinos);
                Label_Subtotal.Text = $"Sub total: ${subTotal}";
            }
            else
            {
                MsjMuchosBoletos();
            }
        }

        private void DismiNiños_btn_Click(object sender, EventArgs e)
        {
            if (contNinos != 0)
            {
                contNinos--;
                subTotal -= 3.50;


                Label_Boletos2.Text = Convert.ToString(contNinos);
                Label_Subtotal.Text = $"Sub total: ${subTotal}";
            }
            else
            {
                MsjCeroBoletos("Niños");
            }
        }

        private void Aumen3era_btn_Click(object sender, EventArgs e)
        {
            if (cont3era != 20)
            {
                cont3era++;
                subTotal += 3;


                Label_Boletos3.Text = Convert.ToString(cont3era);
                Label_Subtotal.Text = $"Sub total: ${subTotal}";
            }
            else
            {
                MsjMuchosBoletos();
            }
        }

        private void Dismi3ra_btn_Click(object sender, EventArgs e)
        {
            if (cont3era != 0)
            {
                cont3era--;
                subTotal -= 3;


                Label_Boletos3.Text = Convert.ToString(cont3era);
                Label_Subtotal.Text = $"Sub total: ${subTotal}";
            }
            else
            {
                MsjCeroBoletos("3era edad");
            }
        }

        private DialogResult MsjMuchosBoletos()
        {
            return MessageBox.Show("¡Estas tratando de comprar muchos boletos!");
        }

        private DialogResult MsjCeroBoletos(string tipo)
        {
            return MessageBox.Show($"¡Tienes cero boletos de {tipo} seleccionados!");
        }

        private DialogResult AsientoOcupado()
        {
            return MessageBox.Show("Alguien ya reservo este asiento, intenta seleccionar otro.", "Ha ocurrido un error");
        }

        private void A1_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(A1_btn);
        }

        private void B1_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(B1_btn);
        }

        private void F1_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(F1_btn);
        }

        private void E1_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(E1_btn);
        }

        private void D1_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(D1_btn);
        }

        private void C1_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(C1_btn);
        }

        private void G1_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(G1_btn);
        }

        private void D2_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(D2_btn);
        }

        private void F2_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(F2_btn);
        }

        private void E2_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(E2_btn);
        }

        private void G2_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(G2_btn);
        }

        private void C2_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(C2_btn);
        }

        private void C3_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(C3_btn);
        }

        private void C4_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(C4_btn);
        }

        private void C5_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(C5_btn);
        }

        private void C6_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(C6_btn);
        }

        private void C7_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(C7_btn);
        }

        private void C8_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(C8_btn);
        }

        private void C9_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(C9_btn);
        }

        private void B2_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(B2_btn);
        }

        private void A2_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(A2_btn);
        }

        private void A3_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(A3_btn);
        }

        private void A4_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(A4_btn);
        }

        private void A5_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(A5_btn);
        }

        private void A6_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(A6_btn);
        }

        private void A7_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(A7_btn);
        }

        private void A8_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(A8_btn);
        }

        private void A9_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(A9_btn);
        }

        private void G3_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(G3_btn);
        }

        private void G4_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(G4_btn);
        }

        private void G5_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(G5_btn);
        }

        private void G6_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(G6_btn);
        }

        private void G7_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(G7_btn);
        }

        private void G8_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(G8_btn);
        }

        private void G9_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(G9_btn);
        }

        private void F3_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(F3_btn);
        }

        private void F4_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(F4_btn);
        }

        private void F5_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(F5_btn);
        }

        private void F6_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(F6_btn);
        }

        private void F7_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(F7_btn);
        }

        private void F8_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(F8_btn);
        }

        private void F9_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(F9_btn);
        }

        private void E3_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(E3_btn);
        }

        private void E4_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(E4_btn);
        }

        private void E5_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(E5_btn);
        }

        private void E6_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(E6_btn);
        }

        private void E7_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(E7_btn);
        }

        private void E8_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(E8_btn);
        }

        private void E9_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(E9_btn);
        }

        private void D3_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(D3_btn);
        }

        private void D4_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(D4_btn);
        }

        private void D5_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(D5_btn);
        }

        private void D6_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(D6_btn);
        }

        private void D7_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(D7_btn);
        }

        private void D8_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(D8_btn);
        }

        private void D9_btn_Click(object sender, EventArgs e)
        {
            CambioDeColor(D9_btn);
        }
    }
}
