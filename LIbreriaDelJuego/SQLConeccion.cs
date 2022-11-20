using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbreriaDelJuego
{
    public static class SQLConeccion
    {
        static string connectionString;//nombre de base de datos

        static SqlConnection connection;
        static SqlCommand command;

        public static List<Jugador> JugadoresDisponibles()
        {
            List<Jugador> jugadoresDisponibles = new List<Jugador>();

            try
            {
                connectionString = "Server = .; Database = Tp2.Truco; Trusted_Connection = True; Encrypt = False;";
                connection = new SqlConnection(connectionString);

                command = new SqlCommand();

                connection.Open();

                command.Connection = connection;

                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "SELECT * FROM Jugadores";

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    int puntaje=reader.GetInt32(2);

                    jugadoresDisponibles.Add(new Jugador(id,nombre,puntaje));
                }

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return jugadoresDisponibles;
        }

        public static void GuardarDatos(Jugador jugador)
        {
            try
            {
                connectionString = "Server = .; Database = Tp2.Truco; Trusted_Connection = True;Encrypt=False;";
                connection = new SqlConnection(connectionString);

                command = new SqlCommand();

                connection.Open();

                command.Connection = connection;

                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = $"INSERT INTO Jugadores (partidosGanados) VALUES (@PartidosGanados)";
                command.Parameters.AddWithValue("@PartidosGanados", jugador.PartidosGanados);

                command.ExecuteNonQuery();

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
