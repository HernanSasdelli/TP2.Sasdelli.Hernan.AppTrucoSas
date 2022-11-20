using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbreriaDelJuego
{
    public class Partida
    {
        public static int ultimaPartida=0;
        public int partidaActual;
        public Action<string> mostrarTerminadas;

        private int contadorDeTantosJug1;
        private int contadorDeTantosJug2;
        private int manosJugadas;
        public string nombreJugador1;
        public string nombreJugador2;


        public Partida()
        {
            partidaActual = ultimaPartida+1;
            ultimaPartida = partidaActual;
            ManosJugadas = 0;
            ContadorDeTantosJug1 = 0;
            ContadorDeTantosJug2 = 0;
        }
        public Partida(string nombreJugador1, string nombreJugador2) : this()
        {
            this.nombreJugador1 = nombreJugador1;
            this.nombreJugador2 = nombreJugador2;
        }

        public int ContadorDeTantosJug1 { get => contadorDeTantosJug1; set => contadorDeTantosJug1 = value; }
        public int ContadorDeTantosJug2 { get => contadorDeTantosJug2; set => contadorDeTantosJug2 = value; }
        public int ManosJugadas { get => manosJugadas; set => manosJugadas = value; }






        /// <summary>
        /// Recibe dos Jugadores, y copia la referencia en la insancia a un jugador pie o un jugador mano
        /// </summary>
        /// <param name="jugador1"></param>
        /// <param name="jugador2"></param>
        /// <param name="orden"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>Devuelve jugador Mano o pie segun orden
        public Jugador DefinirMano(Jugador jugador1, Jugador jugador2, int orden)
        {
            //0 para devolver mano,1 para devolver el pie
            if (jugador1 != null && jugador2 != null)
            {
                if (jugador1.EsMano == true && jugador2.EsMano == false)
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
                else if (jugador2.EsMano == true && jugador1.EsMano == false)
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
                throw new Exception("Error!\nNo se pueden definir jugador mano y pie");
            }
            else
            {
                throw new Exception("Error!\nNo se pudieron cargar jugadores");
            }
            
        }

        public void CambiarMano(Jugador jugador1, Jugador jugador2)
        {
            if (jugador1 == null || jugador2 == null)
            { throw new Exception("Error!\nNo se pudieron cargar jugadores"); }

            if ((jugador1.EsMano == false && jugador2.EsMano == false) ||
                (jugador1.EsMano == true && jugador2.EsMano == true))
            { throw new Exception("Error!\nNo se pueden definir jugador mano y pie"); }

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
