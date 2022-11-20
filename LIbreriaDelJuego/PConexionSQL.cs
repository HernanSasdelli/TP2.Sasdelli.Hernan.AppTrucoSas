using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbreriaDelJuego
{
    public class PConexionSQL
    {
        static string rutaDeConexion;//nombre de base de datos

        static SqlConnection ordenConexion;
        static SqlCommand comando;

        public List<Jugador> JugadoresDisponibles()
        {
            List<Jugador>? jugadoresDisponibles = new List<Jugador>();
            try
            {
                
                rutaDeConexion = "Server = .; Database = Tp2.Truco; Trusted_Connection = True; Encrypt = False;";
                ordenConexion = new SqlConnection(rutaDeConexion);

                comando = new SqlCommand();

                ordenConexion.Open();

                comando.Connection = ordenConexion;

                comando.CommandType = System.Data.CommandType.Text;

                comando.CommandText = "SELECT * FROM Jugadores";

                SqlDataReader reader = comando.ExecuteReader();


                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    int puntaje=reader.GetInt32(2);

                    jugadoresDisponibles.Add(new Jugador(id,nombre,puntaje));
                }

                if (ordenConexion.State == System.Data.ConnectionState.Open)
                {
                    ordenConexion.Close();
                }
                return jugadoresDisponibles;
            }
            catch
            {
                jugadoresDisponibles = null;
                return jugadoresDisponibles;

            }
            
        }

        public void GuardarDatos(Jugador jugador)
        {
        
            try
            {
                rutaDeConexion = "Server = .; Database = Tp2.Truco; Trusted_Connection = True;Encrypt=False;";
                ordenConexion = new SqlConnection(rutaDeConexion);

                comando = new SqlCommand();

                ordenConexion.Open();

                comando.Connection = ordenConexion;

                comando.CommandType = System.Data.CommandType.Text;

                comando.CommandText = $"UPDATE Jugadores SET partidosGanados += PartidosGanados WHERE nombre = nombre";
                comando.Parameters.AddWithValue("@PartidosGanados", jugador.PartidosGanados);


                comando.ExecuteNonQuery();

                if (ordenConexion.State == System.Data.ConnectionState.Open)
                {
                    ordenConexion.Close();
                }
            }
            catch(Exception)
            {
               throw;
            }



               
           
        }
    }
}
