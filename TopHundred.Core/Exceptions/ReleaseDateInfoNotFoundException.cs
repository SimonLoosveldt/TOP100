using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopHundred.Core.Exceptions
{
    public class ReleaseDateInfoNotFoundException : Exception
    {
        public ReleaseDateInfoNotFoundException() : base()
        {

        }

        public ReleaseDateInfoNotFoundException(string message) : base(message)
        {

        }

        public ReleaseDateInfoNotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
