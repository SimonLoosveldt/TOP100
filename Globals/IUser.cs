using System.Collections.Generic;

namespace Models
{
    public interface IUser
    {
        string Firstname { get; set; }
        int Id { get; set; }
        string Lastname { get; set; }
        IEnumerable<ListEntry> ListEntries { get; set; }
        string SpotifyUri { get; set; }
        bool Completed { get; set; }

        string ToString();
    }
}