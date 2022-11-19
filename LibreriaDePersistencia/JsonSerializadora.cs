using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace LibreriaDePersistencia
{
    public class JsonSerializadora <T>
    {
        static string rutaArchivo;

        static JsonSerializadora()
        {
            rutaArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            rutaArchivo += @"/Archivos-Serializacion";
        }


        public static void EscribirJSON(T datos, string archivo)
        {
            if(datos != null && archivo != null && archivo!=string.Empty)
            {
                string rutaCompleta = rutaArchivo + @"/SerializadoraJSON" + archivo + ".json";

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
            throw new Exception("ERROR!\nRuta Incorrecta");
        }

        public static T LeerJSON(string nombre)
        {
            if(string.IsNullOrEmpty(nombre))
            {
                T objeto = default;
                string rutaCompleta = rutaArchivo + @"/SerializadoraJSON" + nombre + ".json";

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
            throw new Exception("ERROR!\nRuta Incorrecta");
        }
         
    }






    }
}
