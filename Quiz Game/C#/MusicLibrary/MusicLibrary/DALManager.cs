using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using System.Data.SqlTypes;
using System.Diagnostics;

namespace MusicLibrary
{
    public class DALManager
    {
        private readonly IConfiguration Configuration;


        public DALManager(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //Method named GetTechnology that return a list Artist objects
        public List<Artist> GetArtist()
        {
            //Create a new list to store the fetched Artist objects
            List<Artist> artistList = new List<Artist>();

            //Create a new NpgsqlConnection using the specified connectionString from the appsettings
            using (NpgsqlConnection connection = new NpgsqlConnection(Configuration["ConnectionString"]))
            {
                //Try statement
                try
                {
                    //Makes a new NpgSglCommand named command
                    using (NpgsqlCommand command = new NpgsqlCommand())
                    {
                        //Set the command's connection and query for getartist() sql function
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM getartist()";

                        //Open the database connection
                        connection.Open();

                        //Execute the command and retrieve the results using a NpgsqlDataReader
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //Create a new Artist object and add it to the artistList,  with the diffrent columns in the database
                                artistList.Add(new Artist(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                            }
                        }
                    }
                }
                //Catch database exceptions
                catch (NpgsqlException npg)
                {
                    //Print it to the debug console
                    Debug.Write("22222222222222222222222222222222222" + npg.Message);
                }
                //Catch all other exceptions
                catch (Exception ex)
                {
                    //Print it to the debug console
                    Debug.Write("An error occurred: " + ex.Message);
                }
                finally
                {
                    //Close the database connection in the finally block
                    connection.Close();
                }
            }

            //Return the fetched list of Technology objects
            return artistList;
        }
    }
}

