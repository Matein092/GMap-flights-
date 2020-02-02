using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace model
{
    public class Country
    {
        //Constante con la que se ubica el archivo de los datos
        private const String FLIGHT_DATA_PATH = "..\\..\\flights-data.txt";

        //Relacion con los vuelos, dependiendo de la ciudad donde este.
        private Dictionary<String, List<Flight>> flights;

        public Country()
        {
            this.flights = new Dictionary<string, List<Flight>>();
        }

        public void readData()
        {
            StreamReader sr = new StreamReader(FLIGHT_DATA_PATH);
            String line = sr.ReadLine();
            int counter = 0;

            while (line != null)
            {
                if (counter > 0)
                {
                    String[] data = line.Split(';');
                    String origin = data[16] + "-" + data[19];
                    String destination = data[25] + "-" + data[28];
                    String date = data[6];
                    String hour = data[31];
                    String flightNumber = data[11];

                    createFlights(origin, destination, date, hour, flightNumber);
                }


                line = sr.ReadLine();
                counter++;
            }
            sr.Close();
        }

        private void createFlights(String origin, String destination, String date, String hour, String flightN)
        {
            Flight flight = new Flight(origin, destination, date, hour, flightN);

            if (flights.ContainsKey(origin))
            {
                flights[origin].Add(flight);
            }
            else
            {
                flights.Add(origin, new List<Flight>());
                flights[origin].Add(flight);
            }
        }
    }
}
