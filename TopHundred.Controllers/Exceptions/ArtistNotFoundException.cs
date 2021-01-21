using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopHundred.Controllers.Exceptions
{
    public class ArtistNotFoundException : Exception
    {

        public ArtistNotFoundException() : base()
        {

        }

        public ArtistNotFoundException(string message) : base(message)
        {

        }

        public ArtistNotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }

    }
}
