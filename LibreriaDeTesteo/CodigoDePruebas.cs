using LIbreriaDelJuego;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDeTesteo
{
    public class CodigoDePruebas
    {
        public static List<Naipe> nuloTresCartas = new List<Naipe>();
        public static List<Naipe> dosCartasNoTres = new List<Naipe>();
        public static List<Naipe> cuatroCartasNoTres = new List<Naipe>();
        public static List<Naipe> tresCartasIguales = new List<Naipe>();

        public CodigoDePruebas()
        {
            CargarCartasIguales(tresCartasIguales);
            CargarDosCartas(dosCartasNoTres);
            CargarCuatroCartas(cuatroCartasNoTres);
        }
        public static void CargarCartasIguales(List<Naipe> tresCartasPrueba)
        {
            tresCartasPrueba.Add(new Naipe(5, 2, "basto", false));
            tresCartasPrueba.Add(new Naipe(5, 2, "basto", false));
            tresCartasPrueba.Add(new Naipe(5, 2, "basto", false));
        }
        public static void CargarDosCartas(List<Naipe> tresCartasPrueba)
        {
            tresCartasPrueba.Add(new Naipe(5, 2, "basto", false));
            tresCartasPrueba.Add(new Naipe(6, 3, "basto", false));

        }
        public static void CargarCuatroCartas(List<Naipe> tresCartasPrueba)
        {
            tresCartasPrueba.Add(new Naipe(4, 1, "basto", false));
            tresCartasPrueba.Add(new Naipe(5, 2, "basto", false));
            tresCartasPrueba.Add(new Naipe(6, 3, "basto", false));
            tresCartasPrueba.Add(new Naipe(7, 4, "basto", false));
        }

    }
}
