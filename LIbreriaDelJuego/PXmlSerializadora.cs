using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LIbreriaDelJuego
{
    public class PXmlSerializadora <T> : PISerializadoraGenerica<T> where T : class, new()
    {
        public string rutaArchivo;

        public PXmlSerializadora()
        {
            rutaArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            rutaArchivo += @"\Archivos-Persistencia";
        }

        public void Escribir(T objeto, string nombreArchivo)
        {
            string rutaCompleta = rutaArchivo + @"\XmlSerializadora" + nombreArchivo + ".xml";
           try
            {
                if (!Directory.Exists(rutaArchivo))
                {
                    Directory.CreateDirectory(rutaArchivo);
                }
                using (StreamWriter escribirSerializacion = new StreamWriter(rutaCompleta))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(escribirSerializacion, objeto);
                }
            }
            catch (Exception)
            {
                throw new Exception($"Error en ruta {rutaCompleta}");
            }
        }

        public T Leer(string archivo)
        {
            string rutaCompleta = rutaArchivo + @"\" + archivo + ".xml";

            try
            {
                if (!Directory.Exists(rutaArchivo))
                {
                    throw new Exception("La ruta no existe");
                }

                using (StreamReader rearmar = new StreamReader(rutaCompleta))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));

                    if (serializer.Deserialize(rearmar) is T objeto)
                    {
                        return objeto;
                    }
                    throw new Exception("El objeto a deserializar no es del tipo de dato esperado.");
                }
            }
            catch (Exception)
            {

                throw;
            }



        }


        


    }
}
