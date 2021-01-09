namespace Globals
{
    public interface IReleaseDateInfo
    {
        int Id { get; set; }
        string ReleaseDate { get; set; }
        string ReleaseDatePrecision { get; set; }
        Track Track { get; set; }

        string ToString();
    }
}