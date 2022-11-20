using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbreriaDelJuego
{
    public interface PISerializadoraGenerica<T> where T : class, new()//solo clases de instancia
    {
            void Escribir(T objeto,string str);
            T Leer(string str);
    }
}
