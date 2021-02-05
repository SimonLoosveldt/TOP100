using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopHundred.Core.Exceptions;

namespace TopHundred.Core.Controllers
{
    public class SpotifyController
    {
        private readonly SpotifyClient _client;

        public SpotifyController(SpotifyClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<FullArtist>> SearchArtist(string searchText)
        {
            var request = new SearchRequest(SearchRequest.Types.Artist, searchText);
            var searchResult = await _client.Search.Item(request);

            return searchResult.Artists.Items ?? throw new ArtistNotFoundException($"No artist for searchtext:\"{searchText}\" found with Spotify API.");
        }

        public async Task<IEnumerable<FullTrack>> SearchTrack(FullArtist artist, string searchText)
        {
            var request = new SearchRequest(SearchRequest.Types.Track, AddArtistToSearchText(artist, searchText));
            var searchResult = await _client.Search.Item(request);

            return searchResult.Tracks.Items ?? throw new TrackNotFoundException($"No track for searchtext:\"{AddArtistToSearchText(artist, searchText)}\" found with Spotify API.");
        }

        public static string AddArtistToSearchText(FullArtist artist, string searchText)
        {
            if (artist != null && !string.IsNullOrEmpty(searchText))
            {
                return $"artist:{artist.Name} track:{searchText}";
            }
            else if (artist == null && !string.IsNullOrEmpty(searchText))
            {
                return searchText;
            }
            else
            {
                return string.Empty;
            }
        }

        public Task<FullArtist> FindFullArtistFromURI(SimpleArtist simpleArtist)
        {
            return _client.Artists.Get(simpleArtist.Id);
        }
    }
}
