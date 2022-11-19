using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbreriaDelJuego
{
    public class Envido
    {
                /////////////////////////ENVIDO////////////////////////////////

        /// <summary>
        /// Evalua las posibilidades de combinar las cartas para formar una jugada de envido
        /// </summary>
        /// <param name="tresCartasJugador"></param>
        /// <returns></returns>(-1) Flor, 3 cartas con el mismo palo;
        /// (entre 20 y 33) Envido,suma dos cartas con el mismo palo entre 1 y 7 sumando hasta 33
        /// (entre 1 y 7) si todas las cartas son diferente palo devuelve el valor de la mas alta
        /// (0) si no tiene tantos, ej.: 10, 11 y 12 de distintos palos
        public static int CalcularEnvidoOFlor(List<Naipe> tresCartasJugador)
        {
            if (VerificarCartasDistintasYNoNulas(tresCartasJugador))
            {

                if (tresCartasJugador[0].Palo == tresCartasJugador[1].Palo &&
                    tresCartasJugador[0].Palo == tresCartasJugador[2].Palo)
                {
                    return -1;
                }
                else if (Hay2MismoPalo(tresCartasJugador) == true)
                {
                    return SumarEnvido(tresCartasJugador);
                }
                else
                    return CartaMasAlta(tresCartasJugador);
            }
            throw new Exception();

        }

        private static int SumarEnvido(List<Naipe> tresCartas)
        {
            if (VerificarCartasDistintasYNoNulas(tresCartas))
            {
                List<Naipe> listaOrdenada = new List<Naipe>();
                listaOrdenada = tresCartas.OrderByDescending(Naipe => Naipe.NumeroNominal).ToList();
                if (listaOrdenada[0].Palo == listaOrdenada[1].Palo)
                {
                    return FiltarSotasParaEnvido(listaOrdenada[0], listaOrdenada[1]);
                }
                if (listaOrdenada[0].Palo == listaOrdenada[2].Palo)
                {
                    return FiltarSotasParaEnvido(listaOrdenada[0], listaOrdenada[2]);
                }
                if (listaOrdenada[1].Palo == listaOrdenada[2].Palo)
                {
                    return FiltarSotasParaEnvido(listaOrdenada[1], listaOrdenada[2]);
                }

            }
            throw new Exception();
        }
        
        /// <summary>
         /// Recibe dos cartas del mismo palo, y suma los tantos del envido, partiendo de 20 unidades
         /// </summary>
         /// <param name="carta1"></param>
         /// <param name="carta2"></param>
         /// <returns></returns> Retorna 20 unidades o mas, hasta 33, si no esta dentro de esos parametros recibe 0;
        public static int FiltarSotasParaEnvido(Naipe carta1, Naipe carta2)
        {
            if (carta1 != null && carta2 != null)
            {   
                if(carta1.Equals(carta2))
                {
                    throw new Exception("ERROR!\nLas Cartas son de palos distintos");
                }
                else
                {
                    if (carta1.Palo.Equals(carta2.Palo))
                    {
                        int acum = 20;
                        if (carta1.NumeroNominal < 8)
                        { acum = acum + carta1.NumeroNominal; }

                        if (carta2.NumeroNominal < 8)
                        { acum = acum + carta2.NumeroNominal; }

                        if (acum > 33)
                        { throw new Exception("ERROR!\nError! Error en el maso"); }

                        return acum;
                    }


                }
                throw new Exception("ERROR!\nLas Cartas son iguales");

            }
            throw new Exception("ERROR!\nNo hay cartas");

        }

        /// <summary>
        /// Chequea que haya dos cartas del mismo palo, dentro de una lista de 3 cartas
        /// </summary>
        /// <param name="tresCartas"></param>
        /// <returns></returns>Si hay dos cartas del mismo palo, devuelve True cuando encuentra las dos primeras, false si los palos son todos iguales
        public static bool Hay2MismoPalo(List<Naipe> tresCartas)
        {
            if (VerificarCartasDistintasYNoNulas(tresCartas))
            {
                if (tresCartas[0].Palo == tresCartas[1].Palo ||
                tresCartas[0].Palo == tresCartas[2].Palo ||
                tresCartas[2].Palo == tresCartas[1].Palo)
                {
                    return true;
                }
                return false;
            }
            throw new Exception();
        }

        /// <summary>
        /// Busca la carta mas alta de una lista de 3 Naipes
        /// </summary>
        /// <param name="tresCartas"></param>
        /// <returns></returns>Carta mas alta, del 1 a 7, no toma en cuenta las sotas
        public static int CartaMasAlta(List<Naipe> tresCartas)
        {
            if(VerificarCartasDistintasYNoNulas(tresCartas))
            {
                List<Naipe> listaOrdenada = new List<Naipe>();
                listaOrdenada = tresCartas.OrderByDescending(Naipe => Naipe.NumeroNominal).ToList();
                if (listaOrdenada[0].NumeroNominal <= 7)
                {
                    return listaOrdenada[0].NumeroNominal;
                }
                else if (listaOrdenada[1].NumeroNominal <= 7)
                {
                    return listaOrdenada[1].NumeroNominal;
                }
                else if (listaOrdenada[2].NumeroNominal <= 7)
                {
                    return listaOrdenada[2].NumeroNominal;
                }
                return 0;
            }
            throw new Exception();
        }
        /// <summary>
        /// Resuelve los puntos recibidos de cada jugador, dependiendo de las jugadas que se realizaron
        /// </summary>
        /// <param name="jugadorMano"></param>
        /// <param name="jugadorPie"></param>
        /// <param name="jugada1"></param>
        /// <param name="jugada2"></param>
        /// <param name="jugada"></param>
        public static void SumarPuntos(Jugador jugadorMano, Jugador jugadorPie,
            int jugada1, int jugada2, Action<string>? jugada)
        {
            if (jugada1 == -1)
            {
                jugadorMano.Puntaje = jugadorMano.Puntaje + 3;
                jugada?.Invoke( $"{jugadorMano.Nombre} Suma 3 puntos de la flor\n");                

            }
            if (jugada2 == -1)
            {
                jugadorPie.Puntaje = jugadorPie.Puntaje + 3;
                jugada?.Invoke($"{jugadorPie.Nombre} Suma 3 puntos de la flor\n");
                
            }
            if ((jugada1 == 1 && jugada2 == 1) || (jugada1 == 1 && jugada2 == 2))
            {
                int tantos1 = CalcularEnvidoOFlor(jugadorMano.TresCarta);
                int tantos2 = CalcularEnvidoOFlor(jugadorPie.TresCarta);
                if (tantos1 >= tantos2)
                {
                    jugadorMano.Puntaje = jugadorMano.Puntaje + 2;
                    jugada?.Invoke($"{jugadorMano.Nombre} Gana 2 puntos del envido con {tantos1} de mano\n");
                   
                }
                else if (tantos1 < tantos2)
                {
                    jugadorPie.Puntaje = jugadorPie.Puntaje + 2;
                    jugada?.Invoke($"{jugadorPie.Nombre} Gana 2 puntos del envido con {tantos2}\n"); 
                    
                }
            }
            else if (jugada1 == -2)
            {
                jugadorPie.Puntaje++;
                jugada?.Invoke($"{jugadorPie.Nombre} Gana 1 punto por envido no querido\n");                

            }
            else if (jugada2 == -2)
            {
                jugadorMano.Puntaje++;
                jugada?.Invoke($"{jugadorMano.Nombre} Gana 1 punto por envido no querido\n");                

            }
        }

        public static bool VerificarCartasDistintasYNoNulas(List<Naipe> tresCartas)
        {
            if (tresCartas != null)
            {
                if (tresCartas.Count == 3)
                {
                    if (tresCartas[0] == tresCartas[1] || tresCartas[0] == tresCartas[2] || tresCartas[1] == tresCartas[2])
                    {
                        throw new Exception("ERROR!\nError en el maso");

                    }
                    else {return true; }
                                                
                }
                else
                    throw new Exception("ERROR!\nNo se recibieron 3 cartas");
            }
            else
                throw new Exception("ERROR!\nNo se recibieron las 3 cartas del jugador");

        }

    }
}
