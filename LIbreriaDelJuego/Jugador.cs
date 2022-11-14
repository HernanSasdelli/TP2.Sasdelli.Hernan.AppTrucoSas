using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbreriaDelJuego
{
    public class Jugador
    {
        string? nombre;
        List<Naipe> tresCarta = new List<Naipe>();
        int puntaje;
        bool esMano;
        bool cantoEnvido;
        bool cantoTruco;
        bool cantoFlor;
        bool quieroEnvido;
        bool quieroTruco;

        public Jugador()
        {
            Puntaje = 0;
            EsMano = false;
            CantoEnvido = false;
            CantoTruco = false;
            QuieroEnvido = false;
            QuieroTruco = false;
            CantoFlor = false;
        }
        public Jugador(string nombre) : this()
        {
            this.nombre = nombre;

        }

        public List<Naipe> TresCarta { get => tresCarta; set => tresCarta = value; }
        public int Puntaje { get => puntaje; set => puntaje = value; }
        public bool EsMano { get => esMano; set => esMano = value; }
        public bool CantoEnvido { get => cantoEnvido; set => cantoEnvido = value; }
        public bool CantoTruco { get => cantoTruco; set => cantoTruco = value; }
        public bool QuieroEnvido { get => quieroEnvido; set => quieroEnvido = value; }
        public bool QuieroTruco { get => quieroTruco; set => quieroTruco = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public bool CantoFlor { get => cantoFlor; set => cantoFlor = value; }





        public int CantarEnvido(List<string> registro, int conveniencia,
            bool seCantoEnvido, bool seCantoFlor, Action<string> jugada)
        {
            int retorno = 0;

            int envido = Envido.CalcularEnvidoOFlor(TresCarta);
            if (envido == -1)
            {
                CantoFlor = true;
                jugada.Invoke($"{Nombre} canto Flor");

                string canto = $"{Nombre} canto Flor";
                registro.Add(canto);
                retorno = -1;
            }
            if (seCantoFlor == false)
            {
                if (envido > conveniencia && seCantoEnvido == false)
                {
                    CantoEnvido = true;

                    jugada.Invoke($"{Nombre} Canta Envido");
                    string canto = $"{Nombre} Canta Envido";
                    registro.Add(canto);
                    if (EsMano == true) { retorno = 1; } else { retorno = 2; }
                }
                else if (envido > conveniencia && seCantoEnvido == true)
                {
                    CantoEnvido = true;
                    jugada.Invoke($"{Nombre} Dice Quiero");
                    string canto = $"{Nombre} Dice Quiero";
                    registro.Add(canto);
                    retorno = 1;
                }
                else if (envido < conveniencia && seCantoEnvido == true)
                {
                    CantoEnvido = false;
                    jugada.Invoke($"{Nombre} Dice No Quiero");
                    string canto = $"{Nombre} Dice No Quiero";
                    registro.Add(canto);
                    retorno = -2;
                }

            }
            return retorno;


        }

        public void ResetearJuego()
        {
            CantoEnvido = false;
            CantoTruco = false;
            QuieroEnvido = false;
            QuieroTruco = false;
            CantoFlor = false;

        }

        public Naipe TirarCartaMasAlta()
        {
            List<Naipe> listaOrdenada = new List<Naipe>();
            listaOrdenada = TresCarta.OrderByDescending(naipe => naipe.ValorEnJuego).ToList();
            foreach (Naipe n in listaOrdenada)
            {
                if (n.EstaJugada == false) { return n; }
            }
            throw (new Exception("Se quedo sin cartas, usted no deberia haber llegado hasta aqui"));
        }


    }
}
