using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Flight
    {
        private String origin;
        private String destination;
        private String date;
        private String hour;
        private String flightNumber;

        public Flight(String origin, String destination, String date, String hour, String flightNumber)
        {
            this.origin = origin;
            this.destination = destination;
            this.date = date;
            this.hour = hour;
            this.flightNumber = flightNumber;
        }

        public String GetOrigin()
        {
            return origin;
        }

        public String GetDestination()
        {
            return destination;
        }

        public String GetDate()
        {
            return date;
        }

        public String GetHour()
        {
            return hour;
        }

        public String GetFlightNumber()
        {
            return flightNumber;
        }
    }
}
