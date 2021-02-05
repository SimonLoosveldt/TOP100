using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopHundred.Core.Exceptions;
using TopHundred.Core.ViewModels;
using TopHundred.Core.Extensions;

namespace TopHundred.Core.Services
{
    public class SpotifyService : ISpotifyService
    {
        private SpotifyClient _client;

        public SpotifyService(string clientId, string clientSecret)
        {
            InitializeClient(clientId, clientSecret);
        }

        public async Task<IEnumerable<ArtistViewModel>> SearchArtist(string searchText)
        {
            var request = new SearchRequest(SearchRequest.Types.Artist, searchText);
            var searchResult = await _client.Search.Item(request);

            return searchResult.Artists.Items.Select(x => x.ToArtistViewModel()) ?? throw new ArtistNotFoundException($"No artist for searchtext:\"{searchText}\" found with Spotify API.");
        } 

        public async Task<IEnumerable<TrackViewModel>> SearchTrack(FullArtist artist, string searchText)
        {
            var request = new SearchRequest(SearchRequest.Types.Track, AddArtistToSearchText(artist, searchText));
            var searchResult = await _client.Search.Item(request);

            return searchResult.Tracks.Items.Select(x => x.ToTrackViewModel()) ?? throw new TrackNotFoundException($"No track for searchtext:\"{AddArtistToSearchText(artist, searchText)}\" found with Spotify API.");
        }

        private static string AddArtistToSearchText(FullArtist artist, string searchText)
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
        private void InitializeClient(string clientId, string clientSecret)
        {
            var config = SpotifyClientConfig.CreateDefault().WithAuthenticator(new ClientCredentialsAuthenticator(clientId, clientSecret));
            _client = new SpotifyClient(config);
        }
    }
}
