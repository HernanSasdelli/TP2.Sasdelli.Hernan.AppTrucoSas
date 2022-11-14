using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbreriaDelJuego
{
    public class Ronda
    {
        private int nroMano;
        private bool seFueAlMaso;


        public Ronda()
        {
            NroMano = 0;
            SeFueAlMaso = false;
        }

        public int NroMano { get => nroMano; set => nroMano = value; }
        public bool SeFueAlMaso { get => seFueAlMaso; set => seFueAlMaso = value; }


        public void irseAlMaso(Jugador Jugador, List<Naipe> masoEnUso)
        {
            if (Jugador != null && masoEnUso != null)
            {
                masoEnUso.AddRange(Jugador.TresCarta);
                Jugador.TresCarta.Clear();

            }
        }
        public List<Naipe> RepartirCartasPorJugador(List<Naipe> maso)
        {
            List<Naipe> tresCartas = new List<Naipe>();
            Random ramdom = new Random();
            int sacarUnaCarta;
            for (int i = 0; i < 3; i++)
            {
                sacarUnaCarta = ramdom.Next(0, maso.Count());
                tresCartas.Add(maso[sacarUnaCarta]);
                maso.Remove(maso[sacarUnaCarta]);
            }
            return tresCartas;
        }
    }
}
