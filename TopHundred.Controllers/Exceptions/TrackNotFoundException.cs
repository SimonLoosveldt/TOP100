using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopHundred.Controllers.Exceptions
{
    public class TrackNotFoundException : Exception
    {

        public TrackNotFoundException() : base()
        {

        }

        public TrackNotFoundException(string message) : base(message)
        {

        }

        public TrackNotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }

    }
}
