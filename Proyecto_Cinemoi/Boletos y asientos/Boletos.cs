using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
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
        public LinkedList<string> asientos = new LinkedList<string>();

        public Boletos(string Seleccion)
        {
            InitializeComponent();
            seleccion = Seleccion;
        }

        private void Boletos_Load(object sender, EventArgs e)
        {
            contAsientos = 0;  subTotal = 0; contBoletos = 0; contAdul = 0; contNinos = 0; cont3era = 0;

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
            else if (contBoletos > 49)
            {
                MessageBox.Show("No puedes seleccionar más asientos de los que hay en la sala", "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Reserva al menos un boleto", "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Siguiente1_btn_Click(object sender, EventArgs e)
        {
            if (contAsientos > contBoletos)
            {
                MessageBox.Show("¡No puedes seleccionar más asientos de los que has reservado anteriormente!" +
                    $"\n\nEstas seleccionando {contAsientos} asientos y has reservado anteriormente {contBoletos}",
                    "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (contAsientos < contBoletos)
                {
                    MessageBox.Show("¡No puedes seleccionar menos asientos de los que has reservado anteriormente!" +
                    $"\n\nEstas seleccionando {contAsientos} asientos y has reservado anteriormente {contBoletos}",
                    "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Form frm = this.MdiChildren.FirstOrDefault(x => x is Pago);
                    if (frm != null)
                    {
                        frm.Show();
                        return;
                    }
                    frm = new Pago(subTotal, asientos);
                    frm.Show();
                    this.Hide();
                }
            }
        }

        private void AgregandoAsientos(string asiento)
        {
            if (asientos.Count >= contBoletos || !asientos.Contains(asiento))
            {
                asientos.AddFirst(asiento.TrimEnd(new char[] { '_', 'b', 't', 'n' }));
            }
        }

        private void RemoviendoAsientos(string asiento)
        {
            asientos.Remove(asiento.TrimEnd(new char[] { '_', 'b', 't', 'n' }));
        }

        private void FuncionesDeBoton(Button btn)
        {
            if (btn.BackColor == Color.White)
            {
                AgregandoAsientos(btn.Name);
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
                RemoviendoAsientos(btn.Name);
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
            return MessageBox.Show("¡Estas tratando de comprar muchos boletos!", "Cuidado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private DialogResult MsjCeroBoletos(string tipo)
        {
            return MessageBox.Show($"¡Tienes cero boletos de {tipo} seleccionados!", "Cuidado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private DialogResult AsientoOcupado()
        {
            return MessageBox.Show("Alguien ya reservo este asiento, intenta seleccionar otro.",
                "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void A1_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(A1_btn);
        }

        private void B1_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(B1_btn);
        }

        private void F1_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(F1_btn);
        }

        private void E1_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(E1_btn);
        }

        private void D1_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(D1_btn);
        }

        private void C1_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(C1_btn);
        }

        private void G1_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(G1_btn);
        }

        private void D2_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(D2_btn);
        }

        private void F2_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(F2_btn);
        }

        private void E2_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(E2_btn);
        }

        private void G2_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(G2_btn);
        }

        private void C2_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(C2_btn);
        }

        private void C3_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(C3_btn);
        }

        private void C4_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(C4_btn);
        }

        private void C5_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(C5_btn);
        }

        private void C6_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(C6_btn);
        }

        private void C7_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(C7_btn);
        }

        private void C8_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(C8_btn);
        }

        private void C9_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(C9_btn);
        }

        private void B2_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(B2_btn);
        }

        private void A2_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(A2_btn);
        }

        private void A3_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(A3_btn);
        }

        private void A4_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(A4_btn);
        }

        private void A5_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(A5_btn);
        }

        private void A6_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(A6_btn);
        }

        private void A7_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(A7_btn);
        }

        private void A8_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(A8_btn);
        }

        private void A9_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(A9_btn);
        }

        private void G3_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(G3_btn);
        }

        private void G4_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(G4_btn);
        }

        private void G5_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(G5_btn);
        }

        private void G6_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(G6_btn);
        }

        private void G7_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(G7_btn);
        }

        private void G8_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(G8_btn);
        }

        private void G9_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(G9_btn);
        }

        private void F3_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(F3_btn);
        }

        private void F4_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(F4_btn);
        }

        private void F5_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(F5_btn);
        }

        private void F6_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(F6_btn);
        }

        private void F7_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(F7_btn);
        }

        private void F8_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(F8_btn);
        }

        private void F9_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(F9_btn);
        }

        private void E3_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(E3_btn);
        }

        private void E4_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(E4_btn);
        }

        private void E5_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(E5_btn);
        }

        private void E6_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(E6_btn);
        }

        private void E7_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(E7_btn);
        }

        private void E8_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(E8_btn);
        }

        private void E9_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(E9_btn);
        }

        private void D3_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(D3_btn);
        }

        private void D4_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(D4_btn);
        }

        private void D5_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(D5_btn);
        }

        private void D6_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(D6_btn);
        }

        private void D7_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(D7_btn);
        }

        private void D8_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(D8_btn);
        }

        private void D9_btn_Click(object sender, EventArgs e)
        {
            FuncionesDeBoton(D9_btn);
        }
    }
}
