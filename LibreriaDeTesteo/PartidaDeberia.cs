using LIbreriaDelJuego;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDeTesteo
{
    
    [TestClass]
    public class PartidaDeberia
    {
        /// <summary>
        /// DefinirMano
        /// </summary>
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void DefinirManoOrdenIncorrecto()
        {
            Jugador nuevoJugador1 = new Jugador();
            Jugador nuevoJugador2 = new Jugador();
            Partida partida = new Partida();

            _ = partida.DefinirMano(nuevoJugador1, nuevoJugador2, -1);
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void DefinirManoJugadorNulo1()
        {
            Jugador nuevoJugador1 = null; 
            Jugador nuevoJugador2 = new Jugador();
            Partida partida = new Partida();

            _ = partida.DefinirMano(nuevoJugador1, nuevoJugador2, 0);
        }


        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void DefinirManoJugadorNulo2()
        {
            Jugador nuevoJugador1 = new Jugador();
            Jugador nuevoJugador2 = null;
            Partida partida = new Partida();

            _ = partida.DefinirMano(nuevoJugador1, nuevoJugador2, 0);
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void DefinirManoJugadorDosFalse()
        {
            Jugador nuevoJugador1 = new Jugador();
            Jugador nuevoJugador2 = new Jugador();

            Partida partida = new Partida();

           _ = partida.DefinirMano(nuevoJugador1, nuevoJugador2, 0);
        }


        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void DefinirManoJugadorDosTrue()
        {
            Jugador nuevoJugador1 = new Jugador();
            Jugador nuevoJugador2 = new Jugador();
            nuevoJugador1.EsMano = true;
            nuevoJugador2.EsMano = true;

            Partida partida = new Partida();

            _ = partida.DefinirMano(nuevoJugador1, nuevoJugador2, 0);
        }


        [TestMethod]
        public void DefinirManoJugadorCorrectamente()
        {
            Jugador nuevoJugador1 = new Jugador();
            Jugador nuevoJugador2 = new Jugador();
            nuevoJugador1.EsMano = true;
            nuevoJugador2.EsMano = false;

            Partida partida = new Partida();

            Jugador jugadorMano = partida.DefinirMano(nuevoJugador1, nuevoJugador2, 0);
            Jugador jugadorPie = partida.DefinirMano(nuevoJugador1, nuevoJugador2, 1);

            Assert.IsTrue(jugadorMano.EsMano);
            Assert.IsFalse(jugadorPie.EsMano);
        }

        /// <summary>
        /// CambiarMano
        /// </summary>
       
       [TestMethod]
        public void CambiarManoCorrectamente()
        {
            Jugador nuevoJugador1 = new Jugador();
            Jugador nuevoJugador2 = new Jugador();
            nuevoJugador1.EsMano = true;
            nuevoJugador2.EsMano = false;

            Partida partida = new Partida();

            partida.CambiarMano(nuevoJugador1, nuevoJugador2);           

            Assert.IsTrue(nuevoJugador2.EsMano);
            Assert.IsFalse(nuevoJugador1.EsMano);
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void CambiarManoJugadorDosTrue()
        {
            Jugador nuevoJugador1 = new Jugador();
            Jugador nuevoJugador2 = new Jugador();
            nuevoJugador1.EsMano = true;
            nuevoJugador2.EsMano = true;

            Partida partida = new Partida();

            partida.CambiarMano(nuevoJugador1, nuevoJugador2);
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void CambiarManoJugadorDosFalse()
        {
            Jugador nuevoJugador1 = new Jugador();
            Jugador nuevoJugador2 = new Jugador();
            nuevoJugador1.EsMano = false;
            nuevoJugador2.EsMano = false;

            Partida partida = new Partida();

            partida.CambiarMano(nuevoJugador1, nuevoJugador2);
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void CambiarManoNulls()
        {
            Jugador nuevoJugador1 = null;
            Jugador nuevoJugador2 = null;

            Partida partida = new Partida();

            partida.CambiarMano(nuevoJugador1, nuevoJugador2);
        }

    }
}
