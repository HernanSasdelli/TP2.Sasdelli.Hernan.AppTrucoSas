using FrmSalaDeJuego;
using LIbreriaDelJuego;
using System.Collections.Generic;

namespace FrmSalonPrincipal
{
    
    public partial class frm_salon : Form
    {
        Action<string> action;

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

                dtg_listaSalas.DataSource = null;

                Sala nuevaSala = new Sala();           
                SalonPrincipal.listaDeSalas2.Add(nuevaSala);

                ///foreach bool de la sala/actualizardata(lista) filtar antes
                /////cuando termina la partida se actualiza datagris evento
         
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

        }


        /* Task instanciarNuevaSala = Task.Run(() => {
             frm_sala paño = new frm_sala();
             paño.ShowDialog();
         });*/
    }
}