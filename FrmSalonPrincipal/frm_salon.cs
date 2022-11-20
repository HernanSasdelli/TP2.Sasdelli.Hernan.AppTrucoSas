using FrmSalaDeJuego;
using LIbreriaDelJuego;
using System.Collections.Generic;
using System.Data;

namespace FrmSalonPrincipal
{
    
    public partial class frm_salon : Form
    {
        Action<string> mostrarErrores;
        

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
            lbl_error.Visible=false;
                dtg_listaSalas.DataSource = null;

                Sala nuevaSala = new Sala(mostrarErrores);
            nuevaSala.mostrarTerminadas += ActualizarRchTexboxSalon;
                SalonPrincipal.listaDeSalas2.Add(nuevaSala);

            ///foreach bool de la sala/actualizardata(lista) filtar antes
            /////cuando termina la partida se actualiza datagris evento

            //TitulosDePartidas(SalonPrincipal.listaDeSalas2);
            dtg_listaSalas.DataSource = SalonPrincipal.listaDeSalas2;
               nuevaSala.IniciarPartida();
        }

        private void dtg_listaSalas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            frm_sala nuevaVistaSala = new frm_sala(SalonPrincipal.listaDeSalas2[dtg_listaSalas.CurrentRow.Index]);
            nuevaVistaSala.Show();          


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
                });
            }
        }
    }

}