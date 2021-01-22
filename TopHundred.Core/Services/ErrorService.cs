namespace TopHundred.Core.Services
{
    public class ErrorService : IErrorService
    {
        public string ErrorMessage { get; private set; }

        public void ChangeMessage(string message)
        {
            ErrorMessage = message;
        }

        public void DeleteMessage()
        {
            ErrorMessage = string.Empty;
        }

    }
}
