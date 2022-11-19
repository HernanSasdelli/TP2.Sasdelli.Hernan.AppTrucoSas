using LIbreriaDelJuego;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDeTesteo
{

    /// <summary>
    /// ConsultarCartaMasAlta(valor en juego)
    /// </summary>
    [TestClass]     
    public class JugadorDeberia
    {
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ConsultarLaCartaMasAltaLanzarExNulo()
        {
            Jugador nuevoJugador = new Jugador();

            _ = nuevoJugador.ConsultarLaCartaMasAltaEnJuego();       
        
        }


        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ConsultarLaCartaMasAltaLanzarExMenosCartas()
        {
            Jugador nuevoJugador = new Jugador();
            nuevoJugador.TresCarta.Add(new Naipe(11, 6, "espada", false));
            nuevoJugador.TresCarta.Add(new Naipe(11, 6, "oro", false));

            _ = nuevoJugador.ConsultarLaCartaMasAltaEnJuego();

        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ConsultarLaCartaMasAltaLanzarExMasCartas()
        {
            Jugador nuevoJugador = new Jugador();
            nuevoJugador.TresCarta.Add(new Naipe(11, 6, "espada", false));
            nuevoJugador.TresCarta.Add(new Naipe(11, 5, "oro", false));
            nuevoJugador.TresCarta.Add(new Naipe(11, 5, "copa", false));
            nuevoJugador.TresCarta.Add(new Naipe(11, 5, "basto", false));

            _ = nuevoJugador.ConsultarLaCartaMasAltaEnJuego();
        }
        [TestMethod]
        public void ConsultarLaCartaMasAlta()
        {
            Jugador nuevoJugador = new Jugador();
            nuevoJugador.TresCarta.Add(new Naipe(11, 6, "espada", false));
            nuevoJugador.TresCarta.Add(new Naipe(11, 5, "oro", false));
            nuevoJugador.TresCarta.Add(new Naipe(11, 5, "copa", false));
            int valorEsperado = nuevoJugador.TresCarta[0].ValorEnJuego;

            Assert.AreEqual(valorEsperado, nuevoJugador.ConsultarLaCartaMasAltaEnJuego().ValorEnJuego);

        }

        /// <summary>
        /// JugarCartaMasAlta(valorEnJuego)
        /// </summary>

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void JugarLaCartaMasAltaLanzarExMasCartas()
        {
            Jugador nuevoJugador = new Jugador();
            nuevoJugador.TresCarta.Add(new Naipe(11, 6, "espada", false));
            nuevoJugador.TresCarta.Add(new Naipe(11, 5, "oro", false));
            nuevoJugador.TresCarta.Add(new Naipe(11, 5, "copa", false));
            nuevoJugador.TresCarta.Add(new Naipe(11, 5, "basto", false));

            _ = nuevoJugador.JugarCartaMasAltaEnJuego();
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void JugarLaCartaMasAltaLanzarExMenosCartas()
        {
            Jugador nuevoJugador = new Jugador();
            nuevoJugador.TresCarta.Add(new Naipe(11, 6, "espada", false));
            nuevoJugador.TresCarta.Add(new Naipe(11, 5, "oro", false));

            _ = nuevoJugador.JugarCartaMasAltaEnJuego();
        }


        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void JugarLaCartaMasAltaLanzarExNull()
        {
            Jugador nuevoJugador = new Jugador();

            _ = nuevoJugador.JugarCartaMasAltaEnJuego();
        }


       
        [TestMethod]
        public void JugarLaCartaMasAltaCorrectamente()
        {
            Jugador nuevoJugador = new Jugador();
            nuevoJugador.TresCarta.Add(new Naipe(1,14, "espada", false));
            nuevoJugador.TresCarta.Add(new Naipe(11, 5, "oro", false));
            nuevoJugador.TresCarta.Add(new Naipe(11, 5, "espada", false));

            Naipe cartaEsperada = nuevoJugador.TresCarta[0];

            Naipe cartaMasAlta = nuevoJugador.JugarCartaMasAltaEnJuego();

            Assert.AreEqual(cartaEsperada, cartaMasAlta);

        }

    }
}
