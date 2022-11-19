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
    public class TrucoDeberiacs
    {
        
        [DataRow(0, 0)]
        [DataRow(1, 1)]
        [DataRow(1, 2)]
        [TestMethod]
        public void DefinirJugadaCorrectamente(int jugada1, int jugada2)
        {
            int jugada = Truco.DefinirJugadas(jugada1, jugada2);
            int jugadaEsperada = 0;

            Assert.AreEqual(jugadaEsperada, jugada);

        }
        [DataRow(1, 0)]
        [DataRow(0, 1)]
        [DataRow(0, 2)]
        [TestMethod]
        public void DefinirJugadaCorrectamente2(int jugada1, int jugada2)
        {
            int jugada = Truco.DefinirJugadas(jugada1, jugada2);
            int jugadaEsperada = 1;

            Assert.AreEqual(jugadaEsperada, jugada);

        }

    }
}
