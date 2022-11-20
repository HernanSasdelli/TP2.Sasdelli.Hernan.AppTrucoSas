using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbreriaDelJuego
{
    public class Naipe
    {
        int numeroNominal;
        int valorEnJuego;
        string palo;
        bool estaJugada;


        public Naipe()
        {


        }
        public Naipe(int numeroNominal, int valorEnJuego, string palo, bool estaJugada):this()
        {
            this.NumeroNominal = numeroNominal;
            this.ValorEnJuego = valorEnJuego;
            this.Palo = palo;
            this.EstaJugada = estaJugada;

        }

        public int NumeroNominal { get => numeroNominal; set => numeroNominal = value; }
        public int ValorEnJuego { get => valorEnJuego; set => valorEnJuego = value; }
        public string Palo { get => palo; set => palo = value; }
        public bool EstaJugada { get => estaJugada; set => estaJugada = value; }

        public static void SerializarCartas()
        {
            int numeroDeCarta = 0;
            string carta;
            List<Naipe> listaDeCartas = new List<Naipe>();
            listaDeCartas = Naipe.CargarCartas();
           
           PISerializadoraGenerica<Naipe> guardarLosNaipes = new PJsonSerializadora<Naipe>();
           foreach(Naipe unNaipe in listaDeCartas)
           {
                numeroDeCarta++;
                carta = "cartaNro" + numeroDeCarta.ToString();
                guardarLosNaipes.Escribir(unNaipe, carta);

           }
         

        }        
        public static List<Naipe> DeserealizarCartas()
        {
            string carta;

            List<Naipe> listaDeCartas = new List<Naipe>();

            for(int i = 1; i < 41; i++)
            {
                PISerializadoraGenerica<Naipe> recuperar = new PJsonSerializadora<Naipe>();
                carta = "cartaNro" + i.ToString();
                Naipe naipe = recuperar.Leer(carta);
                
                listaDeCartas.Add(naipe);
            }

            return listaDeCartas;
        }

        public static List<Naipe> CargarCartas()
        {
            List<Naipe> masoACargar = new List<Naipe>();
            masoACargar.Add(new Naipe(1, 14, "espada", false));
            masoACargar.Add(new Naipe(2, 9, "espada", false));
            masoACargar.Add(new Naipe(3, 10, "espada", false));
            masoACargar.Add(new Naipe(4, 1, "espada", false));
            masoACargar.Add(new Naipe(5, 2, "espada", false));
            masoACargar.Add(new Naipe(6, 3, "espada", false));
            masoACargar.Add(new Naipe(7, 12, "espada", false));
            masoACargar.Add(new Naipe(10, 5, "espada", false));
            masoACargar.Add(new Naipe(11, 6, "espada", false));
            masoACargar.Add(new Naipe(12, 7, "espada", false));


            masoACargar.Add(new Naipe(1, 13, "basto", false));
            masoACargar.Add(new Naipe(2, 9, "basto", false));
            masoACargar.Add(new Naipe(3, 10, "basto", false));
            masoACargar.Add(new Naipe(4, 1, "basto", false));
            masoACargar.Add(new Naipe(5, 2, "basto", false));
            masoACargar.Add(new Naipe(6, 3, "basto", false));
            masoACargar.Add(new Naipe(7, 4, "basto", false));
            masoACargar.Add(new Naipe(10, 5, "basto", false));
            masoACargar.Add(new Naipe(11, 6, "basto", false));
            masoACargar.Add(new Naipe(12, 7, "basto", false));


            masoACargar.Add(new Naipe(1, 8, "oro", false));
            masoACargar.Add(new Naipe(2, 9, "oro", false));
            masoACargar.Add(new Naipe(3, 10, "oro", false));
            masoACargar.Add(new Naipe(4, 1, "oro", false));
            masoACargar.Add(new Naipe(5, 2, "oro", false));
            masoACargar.Add(new Naipe(6, 3, "oro", false));
            masoACargar.Add(new Naipe(7, 11, "oro", false));
            masoACargar.Add(new Naipe(10, 5, "oro", false));
            masoACargar.Add(new Naipe(11, 6, "oro", false));
            masoACargar.Add(new Naipe(12, 7, "oro", false));


            masoACargar.Add(new Naipe(1, 8, "copa", false));
            masoACargar.Add(new Naipe(2, 9, "copa", false));
            masoACargar.Add(new Naipe(3, 10, "copa", false));
            masoACargar.Add(new Naipe(4, 1, "copa", false));
            masoACargar.Add(new Naipe(5, 2, "copa", false));
            masoACargar.Add(new Naipe(6, 3, "copa", false));
            masoACargar.Add(new Naipe(7, 4, "copa", false));
            masoACargar.Add(new Naipe(10, 5, "copa", false));
            masoACargar.Add(new Naipe(11, 6, "copa", false));
            masoACargar.Add(new Naipe(12, 7, "copa", false));

            return masoACargar;

        }
    }
}
