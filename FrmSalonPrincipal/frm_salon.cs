using FrmSalaDeJuego;
using LIbreriaDelJuego;
using System.Collections.Generic;
using System.Data;

namespace FrmSalonPrincipal
{
    
    public partial class frm_salon : Form
    {
        Action<string> mostrarErrores;
        int indice = 0;

        private void ActualizarErrorLabel(string texto)
        {
            if (this.lbl_error.InvokeRequired)
            {
                this.lbl_error.BeginInvoke((MethodInvoker)delegate ()
                {
                    lbl_error.Visible = true;
                    lbl_error.Text = texto;
                });
            }
        }
        public frm_salon()
        {
            InitializeComponent();
        }

        private void btn_crearNuevaSala_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Visible = false;
                dtg_listaSalas.DataSource = null;
                dtg_listaSalas.DataSource = SalonPrincipal.ActualizarSalasEnJuego(SalonPrincipal.listaDeSalas2);
                if(SalonPrincipal.ActualizarSalasEnJuego(SalonPrincipal.listaDeSalas2).Count()<9)
                {
                    Sala nuevaSala = new Sala(mostrarErrores);
                    nuevaSala.mostrarTerminadas += ActualizarRchTexboxSalon;
                    SalonPrincipal.listaDeSalas2.Add(nuevaSala);

                    dtg_listaSalas.DataSource = null;
                    dtg_listaSalas.DataSource = SalonPrincipal.ActualizarSalasEnJuego(SalonPrincipal.listaDeSalas2);
                    nuevaSala.IniciarPartida();
                }
                else
                {
                    lbl_error.Visible = true;
                    lbl_error.Text = "Llego al limite de salas creadas\n Por favor aguarde a que termine una partida";
                }

            }
            catch (Exception ex)
            {
                lbl_error.Text=ex.Message;
            }
        }

        private void dtg_listaSalas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            indice = -1;


            try
            {
                indice = dtg_listaSalas.CurrentRow.Index;
                if (SalonPrincipal.listaDeSalas2[indice].estaVisible == false)
                {
                    frm_sala nuevaVistaSala = new frm_sala(SalonPrincipal.listaDeSalas2[indice]) ;
                    nuevaVistaSala.Show();
                }
                else
                throw new Exception("La Sala ya se encuentra en\nmodo vista");
            }
            catch(Exception ex)
            {
                lbl_error.Visible = true;
                lbl_error.Text=ex.Message;
            }

        }

        private void frm_salon_Load(object sender, EventArgs e)
        {
            mostrarErrores = ActualizarErrorLabel;

        }


        private void ActualizarRchTexboxSalon(string texto)
        {
            if (this.rtb_mostrarPartidasTerminadas.InvokeRequired)
            {
                this.rtb_mostrarPartidasTerminadas.BeginInvoke((MethodInvoker)delegate ()
                {
                    rtb_mostrarPartidasTerminadas.AppendText(texto);
                    rtb_mostrarPartidasTerminadas.ScrollToCaret();
                    

                    dtg_listaSalas.DataSource = null;
                    dtg_listaSalas.DataSource = SalonPrincipal.ActualizarSalasEnJuego(SalonPrincipal.listaDeSalas2);

                });
            }
        }

        private void frm_salon_MouseClick(object sender, MouseEventArgs e)
        {
            lbl_error.Visible = false;
        }


        private void frm_salon_FormClosing(object sender, FormClosingEventArgs e)
        {
                        DialogResult salir = MessageBox.Show("               ¿Seguro desea Salir?", "", MessageBoxButtons.YesNo);
            if (salir == DialogResult.Yes)
            {
                    Application.Exit();
            }
            else 
                e.Cancel = true;
        }
    }

}