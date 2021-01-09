namespace TOP100.Services
{
    public interface IErrorService
    {
        string ErrorMessage { get; }

        void ChangeMessage(string msg);
        void DeleteMessage();
    }
}