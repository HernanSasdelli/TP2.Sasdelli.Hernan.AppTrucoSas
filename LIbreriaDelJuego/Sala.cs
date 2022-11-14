using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbreriaDelJuego
{
    public class Sala
    {
        Jugador jugador1 = new Jugador("Hernan");
        Jugador jugador2 = new Jugador("Juanse");


        public static List<string> lista = new List<string>(); // era para el registro, al reemplazar definitivamente borrar
        private List<Naipe> mazoDeSala = new List<Naipe>();//memoria para copiar el maso de cartas

        public Action<string> mostrarJugadas = GrabarEnRegistro;

        public Sala()
        {
            LogicaDelJuego nuevoJuego = new LogicaDelJuego();
            nuevoJuego.TheGameIsBeginning(mostrarJugadas);

        }

        public List<Naipe> MazoDeSala { get => mazoDeSala; set => mazoDeSala = value; }
        public Jugador Jugador1 { get => jugador1; set => jugador1 = value; }
        public Jugador Jugador2 { get => jugador2; set => jugador2 = value; }
        

        public static void GrabarEnRegistro(string registro)
        {
            lista.Add(registro);
        }
    }
}
