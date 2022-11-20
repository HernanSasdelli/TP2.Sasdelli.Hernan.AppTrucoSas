
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbreriaDelJuego
{
    public static class SalonPrincipal
    {
        public static List<Sala> listaDeSalas2 = new List<Sala>();



        public static List<Jugador> listaJugadores = new List<Jugador>();
        static SalonPrincipal()
        {
            listaJugadores = SQLConeccion.JugadoresDisponibles();
        }
            

            

       
    }
}
