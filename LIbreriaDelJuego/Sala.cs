using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LIbreriaDelJuego
{
    public class Sala
    {
        Jugador jugador1;
        Jugador jugador2;

        public static int nroSala = 1;
        public int salaActual;
        public static List<string> lista = new List<string>(); // era para el registro, al reemplazar definitivamente borrar
        private List<Naipe> mazoDeSala = new List<Naipe>();//memoria para copiar el maso de cartas


        public CancellationTokenSource ctSource;       
        
        public Action<string> jugada;
                
        public Task nuevoJuego;

        public Sala()
        {
            salaActual = nroSala++;            
            jugador1 = new Jugador("Hernan");
            jugador2 = new Jugador("Juanse");
            mazoDeSala = Naipe.CargarCartas();

            ctSource = new CancellationTokenSource();            

            nuevoJuego = new Task(JugarTruco);
        }

        public List<Naipe> MazoDeSala { get => mazoDeSala; set => mazoDeSala = value; }
        public Jugador Jugador1 { get => jugador1; set => jugador1 = value; }
        public Jugador Jugador2 { get => jugador2; set => jugador2 = value; }


        public void IniciarPartida()
        {
            nuevoJuego.Start();
        }


        public void JugarTruco()
        {            
            {
                Jugador jugadorMano = new Jugador();
                Jugador jugadorPie = new Jugador();

                Partida nuevaPartida = new Partida();
                Partida.NroIdentificadorDePartida++;

                int jugarALaGuerraDeCartas=0;
                Naipe cartaMano;
                Naipe cartaPie;

                jugador1.EsMano = true;
                int mano = 1;
                int jugada1 =0;
                int jugada2 =0;
                Thread.Sleep(2000);

                jugada?.Invoke("-------Comienza la Partida------\n");

                do
                {               ///partida hasta sumar los puntos necesarios o sea cancelada     
                                        {
                                            jugada?.Invoke($"\n        ---------Mano{mano++}------\n");
                                            jugada?.Invoke("");

                                            jugadorMano = nuevaPartida.DefinirMano(jugador1, jugador2, 0);
                                            jugadorPie = nuevaPartida.DefinirMano(jugador1, jugador2, 1);
                                            Ronda nuevaRonda = new Ronda();
                                ///reparto
                                            jugadorMano.TresCarta = nuevaRonda.RepartirCartasPorJugador(mazoDeSala);
                                                         jugada?.Invoke($"{jugadorMano.Nombre}, recibio {jugadorMano.TresCarta[0].NumeroNominal} de {jugadorMano.TresCarta[0].Palo}," +
                                                         $"{jugadorMano.TresCarta[1].NumeroNominal} de {jugadorMano.TresCarta[1].Palo},{jugadorMano.TresCarta[2].NumeroNominal} de {jugadorMano.TresCarta[2].Palo}\n");

                                            jugadorPie.TresCarta = nuevaRonda.RepartirCartasPorJugador(mazoDeSala);
                                                         jugada?.Invoke($"{jugadorPie.Nombre}, recibio {jugadorPie.TresCarta[0].NumeroNominal} de {jugadorPie.TresCarta[0].Palo}," +
                                                         $"{jugadorPie.TresCarta[1].NumeroNominal} de {jugadorPie.TresCarta[1].Palo},{jugadorPie.TresCarta[2].NumeroNominal} de {jugadorPie.TresCarta[2].Palo}\n");
                                //manos
                                                                while (nuevaRonda.NroMano<4 && !ctSource.Token.IsCancellationRequested)
                                                                {
                                                                            //envido solo primera mano
                                                                            if (nuevaRonda.NroMano == 1)
                                                                            {
                                                                                Thread.Sleep(1000);
                                                                                jugada1 = jugadorMano.CantarEnvido(26, jugadorMano.CantoEnvido, jugadorMano.CantoFlor, jugada);
                                                                                Thread.Sleep(1000);
                                                                                jugada2 = jugadorPie.CantarEnvido(22, jugadorMano.CantoEnvido, jugadorMano.CantoFlor, jugada);

                                                                                if (jugada2 == 2)
                                                                                {
                                                                                    Thread.Sleep(1000);
                                                                                    jugada1 = jugadorMano.CantarEnvido(22, jugadorPie.CantoEnvido, jugadorPie.CantoFlor, jugada);
                                                                                }
                                                                                Envido.SumarPuntos(jugadorMano, jugadorPie, jugada1, jugada2, jugada);
                                                                           
                                                                                //truco(guerra de cartas)
                                                                                jugada1 = jugadorMano.CantarTruco(10, jugadorMano.CantoTruco, jugadorMano.QuieroTruco, jugada);
                                                                                jugada2 = jugadorPie.CantarTruco(8, jugadorMano.CantoTruco, jugadorMano.QuieroTruco, jugada);

                                                                                if (jugada2 == 2)
                                                                                {
                                                                                    Thread.Sleep(1000);
                                                                                    jugada1 = jugadorMano.CantarTruco(7, jugadorPie.CantoTruco, jugadorPie.QuieroTruco, jugada);
                                                                                }
                                                                            }           

                                                                         jugarALaGuerraDeCartas = Truco.DefinirJugadas(jugada1, jugada2);
                                                                        if (jugarALaGuerraDeCartas == 0)
                                                                        {
 
                                                                                Thread.Sleep(1000);
                                                                                cartaMano = jugadorMano.JugarCartaMasAltaEnJuego();
                                                                                jugada?.Invoke($"El jugador {jugadorMano.Nombre} jugó un {cartaMano.NumeroNominal} de {cartaMano.Palo}\n");

                                                                                Thread.Sleep(1000);
                                                                                cartaPie = jugadorPie.JugarCartaMasAltaEnJuego();
                                                                                jugada?.Invoke($"El jugador {jugadorPie.Nombre} jugó un {cartaPie.NumeroNominal} de {cartaPie.Palo}\n\n");

                                                                                ContadorPuntosMano(cartaMano, cartaPie, jugadorMano, jugadorPie);
                                                                        }

                                                                        nuevaRonda.NroMano++;

                                                                }
                                                                Thread.Sleep(1000);
                                                                Truco.DefinirGanadorTruco(jugadorMano, jugadorPie, jugarALaGuerraDeCartas, jugada, jugada1, jugada2);
                                                                jugada?.Invoke("");

                                           nuevaRonda.NroMano=1;
                                            nuevaPartida.CambiarMano(jugadorMano, jugadorPie);
                                            nuevaRonda.irseAlMaso(jugador1, mazoDeSala);
                                            nuevaRonda.irseAlMaso(jugador2, mazoDeSala);

                                            jugadorMano.ResetearJugador();
                                            jugadorPie.ResetearJugador();


                                        }
                                        if(!ctSource.Token.IsCancellationRequested && (jugadorMano.Puntaje >= 6 || jugadorPie.Puntaje >= 6))
                                        {
                                            jugada?.Invoke($"{DefinirGanador(jugadorMano, jugadorPie)} gana la partida\n");
                                        }
                                        else if(ctSource.Token.IsCancellationRequested){ jugada?.Invoke($"Partida Cancelada\n");}

                } while ((jugadorMano.Puntaje < 6 && jugadorPie.Puntaje < 6) && !ctSource.Token.IsCancellationRequested);
            }
            

        }
        /// <summary>
        /// Cuenta los puntos de cada jugador en la guerra de cartas (truco)
        /// </summary>
        /// <param name="cartaMano"></param>
        /// <param name="cartaPie"></param>
        /// <param name="jugadorMano"></param>
        /// <param name="jugadorPie"></param>
        /// <exception cref="Exception"></exception>
        public void ContadorPuntosMano(Naipe cartaMano, Naipe cartaPie, Jugador jugadorMano, Jugador jugadorPie)
        {
            if (cartaMano == null || cartaPie == null || jugadorMano == null || jugadorPie == null)
            {
                throw new Exception("No se pueden contar los puntos");
            }

            if (cartaMano.EstaJugada == true && cartaPie.EstaJugada == true)
            {
                if (cartaMano.ValorEnJuego>=cartaPie.ValorEnJuego)
                {
                    jugadorMano.PuntosPorMano++;                    
                }
                else if(cartaPie.ValorEnJuego>cartaMano.ValorEnJuego)
                {
                    jugadorPie.PuntosPorMano++;
                }
            }
            else
            {
                throw new Exception("Error!\nNo estan jugadas las cartas");
            }
            
        }
        /// <summary>
        /// Compara los puntajes de los jugadores despues de tres manos, y define el ganador de la guerra de cartas(truco)
        /// </summary>
        /// <param name="jugadorMano"></param>
        /// <param name="jugadorPie"></param>
        /// <returns></returns>Devuelve el nombre del jugador ganador
        public string DefinirGanador(Jugador jugadorMano,Jugador jugadorPie)
        {
            if(jugadorMano!=null && jugadorPie!=null)
            {
                if(jugadorMano.Nombre!=string.Empty && jugadorPie.Nombre != string.Empty)
                {
                    if (jugadorMano.Puntaje >= jugadorPie.Puntaje)
                    {
                        jugadorMano.PartidosGanados++;
                        return jugadorMano.Nombre;
                    }
                    else
                    {
                        jugadorPie.PartidosGanados++;
                        return jugadorPie.Nombre;
                    }
                }
                throw new Exception("ERROR!\nJugadores Incorrectos");
            }
            throw new Exception("ERROR!\nNo se pueden cargar jugadores");
            
        }
    }
}
