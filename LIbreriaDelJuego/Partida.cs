using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbreriaDelJuego
{
    public class Partida
    {

        private static int nroIdentificadorDePartida = 0;
        private int contadorDeTantosJug1;
        private int contadorDeTantosJug2;
        private int manosJugadas;



        public Partida()
        {
            NroIdentificadorDePartida++;
            ManosJugadas = 0;
            ContadorDeTantosJug1 = 0;
            ContadorDeTantosJug2 = 0;
        }

        public static int NroIdentificadorDePartida { get => nroIdentificadorDePartida; set => nroIdentificadorDePartida = value; }
        public int ContadorDeTantosJug1 { get => contadorDeTantosJug1; set => contadorDeTantosJug1 = value; }
        public int ContadorDeTantosJug2 { get => contadorDeTantosJug2; set => contadorDeTantosJug2 = value; }
        public int ManosJugadas { get => manosJugadas; set => manosJugadas = value; }

        public Jugador DefinirMano(Jugador jugador1, Jugador jugador2, int orden)
        {
            //0 para devolver mano,1 para devolver el pie
            if (jugador1 != null && jugador2 != null)
            {
                if (jugador1.EsMano == true)
                {
                    if (orden == 0)
                    {
                        return jugador1;
                    }
                    else if (orden == 1)
                    {
                        return jugador2;
                    }
                }
                else if (jugador2.EsMano == true)
                {
                    if (orden == 0)
                    {
                        return jugador2;
                    }
                    else if (orden == 1)
                    {
                        return jugador1;
                    }
                }
            }
            throw new Exception("Error 404");
        }

        public void CambiarMano(Jugador jugador1, Jugador jugador2)
        {

            if (jugador1.EsMano == true && jugador2.EsMano == false)
            {
                jugador1.EsMano = false;
                jugador2.EsMano = true;
            }

            else if (jugador1.EsMano == false && jugador2.EsMano == true)
            {
                jugador1.EsMano = true;
                jugador2.EsMano = false;
            }
        }

    }
}
