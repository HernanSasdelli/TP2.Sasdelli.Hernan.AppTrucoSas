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
        public int manoGanadaJ1;//jugador1
        public int manoGanadaJ2;//jugador2


        public Ronda()
        {
            NroMano = 1;
            SeFueAlMaso = false;
            manoGanadaJ1 = 0;
            manoGanadaJ2 = 0;
    }

        public int NroMano { get => nroMano; set => nroMano = value; }
        public bool SeFueAlMaso { get => seFueAlMaso; set => seFueAlMaso = value; }


        public void irseAlMaso(Jugador jugador, List<Naipe> masoEnUso)
        {
            if (jugador == null || masoEnUso == null)
            {
                throw new Exception("Jugador o maso vacio");
            }
            if(jugador.TresCarta.Count()!=3)
            {
                throw new Exception("El Jugador No Tiene Cartas");
            }
            foreach (Naipe unaCarta in jugador.TresCarta)
            {
                unaCarta.EstaJugada = false;
            }
            masoEnUso.AddRange(jugador.TresCarta);
            jugador.TresCarta.Clear();

        }
        public List<Naipe> RepartirCartasPorJugador(List<Naipe> maso)
        {
            if(maso != null && maso.Count()>2)
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
            throw new Exception("Error!\nEl maso de cartas no esta");
        }
    }
}
