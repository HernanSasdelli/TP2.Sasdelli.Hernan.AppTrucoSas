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
    public class SalaDeberia
    {
        /// <summary>
        /// ContadorPuntosManos
        /// </summary>
        [TestMethod]
        public void contarPuntosManoCorrectamente()
        {
            Naipe cartaMano = new Naipe(5, 2, "basto", true);
            Naipe cartaPie = new Naipe(6, 3, "basto", true);
            Jugador jugadorMano = new Jugador();
            Jugador jugadorPie = new Jugador();
            Sala sala = new Sala();            
            

            sala.ContadorPuntosMano(cartaMano,cartaPie,jugadorMano,jugadorPie);

            Assert.AreEqual(1, jugadorPie.PuntosPorMano);
            Assert.AreEqual(0, jugadorMano.PuntosPorMano);            
        }

        [TestMethod]
        public void contarPuntosManoCorrectamente2()
        {
            Naipe cartaMano = new Naipe(5, 2, "basto", true);
            Naipe cartaPie = new Naipe(5, 2, "basto", true);
            Jugador jugadorMano = new Jugador();
            Jugador jugadorPie = new Jugador();
            Sala sala = new Sala();

            sala.ContadorPuntosMano(cartaMano, cartaPie, jugadorMano, jugadorPie);

            Assert.AreEqual(0, jugadorPie.PuntosPorMano);
            Assert.AreEqual(1, jugadorMano.PuntosPorMano);
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void contarPuntosManoJugadorNull()
        {
            Naipe cartaMano = new Naipe(5, 2, "basto", true);
            Naipe cartaPie = new Naipe(6, 3, "basto", true);
            Jugador jugadorMano = null;
            Jugador jugadorPie = new Jugador();
            Sala sala = new Sala();


            sala.ContadorPuntosMano(cartaMano, cartaPie, jugadorMano, jugadorPie);
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void contarPuntosManoCartaNull()
        {
            Naipe cartaMano = new Naipe(5, 2, "basto", true);
            Naipe cartaPie = null;
            Jugador jugadorMano = new Jugador();
            Jugador jugadorPie = new Jugador();
            Sala sala = new Sala();


            sala.ContadorPuntosMano(cartaMano, cartaPie, jugadorMano, jugadorPie);
        }

        [DataRow(true,false)]
        [DataRow(false, true)]
        [DataRow(false, false)]
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void contarPuntosManoCartaNoJugada(bool cartaJugada1,bool cartaJugada2)
        {
            Naipe cartaMano = new Naipe(5, 2, "basto", cartaJugada1);
            Naipe cartaPie = new Naipe(5, 2, "basto", cartaJugada2);
            Jugador jugadorMano = new Jugador();
            Jugador jugadorPie = new Jugador();
            Sala sala = new Sala();

            sala.ContadorPuntosMano(cartaMano, cartaPie, jugadorMano, jugadorPie);
        }


        /// <summary>
        /// DefinirGanador
        /// </summary>
        [TestMethod]
        public void DefinirGanadorCorrectamente()
        {
            Jugador jugadorMano = new Jugador("Pepe");
            Jugador jugadorPie = new Jugador("Pepa");
            jugadorMano.PuntosPorMano++;

            Sala sala = new Sala();

            string nombreGanador = sala.DefinirGanador(jugadorMano, jugadorPie);

            Assert.AreEqual(nombreGanador, jugadorMano.Nombre);
            Assert.AreEqual(1, jugadorMano.PuntosPorMano);

        }


        [DataRow("","")]
        [DataRow(null,null)]
        [DataRow("", null)]
        [DataRow(null,"")]
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void DefinirGanadorNombresVacios(string nombre1, string nombre2)
        {
            Jugador jugadorMano = new Jugador(nombre1);
            Jugador jugadorPie = new Jugador(nombre2);
            jugadorMano.PuntosPorMano++;

            Sala sala = new Sala();

            _ = sala.DefinirGanador(jugadorMano, jugadorPie);

        }


    }
}

