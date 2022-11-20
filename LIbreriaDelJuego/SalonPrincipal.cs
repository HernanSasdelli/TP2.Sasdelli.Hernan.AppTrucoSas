
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
        public static List<Naipe> listaNaipePrincipal = new List<Naipe>();

        static SalonPrincipal()
        {
            PConexionSQL  nuevaConexionSQL = new PConexionSQL();
            listaJugadores = nuevaConexionSQL.JugadoresDisponibles();
            listaNaipePrincipal = DecidirSiSerializarCartas();
            
        }
            
        public static List<Sala> ActualizarSalasEnJuego(List<Sala> listaDeSalas)
        {
            if(listaDeSalas!=null)
            {
                List<Sala> salasDisponibles = new List<Sala>();

                salasDisponibles = listaDeSalas.FindAll((sala) => sala.terminoPartida.Equals(false));

                return salasDisponibles;
            }
            throw new Exception("ERROR!\nNo fue posible conectar los Jugadores");
        }

        public static List<Naipe> DecidirSiSerializarCartas()
        {
            List<Naipe> listaNaipePrincipal = new List<Naipe>();
            try
            {
                listaNaipePrincipal = Naipe.DeserealizarCartas();
            }
            catch(Exception)
            {
                Naipe.SerializarCartas();
                listaNaipePrincipal = Naipe.DeserealizarCartas();
            }
            return listaNaipePrincipal;
        }
       
    }
}
