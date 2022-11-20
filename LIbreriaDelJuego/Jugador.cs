using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbreriaDelJuego
{
    public class Jugador
    {
        public int id;
        public string? nombre;
        public List<Naipe> tresCarta = new List<Naipe>();
        public int puntaje;
        public bool esMano;
        public bool cantoEnvido;
        public bool cantoTruco;
        public bool cantoFlor;
        public bool quieroEnvido;
        public bool quieroTruco;
        public int puntosPorMano;
        public bool estaJugando;

        int partidosGanados;

        public event Action<string> cantar;


        public Jugador()
        {
       
        }
        public Jugador(int id, string nombre,int partidosGanados) : this()
        {
            this.id = id;
            this.nombre = nombre;
            this.partidosGanados = partidosGanados;
            Puntaje = 0;
            PuntosPorMano = 0;
        }

        public List<Naipe> TresCarta { get => tresCarta; set => tresCarta = value; }
        public int Puntaje { get => puntaje; set => puntaje = value; }
        public bool EsMano { get => esMano; set => esMano = value; }
        public bool CantoEnvido { get => cantoEnvido; set => cantoEnvido = value; }
        public bool CantoTruco { get => cantoTruco; set => cantoTruco = value; }
        public bool QuieroEnvido { get => quieroEnvido; set => quieroEnvido = value; }
        public bool QuieroTruco { get => quieroTruco; set => quieroTruco = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public bool CantoFlor { get => cantoFlor; set => cantoFlor = value; }
        public int PuntosPorMano { get => puntosPorMano; set => puntosPorMano = value; }
        public int PartidosGanados { get => partidosGanados; set => partidosGanados = value; }

        public int CantarEnvido( int conveniencia,
            bool seCantoEnvido, bool seCantoFlor)
        {
            int retorno = 0;

            int envido = Envido.CalcularEnvidoOFlor(TresCarta);
            if (envido == -1)
            {
                CantoFlor = true;
                cantar?.Invoke($"{Nombre} canto Flor\n");

                retorno = -1;
            }
            if (seCantoFlor == false)
            {
                if (envido > conveniencia && seCantoEnvido == false)
                {
                    CantoEnvido = true;

                    cantar?.Invoke($"{Nombre} Canta Envido\n");
 
                    if (EsMano == true) { retorno = 1; } else { retorno = 2; }
                }
                else if (envido > conveniencia && seCantoEnvido == true)
                {
                    CantoEnvido = true;
                    cantar?.Invoke($"{Nombre} Dice Quiero\n");


                    retorno = 1;
                }
                else if (envido < conveniencia && seCantoEnvido == true)
                {
                    CantoEnvido = false;
                    cantar?.Invoke($"{Nombre} Dice No Quiero\n");

                    retorno = -2;
                }
            }
            return retorno;
        }

        public void ResetearJugador()
        {
            CantoEnvido = false;
            CantoTruco = false;
            QuieroEnvido = false;
            QuieroTruco = false;
            CantoFlor = false;
            PuntosPorMano = 0;
        }

        public static void ResetearJugadores(Jugador j1, Jugador j2)
        {
            if (j1 == null || j2 == null)
                throw new Exception("Error!\nJugadores no existen");
            j1.CantoEnvido = false;
            j1.CantoTruco = false;
            j1.QuieroEnvido = false;
            j1.QuieroTruco = false;
            j1.CantoFlor = false;
            j1.PuntosPorMano = 0;
            j1.puntaje = 0;
            j1.estaJugando = false;
            j1.esMano = false; 
            j2.CantoEnvido = false;
            j2.CantoTruco = false;
            j2.QuieroEnvido = false;
            j2.QuieroTruco = false;
            j2.CantoFlor = false;
            j2.PuntosPorMano = 0;
            j2.puntaje = 0;
            j2.estaJugando = false;
            j2.esMano = false;

        }
        /// <summary>
        /// Administra la jugada, canta truco y lo responde, lo escribe a traves de un delegado Action
        /// y cambia las banderas recibidas, para cada caso
        /// </summary>
        /// <param name="conveniencia"></param>
        /// <param name="seCantoTruco"></param>
        /// <param name="quizoTruco"></param>
        /// <returns></returns>int que representa el movimiento
        /// (1y2) para cantar truco, jugador mano y jugador pie respectivamente, 1 para querer truco
        /// (-1) truco no querido
        /// (0) si se pasa la jugada sin cantar
        /// 
        public int CantarTruco(int conveniencia,bool seCantoTruco, bool quizoTruco)
        {
            Naipe cartaMasAlta = ConsultarLaCartaMasAltaEnJuego();
            if (seCantoTruco==false && quizoTruco == false)            
            {                
                if(cartaMasAlta.ValorEnJuego > conveniencia)
                {
                    seCantoTruco=true;
                    CantoTruco = true;
                    cantar?.Invoke($"El jugador {Nombre}, canto Truco\n");

                    if (EsMano == true) { return 1; } else return 2;
                }
            }
            if (seCantoTruco==true && quizoTruco == false)
            {
                if(cartaMasAlta.ValorEnJuego > conveniencia)
                {
                    quizoTruco = true;
                    QuieroTruco = true;
                    cantar?.Invoke($"El jugador {Nombre}, dice quiero\n");
                    return 1;
                }
                else
                {
                    cantar?.Invoke($"El jugador {Nombre}, no quiero\n");
                    return -1;
                }
            }
            return 0;
        }
        /// <summary>
        /// devuelve la carta mas alta, tomando en cuenta su valor en juego
        /// </summary>
        /// <returns></returns>carta mas alta
        public Naipe ConsultarLaCartaMasAltaEnJuego()
        {
            if (tresCarta != null && tresCarta.Count == 3)
            {
                List<Naipe> listaOrdenada = new List<Naipe>();
                listaOrdenada = TresCarta.OrderByDescending(naipe => naipe.ValorEnJuego).ToList();
                return listaOrdenada[0];
            }
            throw (new Exception("No Existen Cartas en mano\n"));

        }

        /// <summary>
        /// Recibe Un Jugador, y devuelve de su Lista de 3 cartas, la referencia a la carta mas alta aun NO jugada
        /// le cambia la bandera es jugada al Naipe, para que no se pueda volver a utlizar
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>carta mas alta con si bool estajugada cambiado a true
        public Naipe JugarCartaMasAltaEnJuego()
        {
            if(tresCarta!=null && tresCarta.Count==3)
            {
                List<Naipe> listaOrdenada = new List<Naipe>();
                listaOrdenada = TresCarta.OrderByDescending(naipe => naipe.ValorEnJuego).ToList();

                foreach (Naipe unaCarta in listaOrdenada)
                {
                    if (unaCarta.EstaJugada == false)
                    {
                        unaCarta.EstaJugada = true;
                        return unaCarta;
                    }
                }            
            }

                throw (new Exception("ERROR!,Se quedo sin cartas, o es null, o mal el maso\n"));
             
            
        }
        /// <summary>
        /// Recibe una lista de jugadores precargados, y devuelve un jugador, que no se encuentre en juego
        /// </summary>
        /// <param name="listaDeJugadores"></param>
        /// <returns></returns>Un Jugador que no este jugando
        /// <exception cref="Exception"></exception>
        public static Jugador LlamarUnJugador(List<Jugador> listaDeJugadores)
        {
            if(listaDeJugadores!=null && listaDeJugadores.Count()>0)
            {
                foreach(Jugador unJugador in listaDeJugadores)
                {
                    if(unJugador.estaJugando == false)
                    {
                        unJugador.estaJugando = true;
                        return unJugador;                    
                    }                    
                }
                throw new Exception("Error!\nNo hay Jugadores disponibles");
            }
            throw new Exception("Error!\nNo encontro lista de jugadores");
        }

    }
}
