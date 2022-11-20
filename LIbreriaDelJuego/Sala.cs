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
        public bool estaVisible;
        public bool terminoPartida;

        public CancellationTokenSource ctSource;       
        
        public Action<string> jugada;
                
        public Task nuevoJuego;

        public Action<string> mostrarErrores;
        

        public Action<string> mostrarTerminadas;


        public Sala()
        {
            salaActual = nroSala++;

            mazoDeSala = SalonPrincipal.listaNaipePrincipal.ToList();

            ctSource = new CancellationTokenSource();

            nuevoJuego = new Task(JugarTruco);
            
        }

        public Sala(Action<string> mostrarErrores) :this()   
        {
            this.mostrarErrores = mostrarErrores;

        }

        public List<Naipe> MazoDeSala { get => mazoDeSala; set => mazoDeSala = value; }
        public Jugador Jugador1 { get => jugador1; set => jugador1 = value; }
        public Jugador Jugador2 { get => jugador2; set => jugador2 = value; }


        public void IniciarPartida()
        {
            nuevoJuego.Start();
        }

        public void MostrarJugada(string str)
        {
            jugada?.Invoke(str);
        }
        public void JugarTruco()
        {
            try
            {
                jugador1 = Jugador.LlamarUnJugador(SalonPrincipal.listaJugadores);
                jugador2 = Jugador.LlamarUnJugador(SalonPrincipal.listaJugadores);
                jugador1.cantar += MostrarJugada;
                jugador2.cantar += MostrarJugada;


            }
            catch (Exception ex)
            {
                mostrarErrores($"La sala{this.salaActual} dice:\n{ex.Message}");
                this.ctSource.Cancel();
                
            }
            if(!ctSource.Token.IsCancellationRequested)
            {
                Partida nuevaPartida = new Partida(jugador1.Nombre, jugador2.Nombre);
                try
                {
                    Jugador jugadorMano;
                    Jugador jugadorPie;
                    
                    
                    int jugarALaGuerraDeCartas = 0;
                    Naipe cartaMano;
                    Naipe cartaPie;

                    jugador1.EsMano = true;
                    int mano = 1;
                    int jugada1 =0;
                    int jugada2 =0;
                    Thread.Sleep(500);

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
                                                                                    Thread.Sleep(500);
                                                                                    jugada1 = jugadorMano.CantarEnvido(26, jugadorMano.CantoEnvido, jugadorMano.CantoFlor);
                                                                                    Thread.Sleep(500);
                                                                                    jugada2 = jugadorPie.CantarEnvido(22, jugadorMano.CantoEnvido, jugadorMano.CantoFlor);

                                                                                    if (jugada2 == 2)
                                                                                    {
                                                                                        Thread.Sleep(1000);
                                                                                        jugada1 = jugadorMano.CantarEnvido(22, jugadorPie.CantoEnvido, jugadorPie.CantoFlor);
                                                                                    }
                                                                                    Envido.SumarPuntos(jugadorMano, jugadorPie, jugada1, jugada2, jugada);
                                                                           
                                                                                    //truco(guerra de cartas)
                                                                                    jugada1 = jugadorMano.CantarTruco(10, jugadorMano.CantoTruco, jugadorMano.QuieroTruco);
                                                                                    jugada2 = jugadorPie.CantarTruco(8, jugadorMano.CantoTruco, jugadorMano.QuieroTruco);

                                                                                    if (jugada2 == 2)
                                                                                    {
                                                                                        Thread.Sleep(500);
                                                                                        jugada1 = jugadorMano.CantarTruco(7, jugadorPie.CantoTruco, jugadorPie.QuieroTruco);
                                                                                    }
                                                                                }           

                                                                             jugarALaGuerraDeCartas = Truco.DefinirJugadas(jugada1, jugada2);
                                                                            if (jugarALaGuerraDeCartas == 0)
                                                                            {
 
                                                                                    Thread.Sleep(500);
                                                                                    cartaMano = jugadorMano.JugarCartaMasAltaEnJuego();
                                                                                    jugada?.Invoke($"El jugador {jugadorMano.Nombre} jugó un {cartaMano.NumeroNominal} de {cartaMano.Palo}\n");

                                                                                    Thread.Sleep(500);
                                                                                    cartaPie = jugadorPie.JugarCartaMasAltaEnJuego();
                                                                                    jugada?.Invoke($"El jugador {jugadorPie.Nombre} jugó un {cartaPie.NumeroNominal} de {cartaPie.Palo}\n\n");

                                                                                    ContadorPuntosMano(cartaMano, cartaPie, jugadorMano, jugadorPie);
                                                                            }

                                                                            nuevaRonda.NroMano++;

                                                                    }
                                                                    Thread.Sleep(500);
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
                                                Jugador ganador = DefinirGanador(jugadorMano, jugadorPie);
                                                jugada?.Invoke($"{ganador.Nombre} gana la partida\n");
                                                mostrarTerminadas($"La Partida {nuevaPartida.partidaActual} \ntermino con {ganador.Nombre} de Ganador\n--------\n");

                                                PConexionSQL nuevaConexion = new PConexionSQL();
                                                nuevaConexion.GuardarDatos(ganador);

                                               /* PISerializadoraGenerica<Jugador> nuevoJsonJugadores = new PJsonSerializadora<Jugador>();
                                                nuevoJsonJugadores.Escribir(ganador, "jugadoresGanadores");*/
                                               
                                                terminoPartida = true;
                                                
                                                 this.terminoPartida = true;
                                            }
                                            else if(ctSource.Token.IsCancellationRequested)
                                            {
                                                jugada?.Invoke($"Partida Cancelada\n");              
                                                mostrarTerminadas($"La partida {nuevaPartida.partidaActual} fue cancelada\n--------\n");
                                                
                                                
                                                 this.terminoPartida = true;
                                             }

                    } while ((jugadorMano.Puntaje < 6 && jugadorPie.Puntaje < 6) && !ctSource.Token.IsCancellationRequested);
                    Jugador.ResetearJugadores(Jugador1, Jugador2);
                    terminoPartida = true;
                }
                catch (Exception ex)
                {              
                    mostrarErrores($"La partida {nuevaPartida.partidaActual} dice:\n{ex.Message}");
                    this.terminoPartida = true;
                    Jugador.ResetearJugadores(Jugador1, Jugador2);
                }

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
        public Jugador DefinirGanador(Jugador jugadorMano,Jugador jugadorPie)
        {
            if(jugadorMano!=null || jugadorPie!=null)
            {
                if(jugadorMano.Nombre!=string.Empty && jugadorPie.Nombre != string.Empty)
                {
                    if (jugadorMano.Puntaje >= jugadorPie.Puntaje)
                    {
                        jugadorMano.PartidosGanados++;
                        return jugadorMano;
                    }
                    else
                    {
                        jugadorPie.PartidosGanados++;
                        return jugadorPie;
                    }
                }
                throw new Exception("ERROR!\nJugadores Incorrectos");
            }
            throw new Exception("ERROR!\nNo se pueden cargar jugadores");
            
        }
    }
}
