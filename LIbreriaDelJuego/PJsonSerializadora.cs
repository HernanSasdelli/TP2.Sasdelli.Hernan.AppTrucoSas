using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace LIbreriaDelJuego
{
    public class PJsonSerializadora <T>:PISerializadoraGenerica<T> where T : class, new()
    {
        static string rutaArchivo;

        static PJsonSerializadora()
        {
            rutaArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +@"/Archivos-Persistencia";            
        }


        public  void Escribir(T datos, string nombreArchivo)
        {
            string rutaCompleta = rutaArchivo + @"/JsonSerializadora" + nombreArchivo + ".json";
            if (datos != null && nombreArchivo != null && nombreArchivo != string.Empty)
            {              

                if (!Directory.Exists(rutaArchivo))
                {
                    Directory.CreateDirectory(rutaArchivo);
                }
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
                };
                string objetoJson = JsonSerializer.Serialize(datos, options);

                File.WriteAllText(rutaCompleta, objetoJson);
            }
            else
            {
                throw new Exception($"ERROR!\nRuta{rutaCompleta}Incorrecta");
            }
            
        }

        public T Leer(string nombreArchivo)
        {
            string rutaCompleta = rutaArchivo + @"/JsonSerializadora" + nombreArchivo + ".json";
            if (!string.IsNullOrEmpty(nombreArchivo))
            {
                T objeto = default;                

                if (!Directory.Exists(rutaArchivo))
                {
                    Directory.CreateDirectory(rutaArchivo);
                }

                JsonSerializerOptions options = new JsonSerializerOptions///esto es para que quede el nombre, y no 0,1,2
                {
                    Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
                };

                string archivoJson = File.ReadAllText(rutaCompleta);
                objeto = JsonSerializer.Deserialize<T>(archivoJson, options);

                return objeto;
            }
            else
            {
                throw new Exception($"ERROR!\nRuta{rutaCompleta}Incorrecta");
            }
           
        }
         
    }






    
}
