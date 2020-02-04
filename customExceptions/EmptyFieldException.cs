using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customExceptions
{
    public class EmptyFieldException : ApplicationException
    {
        private String message;
        private String cause;

        public EmptyFieldException(String message, String cause)
        {
            this.message = message;
            this.cause = cause;
        }

        public override string Message
        {
            get
            {
                return String.Format("{0} \nCausa: El campo {1} no puede estar vacio", message, cause);
            }
        }

    }
}
