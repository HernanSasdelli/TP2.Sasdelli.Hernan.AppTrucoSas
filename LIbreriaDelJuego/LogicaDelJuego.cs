using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LIbreriaDelJuego
{
    public class LogicaDelJuego
    {

        public Action<string> Mostrar1 = Sala.GrabarEnRegistro;


        public List<string> TheGameIsBeginning(Action<string> jugada)
        {
            List<string> registro = new List<string>();
            Jugador jugadorMano = new Jugador();
            Jugador jugadorPie = new Jugador();


            Sala nuevaSala = new Sala();


            Partida nuevaPartida = new Partida();
            Partida.NroIdentificadorDePartida++;
            nuevaSala.Jugador1.EsMano = true;
            int mano = 1;
            int jugada1;
            int jugada2;


            // nuevoDelegado.Invoke("-------Comienza la Partida------");

            do
            {
                jugada.Invoke($"---------Mano{mano++}------");

                registro.Add("");
                jugadorMano = nuevaPartida.DefinirMano(nuevaSala.Jugador1, nuevaSala.Jugador2, 0);
                jugadorPie = nuevaPartida.DefinirMano(nuevaSala.Jugador1, nuevaSala.Jugador2, 1);

                Ronda nuevaRonda = new Ronda();
                jugadorMano.TresCarta = nuevaRonda.RepartirCartasPorJugador(nuevaSala.MazoDeSala);
                jugadorPie.TresCarta = nuevaRonda.RepartirCartasPorJugador(nuevaSala.MazoDeSala);
                while (nuevaRonda.NroMano < 2 || nuevaRonda.SeFueAlMaso == true)
                {
                    // Mano nuevaMano = new Mano();
                    if (nuevaRonda.NroMano == 0)
                    {

                        jugada1 = jugadorMano.CantarEnvido(registro, 26, jugadorMano.CantoEnvido, jugadorMano.CantoFlor, jugada);
                        Task.Delay(2000);
                        jugada2 = jugadorPie.CantarEnvido(registro, 22, jugadorMano.CantoEnvido, jugadorMano.CantoFlor, jugada);
                        Task.Delay(2000);

                        if (jugada2 == 2)
                        {
                            Task.Delay(3000);
                            jugada1 = jugadorMano.CantarEnvido(registro, 22, jugadorPie.CantoEnvido, jugadorPie.CantoFlor, jugada);
                        }

                        Envido.SumarPuntos(jugadorMano, jugadorPie, jugada1, jugada2, registro);
                    }


                    //jugada1 = jugadorMano.CantarTruco(registro, 10, jugadorMano.CantoTruco);
                    //jugada2 = jugadorPie.CantarTruco(registro, 10, jugadorMano.CantoTruco);



                    nuevaRonda.irseAlMaso(nuevaSala.Jugador1, nuevaSala.MazoDeSala);
                    nuevaRonda.irseAlMaso(nuevaSala.Jugador2, nuevaSala.MazoDeSala);



                    nuevaRonda.NroMano++;
                    jugadorMano.ResetearJuego();
                    jugadorPie.ResetearJuego();

                }
                nuevaPartida.CambiarMano(jugadorMano, jugadorPie);
                nuevaPartida.ContadorDeTantosJug2 = nuevaPartida.ContadorDeTantosJug2 + 2;


            } while (jugadorMano.Puntaje < 4 && jugadorPie.Puntaje < 4);
            jugada.Invoke("Lala");
            Task.Delay(10000);
            return registro;
        }



    }
}
