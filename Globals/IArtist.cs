using System.Collections.Generic;

namespace Globals
{
    public interface IArtist
    {
        string Genre { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        int Popularity { get; set; }
        string SpotifyUri { get; set; }
        IEnumerable<Track> Tracks { get; set; }

        string ToString();
    }
}