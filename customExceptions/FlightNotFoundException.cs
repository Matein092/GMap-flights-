using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customExceptions
{
    public class FlightNotFoundException : ApplicationException
    {
        private String message;
        private String cause;

        public FlightNotFoundException(String message, String cause)
        {
            this.message = message;
            this.cause = cause;
        }

        public override string Message
        {
            get
            {
                return String.Format("{0} \nCausa: el lugar {1} no se encuentra registrado", message, cause);
            }
        }
    }
}
