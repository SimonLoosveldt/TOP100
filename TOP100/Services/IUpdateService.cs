namespace TOP100.Services
{
    public interface IUpdateService
    {
        int Count { get; set; }

        void Update(object stateinfo);
    }
}