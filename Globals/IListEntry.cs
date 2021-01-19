namespace Models
{
    public interface IListEntry
    {
        int Id { get; set; }
        int Points { get; set; }
        Track Track { get; set; }
        User User { get; set; }
        int Year { get; set; }

        string ToString();
    }
}