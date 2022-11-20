using LIbreriaDelJuego;

namespace FrmSalaDeJuego
{
    public partial class frm_sala : Form
    {
        Sala salaRecibida;
        public frm_sala()
        {
            InitializeComponent();
         
        }
        public frm_sala(Sala salaSeleccionada):this()
        {
            salaRecibida = salaSeleccionada;
            
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            salaRecibida.estaVisible = false;
            this.Close();
         
        }

        private void frm_sala_Load(object sender, EventArgs e)
        {
            
            salaRecibida.jugada += ActualizarRchTexbox;//delegado de sala


            lbl_jugadorDos.Text= $"Jugador 1:\n {salaRecibida.Jugador2.Nombre}";
            lbl_jugadorUno.Text = $"Jugador 2:\n {salaRecibida.Jugador1.Nombre}";
            lbl_mostrarPartida.Text =$"Sala {salaRecibida.salaActual.ToString()}";
            salaRecibida.estaVisible = true;

        }

        private void ActualizarRchTexbox(string texto)
        {
            if (this.rtb_mostrarJugadas.InvokeRequired)
            {
                this.rtb_mostrarJugadas.BeginInvoke((MethodInvoker)delegate ()
                {
                    rtb_mostrarJugadas.AppendText(texto);
                    rtb_mostrarJugadas.ScrollToCaret();
                });                
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            salaRecibida.ctSource.Cancel();
        }


    }
}