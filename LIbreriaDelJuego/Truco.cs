using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbreriaDelJuego
{
    public class Truco
    {

        /// <summary>
        /// Define si se juega al truco o no
        /// </summary>
        /// <param name="jugada1"></param>
        /// <param name="jugada2"></param>
        /// <returns></returns>Retorna 0 si ambos jugadores decidieron jugar, o retorna 1 si algun jugador no quizo el truco
        public static int DefinirJugadas(int jugada1,int jugada2)
        {
            if ((jugada1 == 0 && jugada2 == 0) || (jugada1 == 1 && jugada2 == 1) || (jugada1 == 1 && jugada2 == 2))
            {
                return 0;
            }
            else return 1; 
        }
        /// <summary>
        /// Si la jugada continua, sea porque se quizo el truco, o no se canto, define quien fue el ganador
        /// </summary>
        /// <param name="jugadorMano"></param>
        /// <param name="jugadorPie"></param>
        /// <param name="jugoAlTruco"></param>
        /// <param name="jugada"></param>
        /// <param name="jugada1"></param>
        /// <param name="jugada2"></param>
        /// <exception cref="Exception"></exception>
        public static void DefinirGanadorTruco(Jugador jugadorMano, Jugador jugadorPie,int jugoAlTruco,Action<string>? jugada, int jugada1,int jugada2)
        {
           if(jugadorMano!= null && jugadorPie!= null)
           {
                if(jugoAlTruco == 0)
                {
                    if(jugadorMano.PuntosPorMano>= jugadorPie.PuntosPorMano)
                    {
                        if(jugada1 == 0 && jugada2 == 0)
                        {
                            jugadorMano.Puntaje = jugadorMano.Puntaje +1;
                            jugada?.Invoke($"El jugador {jugadorMano.Nombre} gano 1 punto, no se canto truco\n");
                        }
                        else
                        {
                            jugadorMano.Puntaje = jugadorMano.Puntaje + 2;
                            jugada?.Invoke($"El jugador {jugadorMano.Nombre} gano 2 puntos por ganar el truco\n");
                        }
                    }
                    else if ( jugadorPie.PuntosPorMano > jugadorMano.PuntosPorMano)
                    {
                        if (jugada1 == 0 && jugada2 == 0)
                        {
                            jugadorPie.Puntaje = jugadorPie.Puntaje + 1;
                            jugada?.Invoke($"El jugador {jugadorPie.Nombre} gano 1 punto, no se canto truco\n");
                        }
                        else
                        {
                            jugadorPie.Puntaje = jugadorPie.Puntaje + 2;
                            jugada?.Invoke($"El jugador {jugadorPie.Nombre} gano 2 puntos por ganar el truco\n");
                        }
                    }
                }
                else if(jugoAlTruco == 1)
                {
                    if(jugada1 == 1)
                    {
                        jugadorMano.Puntaje = jugadorMano.Puntaje + 1;
                        jugada?.Invoke($"El jugador {jugadorMano.Nombre} gano 1 punto por truco no querido\n");
                    }
                    else if (jugada2 == 2)
                    {
                        jugadorPie.Puntaje = jugadorPie.Puntaje + 1;
                        jugada?.Invoke($"El jugador {jugadorPie.Nombre} gano 1 punto por truco no querido\n");
                    }
                }
           }
           //throw new Exception("ERROR!\nNo se pudieron sumar los puntos");
        }
    }
}