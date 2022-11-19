using LIbreriaDelJuego;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LibreriaDeTesteo
{
    [TestClass]
    public class EnvidoDeberia
    {
        /// <summary>
        /// CalcularEnvidoOFlor
        /// </summary>
 

        [TestMethod]
        public void CalcularFlorCorrectamente()
        {
            int calculoDeEnvido;
            List<Naipe> tresCartasPrueba=new List<Naipe>();
            tresCartasPrueba.Add(new Naipe(5, 2, "basto", false));
            tresCartasPrueba.Add(new Naipe(6, 3, "basto", false));
            tresCartasPrueba.Add(new Naipe(7, 4, "basto", false));
            int seEspera = -1;// (flor)

            calculoDeEnvido = Envido.CalcularEnvidoOFlor(tresCartasPrueba);

            Assert.AreEqual(calculoDeEnvido,seEspera);
        }
        [TestMethod]
        public void CalcularEnvidoCorrectamente()
        {
            List<Naipe> tresCartasPrueba = new List<Naipe>();
            tresCartasPrueba.Add(new Naipe(5, 2, "basto", false));
            tresCartasPrueba.Add(new Naipe(6, 3, "espada", false));
            tresCartasPrueba.Add(new Naipe(7, 4, "basto", false));
            int seEspera = 32;

            List<Naipe> tresCartasPrueba2 = new List<Naipe>();
            tresCartasPrueba2.Add(new Naipe(10, 5, "basto", false));
            tresCartasPrueba2.Add(new Naipe(6, 3, "espada", false));
            tresCartasPrueba2.Add(new Naipe(4, 1, "oro", false));
            int seEspera2 = 6;

            List<Naipe> tresCartasPrueba3 = new List<Naipe>();
            tresCartasPrueba3.Add(new Naipe(10, 5, "basto", false));
            tresCartasPrueba3.Add(new Naipe(11, 6, "espada", false));
            tresCartasPrueba3.Add(new Naipe(12, 7, "oro", false));
            int seEspera3 = 0;

            int calculoDeEnvido = Envido.CalcularEnvidoOFlor(tresCartasPrueba);
            int calculoDeEnvido2 = Envido.CalcularEnvidoOFlor(tresCartasPrueba2);
            int calculoDeEnvido3 = Envido.CalcularEnvidoOFlor(tresCartasPrueba3);

            Assert.AreEqual(seEspera, calculoDeEnvido);
            Assert.AreEqual(seEspera2, calculoDeEnvido2);
            Assert.AreEqual(seEspera3, calculoDeEnvido3);
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ErrorPorCartasigualesEnLista()
        {
            List<Naipe> tresCartasPrueba = new List<Naipe>();

            Naipe naipe1 = new Naipe(10, 5, "oro", false);
            Naipe naipe2 = naipe1;
            Naipe naipe3 = new Naipe(11, 6, "oro", false);

            _ = Envido.CalcularEnvidoOFlor(tresCartasPrueba);
        }



        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void DarErrorPorMenosCartas()
        {
            List<Naipe> tresCartasPrueba = new List<Naipe>();
            tresCartasPrueba.Add(new Naipe(5, 2, "basto", false));
            tresCartasPrueba.Add(new Naipe(5, 2, "basto", false));


            _ = Envido.CalcularEnvidoOFlor(tresCartasPrueba);
        }


        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void DarErrorPorCartasDeMas()
        {
            List<Naipe> tresCartasPrueba = new List<Naipe>();
            tresCartasPrueba.Add(new Naipe(5, 2, "basto", false));
            tresCartasPrueba.Add(new Naipe(5, 2, "basto", false));
            tresCartasPrueba.Add(new Naipe(7, 4, "basto", false));
            tresCartasPrueba.Add(new Naipe(12, 7, "basto", false));


            _ = Envido.CalcularEnvidoOFlor(tresCartasPrueba);
        }


        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void DarErrorPorVacio()
        {
            List<Naipe> tresCartasPrueba = new List<Naipe>();

            _ = Envido.CalcularEnvidoOFlor(tresCartasPrueba);
        }



        /// <summary>
        /// /Filtrar sotas
        /// </summary>

        [TestMethod]
        public void SumarEnvidoDeDosCartasMismoPalo()
        {
            Naipe naipe1 = new Naipe(12, 7, "oro", false);
            Naipe naipe2 = new Naipe(10, 5, "oro", false);

            Naipe naipe3 = new Naipe(7, 4, "basto", false);
            Naipe naipe4 = new Naipe(10, 5, "basto", false);

            Naipe naipe5 = new Naipe(7, 4, "basto", false);
            Naipe naipe6 = new Naipe(1, 13, "basto", false);

            int valorEsperado1 = 20;
            int valorEsperado2 = 27;
            int valorEsperado3 = 28;

            int valor1 = Envido.FiltarSotasParaEnvido(naipe1,naipe2);
            int valor2 = Envido.FiltarSotasParaEnvido(naipe3,naipe4);
            int valor3 = Envido.FiltarSotasParaEnvido(naipe5,naipe6);

            Assert.AreEqual(valorEsperado1, valor1);
            Assert.AreEqual(valorEsperado2, valor2);
            Assert.AreEqual(valorEsperado3, valor3);
        }
      

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ErrorPorCartasNulas()
        {
            Naipe? naipe1 = null;
            Naipe naipe2 = new Naipe(10, 5, "oro", false);

            _ = Envido.FiltarSotasParaEnvido(naipe1, naipe2);
        }


        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ErrorPorCartasIguales()
        {
            Naipe naipe1 = new Naipe(10, 5, "oro", false);
            Naipe naipe2 = naipe1;

            _ = Envido.FiltarSotasParaEnvido(naipe1, naipe2);
        }


        /// <summary>
        /// HayDosMismoPalo
        /// </summary>
        [TestMethod]
        public void DevolverTrueSiHayDosCartasDelMismoPalo()
        {
            List<Naipe> tresCartasPrueba = new List<Naipe>();
            tresCartasPrueba.Add(new Naipe(5, 2, "oro", false));
            tresCartasPrueba.Add(new Naipe(6, 3, "espada", false));
            tresCartasPrueba.Add(new Naipe(7, 4, "basto", false));
            

            List<Naipe> tresCartasPrueba2 = new List<Naipe>();
            tresCartasPrueba2.Add(new Naipe(5, 2, "oro", false));
            tresCartasPrueba2.Add(new Naipe(6, 3, "oro", false));
            tresCartasPrueba2.Add(new Naipe(7, 4, "basto", false));

            bool seEspera = Envido.Hay2MismoPalo(tresCartasPrueba);
            bool seEspera2 = Envido.Hay2MismoPalo(tresCartasPrueba2);

            Assert.IsFalse(seEspera);
            Assert.IsTrue(seEspera2);            
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void DarErrorPorVacio2()
        {
            List<Naipe> tresCartasPrueba = new List<Naipe>();

            _ = Envido.Hay2MismoPalo(tresCartasPrueba);
        }


        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void DarErrorPorMenosCartas2()
        {
            List<Naipe> tresCartasPrueba = new List<Naipe>();
            tresCartasPrueba.Add(new Naipe(5, 2, "basto", false));
            tresCartasPrueba.Add(new Naipe(5, 2, "basto", false));


            _ = Envido.Hay2MismoPalo(tresCartasPrueba);
        }


        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void DarErrorPorCartasIguales()
        {
            List<Naipe> tresCartasPrueba = new List<Naipe>();
            tresCartasPrueba.Add(new Naipe(5, 2, "basto", false));
            tresCartasPrueba.Add(new Naipe(5, 2, "basto", false));
            Naipe naipe1= tresCartasPrueba[0];
            tresCartasPrueba.Add(naipe1);

            _ = Envido.Hay2MismoPalo(tresCartasPrueba);
        }



        /// <summary>
        /// CartaMasAlta, se comprueba solo funcionamiento correcto
        /// Nullidad, cartas iguales, menos o mas cartas recibidas, queda comprobado en los test anteriores por el metodo:
        /// bool VerificarCartasDistintasYNoNulas(List<Naipe> tresCartas); que comparten las funciones, y ademas se testea 
        /// al final de esta clase Test
        /// </summary>
        [TestMethod]
        public void DevolverCartaMasAltaSinSotas()
        {
            List<Naipe> tresCartasPrueba = new List<Naipe>();
            tresCartasPrueba.Add(new Naipe(5, 2, "oro", false));
            tresCartasPrueba.Add(new Naipe(6, 3, "espada", false));
            tresCartasPrueba.Add(new Naipe(7, 4, "basto", false));

            List<Naipe> tresCartasPrueba2 = new List<Naipe>();
            tresCartasPrueba2.Add(new Naipe(12, 7, "oro", false));
            tresCartasPrueba2.Add(new Naipe(10, 5, "espada", false));
            tresCartasPrueba2.Add(new Naipe(7, 4, "basto", false));

            int seEspera = 7;
            int seEspera2 = 7;

            int valor1 = Envido.CartaMasAlta(tresCartasPrueba);
            int valor2 = Envido.CartaMasAlta(tresCartasPrueba2);

            Assert.AreEqual(seEspera, valor1);
            Assert.AreEqual(seEspera2, valor2);

        }


        /// <summary>
        /// VerificarCartasDistintasYNoNulas
        /// </summary>
        /// <param name="tresCartas"></param>

        [TestMethod]
        public void DevolverTrueSiLasCartasSonCorrectas()
        {
            List<Naipe> tresCartasPrueba = new List<Naipe>();
            tresCartasPrueba.Add(new Naipe(5, 2, "oro", false));
            tresCartasPrueba.Add(new Naipe(6, 3, "espada", false));
            tresCartasPrueba.Add(new Naipe(7, 4, "basto", false));

            List<Naipe> tresCartasPrueba2 = new List<Naipe>();
            tresCartasPrueba2.Add(new Naipe(12, 7, "oro", false));
            tresCartasPrueba2.Add(new Naipe(10, 5, "espada", false));
            tresCartasPrueba2.Add(new Naipe(7, 4, "basto", false));

            bool valor1 = Envido.VerificarCartasDistintasYNoNulas(tresCartasPrueba);
            bool valor2 = Envido.VerificarCartasDistintasYNoNulas(tresCartasPrueba2);

            Assert.IsTrue(valor1);
            Assert.IsTrue(valor2);

        }


        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void DarErrorPorCartasIguales2()
        {
            List<Naipe> tresCartasPrueba = new List<Naipe>();
            tresCartasPrueba.Add(new Naipe(5, 2, "basto", false));
            tresCartasPrueba.Add(new Naipe(5, 2, "basto", false));
            Naipe naipe1 = tresCartasPrueba[0];
            tresCartasPrueba.Add(naipe1);

            _ = Envido.VerificarCartasDistintasYNoNulas(tresCartasPrueba);
        }


        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void DarErrorPorMenosCartas3()
        {
            List<Naipe> tresCartasPrueba = new List<Naipe>();
            tresCartasPrueba.Add(new Naipe(5, 2, "basto", false));
            tresCartasPrueba.Add(new Naipe(5, 2, "basto", false));


            _ = Envido.VerificarCartasDistintasYNoNulas(tresCartasPrueba);
        }


        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void DarErrorPorCartasDeMas2()
        {
            List<Naipe> tresCartasPrueba = new List<Naipe>();
            tresCartasPrueba.Add(new Naipe(5, 2, "basto", false));
            tresCartasPrueba.Add(new Naipe(5, 2, "basto", false));
            tresCartasPrueba.Add(new Naipe(7, 4, "basto", false));
            tresCartasPrueba.Add(new Naipe(12, 7, "basto", false));


            _ = Envido.VerificarCartasDistintasYNoNulas(tresCartasPrueba);
        }
















    }
}