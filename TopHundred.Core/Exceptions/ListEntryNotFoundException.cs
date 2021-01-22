using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopHundred.Core.Exceptions
{
    public class ListEntryNotFoundException : Exception
    {
        public ListEntryNotFoundException() : base()
        {

        }

        public ListEntryNotFoundException(string message) : base(message)
        {

        }

        public ListEntryNotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
