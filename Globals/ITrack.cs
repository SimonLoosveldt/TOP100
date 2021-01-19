using System.Collections.Generic;

namespace TopHundred.Models
{
    public interface ITrack
    {
        Artist Artist { get; set; }
        int Id { get; set; }
        IEnumerable<ListEntry> ListEntries { get; set; }
        bool ManualEntry { get; set; }
        ReleaseDateInfo ReleaseDate { get; set; }
        string SpotifyUri { get; set; }
        string Title { get; set; }

        string ToString();
    }
}