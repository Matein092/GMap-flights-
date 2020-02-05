using System;
using System.Collections.Generic;
using System.IO;
using customExceptions;

namespace model
{
    public class Country
    {
        //Constante con la que se ubica el archivo de los datos
        private const String FLIGHT_DATA_PATH = "..\\..\\..\\flights-data.csv";

        //Relacion con los vuelos, dependiendo de la ciudad donde este.
        private Dictionary<String, List<Flight>> flights;

        public Country()
        {
            this.flights = new Dictionary<string, List<Flight>>();
        }

        public List<String> GetUbicationsFlights()
        {
            return new List<string>(flights.Keys);
        }

        public bool CheckEmptyField(String fieldText)
        {
            return fieldText.Equals("");
        }

        public void ReadData()
        {
            StreamReader sr = new StreamReader(FLIGHT_DATA_PATH);
            String line = sr.ReadLine();
            line = sr.ReadLine();
            
            while (line != null)
            {
                String[] data = line.Split(';');

                String date = data[0];
                String tailNumber = data[1];
                String flightNumber = data[2];
                String originCity = CitiesUbications(data[3], data[4]);
                String destinationCity = CitiesUbications(data[5], data[6]);
                String hour = data[7];
                String arivalTime = data[8];
                String airTime = data[10];
                String distance = data[11];

                CreateFlights(date, tailNumber, flightNumber, originCity, destinationCity, hour, arivalTime, airTime, distance);

                line = sr.ReadLine();
            }
            sr.Close();
        }

        private String CitiesUbications(String city, String state)
        {
            String ubication = "";

            String[] data = city.Split(',');
            ubication = data[0] + ", " + state;

            return ubication;
        }

        private void CreateFlights(String date, String tailNumber, String flightNumber, String originCity, String destinationCity, String hour, String arivalTime, String airTime, String distance)
        {
            Flight flight = new Flight(date, tailNumber, flightNumber, originCity, destinationCity, hour, arivalTime, airTime, distance);

            if (flights.ContainsKey(originCity))
            {
                flights[originCity].Add(flight);
            }
            else
            {
                flights.Add(originCity, new List<Flight>());
                flights[originCity].Add(flight);
            }
        }

        public List<Flight> FlightbyOrigin(string origin)
        {
            List<Flight> list = null;


            if (!CheckEmptyField(origin))
            {
                if (flights.ContainsKey(origin))
                {
                    list = flights[origin];

                }
                else
                {
                    throw new FlightNotFoundException("Vuelo no encontrado", origin);
                }
            }
            else
            {
                throw new EmptyFieldException("Campo vacio", "Ciudad de Origen");
            }
            return list;
        }

    }
}
