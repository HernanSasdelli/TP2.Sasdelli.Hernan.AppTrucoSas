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
            if (tresCartasJugador != null && tresCartasJugador.Count() == 3)
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
            return 0;

        }

        private static int SumarEnvido(List<Naipe> tresCartas)
        {
            if (tresCartas != null && tresCartas.Count() == 3)
            {
                // int acum = 20;
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
            return 0;
        }
        private static int FiltarSotasParaEnvido(Naipe carta1, Naipe carta2)
        {
            int acum = 20;
            if (carta1 != null && carta2 != null)
            {

                if (carta1.NumeroNominal < 8)
                { acum = acum + carta1.NumeroNominal; }
                if (carta2.NumeroNominal < 8)
                { acum = acum + carta2.NumeroNominal; }

            }
            return acum;
        }


        private static bool Hay2MismoPalo(List<Naipe> tresCartas)
        {
            if (tresCartas != null && tresCartas.Count == 3)
            {
                if (tresCartas[0].Palo == tresCartas[1].Palo ||
                tresCartas[0].Palo == tresCartas[2].Palo ||
                tresCartas[2].Palo == tresCartas[1].Palo)
                {
                    return true;
                }

            }
            return false;
        }

        /// <summary>
        /// Busca la carta mas alta de una lista de 3 items
        /// </summary>
        /// <param name="tresCartas"></param>
        /// <returns></returns>Carta mas alta, del 1 a 7, no toma en cuenta las sotas
        private static int CartaMasAlta(List<Naipe> tresCartas)
        {
            if (tresCartas != null && tresCartas.Count() == 3)
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
            }
            return 0;
        }

        public static void SumarPuntos(Jugador jugadorMano, Jugador jugadorPie,
            int jugada1, int jugada2, List<string> registro)
        {
            if (jugada1 == -1)
            {
                jugadorMano.Puntaje = jugadorMano.Puntaje + 3;
                string canto = $"{jugadorMano.Nombre} Suma 3 puntos de la flor";
                registro.Add(canto);

            }
            if (jugada2 == -1)
            {
                jugadorPie.Puntaje = jugadorPie.Puntaje + 3;
                string canto = $"{jugadorPie.Nombre} Suma 3 puntos de la flor";
                registro.Add(canto);
            }
            if ((jugada1 == 1 && jugada2 == 1) || (jugada1 == 1 && jugada2 == 2))
            {
                int tantos1 = CalcularEnvidoOFlor(jugadorMano.TresCarta);
                int tantos2 = CalcularEnvidoOFlor(jugadorPie.TresCarta);
                if (tantos1 >= tantos2)
                {
                    jugadorMano.Puntaje = jugadorMano.Puntaje + 2;
                    string canto = $"{jugadorMano.Nombre} Gana 2 puntos del envido con {tantos1} de mano";
                    registro.Add(canto);
                }
                else if (tantos1 < tantos2)
                {
                    jugadorPie.Puntaje = jugadorPie.Puntaje + 2;
                    string canto = $"{jugadorPie.Nombre} Gana 2 puntos del envido con {tantos2}"; ;
                    registro.Add(canto);
                }
            }
            else if (jugada1 == -2)
            {
                jugadorPie.Puntaje++;
                string canto = $"{jugadorPie.Nombre} Gana 1 punto por envido no querido";
                registro.Add(canto);

            }
            else if (jugada2 == -2)
            {
                jugadorMano.Puntaje++;
                string canto = $"{jugadorMano.Nombre} Gana 1 punto por envido no querido";
                registro.Add(canto);

            }


        }
    }
}
