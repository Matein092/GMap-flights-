using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    class Flight
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

        public String getOrigin()
        {
            return origin;
        }

        public void setOrigin(String origin)
        {
            this.origin = origin;
        }

        public String getDestination()
        {
            return destination;
        }

        public void setDestination(String destination)
        {
            this.destination = destination;
        }

        public String getDate()
        {
            return date;
        }

        public void setDate(String date)
        {
            this.date = date;
        }

        public String getHour()
        {
            return hour;
        }

        public void setHour(String hour)
        {
            this.hour = hour;
        }

        public String getFlightNumber()
        {
            return flightNumber;
        }

        public void setFlightNumber(String flightNumber)
        {
            this.flightNumber = flightNumber;
        }
    }
}
