using System;

namespace model
{
    public class Flight
    {

        private String originCity;
        private String destinationCity;
        private String date;
        private String hour;
        private String flightNumber;
        private String tailNumber;
        private String arivalTime;
        private String airTime;
        private String distance;

        public Flight(String date, String tailNumber, String flightNumber, String originCity, String destinationCity, String hour, String arivalTime, String airTime, String distance)
        {
            this.Date = date;
            this.TailNumber = tailNumber;
            this.FlightNumber = flightNumber;
            this.OriginCity = originCity;
            this.DestinationCity = destinationCity;
            this.Hour = hour;
            this.ArivalTime = arivalTime;
            this.AirTime = airTime;
            this.Distance = distance;
        }

        public string OriginCity { get => originCity; set => originCity = value; }
        public string DestinationCity { get => destinationCity; set => destinationCity = value; }
        public string Date { get => date; set => date = value; }
        public string Hour { get => hour; set => hour = value; }
        public string FlightNumber { get => flightNumber; set => flightNumber = value; }
        public string TailNumber { get => tailNumber; set => tailNumber = value; }
        public string ArivalTime { get => arivalTime; set => arivalTime = value; }
        public string AirTime { get => airTime; set => airTime = value; }
        public string Distance { get => distance; set => distance = value; }
    }
}

