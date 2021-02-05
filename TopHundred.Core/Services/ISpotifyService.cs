using SpotifyAPI.Web;
using System.Collections.Generic;
using System.Threading.Tasks;
using TopHundred.Core.ViewModels;

namespace TopHundred.Core.Services
{
    public interface ISpotifyService
    {
        Task<IEnumerable<ArtistViewModel>> SearchArtist(string searchText);
        Task<IEnumerable<TrackViewModel>> SearchTrack(FullArtist artist, string searchText);
    }
}