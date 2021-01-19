namespace TopHundred.Views.Services
{
    public interface IErrorService
    {
        string ErrorMessage { get; }

        void ChangeMessage(string msg);
        void DeleteMessage();
    }
}