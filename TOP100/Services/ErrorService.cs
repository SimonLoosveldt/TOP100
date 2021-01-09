using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TOP100.Services
{
    public class ErrorService : IErrorService
    {
        public string ErrorMessage { get; private set; }

        public ErrorService()
        {

        }

        public void ChangeMessage(string msg)
        {
            ErrorMessage = msg;
        }

        public void DeleteMessage()
        {
            ErrorMessage = string.Empty;
        }

    }
}
