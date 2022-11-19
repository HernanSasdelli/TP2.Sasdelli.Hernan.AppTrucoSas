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
    public class RondaDeberia
    {
        /// <summary>
        /// irseAlMaso (metodo mas jodido de testear)
        /// </summary>
        [TestMethod]
        public void IrseAlMasoCorrectamente()
        {
            List<Naipe> masoEnUso = new List<Naipe>();//este esta vacio
            Ronda ronda = new Ronda();
            List<Naipe> auxiliar = new List<Naipe>();
            Jugador jugador = new Jugador();
            jugador.TresCarta.Add(new Naipe(1, 14, "espada", false));
            jugador.TresCarta.Add(new Naipe(2, 9, "espada", false));
            jugador.TresCarta.Add(new Naipe(3, 10, "espada", false));

            auxiliar.Add(jugador.TresCarta[0]);
            auxiliar.Add(jugador.TresCarta[1]);
            auxiliar.Add(jugador.TresCarta[2]);

            ronda.irseAlMaso(jugador, masoEnUso);

            CollectionAssert.AreEquivalent(auxiliar, masoEnUso);
            Assert.AreEqual(0,jugador.TresCarta.Count());        

        }


        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void IrseAlMasoNull()
        {
            List<Naipe> masoEnUso = null;
            Ronda ronda = new Ronda();

            Jugador jugador = new Jugador();
            jugador.TresCarta.Add(new Naipe(1, 14, "espada", false));
            jugador.TresCarta.Add(new Naipe(2, 9, "espada", false));
            jugador.TresCarta.Add(new Naipe(3, 10, "espada", false));

            ronda.irseAlMaso(jugador, masoEnUso);
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void IrseAlMasoJugadorNull()
        {
            List<Naipe> masoEnUso = new List<Naipe>();
            Ronda ronda = new Ronda();

            Jugador jugador = null;

            ronda.irseAlMaso(jugador, masoEnUso);
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void IrseAlMasoCartasDelJugadorNull()
        {
            List<Naipe> masoEnUso = new List<Naipe>();
            Ronda ronda = new Ronda();

            Jugador jugador = new Jugador();

            ronda.irseAlMaso(jugador, masoEnUso);
        }

        /// <summary>
        /// RepartirCartasPorJugador
        /// </summary>
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void RepartirCartasPorJugadorMasoNull()
        {
            List<Naipe> maso1 = new List<Naipe>();
            Ronda ronda = new Ronda();

           _ = ronda.RepartirCartasPorJugador(maso1);
        }

        [TestMethod]
        public void RepartirCartasCorrectamente()
        {
            Jugador jugador = new Jugador();
            List<Naipe> maso1 = Naipe.CargarCartas();
            int cartasTotales = maso1.Count();
            Ronda ronda = new Ronda();

            jugador.TresCarta = ronda.RepartirCartasPorJugador(maso1);

            Assert.AreEqual(cartasTotales, jugador.TresCarta.Count()+maso1.Count());
            Assert.AreEqual(3, jugador.TresCarta.Count());
            CollectionAssert.AllItemsAreUnique(jugador.TresCarta);
        }

    }
}
