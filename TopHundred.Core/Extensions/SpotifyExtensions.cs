using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopHundred.Core.Entities;
using TopHundred.Core.ViewModels;

namespace TopHundred.Core.Extensions
{
    public static class SpotifyExtensions
    {
        private static readonly string emptyAlbumCover = "img/music_black_48dp.png";


        public static TrackViewModel ToTrackViewModel(this FullTrack fullTrack)
        {
            return new TrackViewModel(new Track
            {
                Title = fullTrack.Name,
                SpotifyUri = fullTrack.Uri,
                ManualEntry = false,
                ImageUrl = fullTrack.Album.Images.FirstOrDefault()?.Url ?? emptyAlbumCover,

                Artist = fullTrack.Artists
            });
        }

        public static TrackViewModel ToTrackViewModel(this SimpleTrack simpleTrack)
        {
            return new TrackViewModel(new Track
            {
                Title = simpleTrack.Name,
                SpotifyUri = simpleTrack.Uri,
                ManualEntry = false,
                ImageUrl = emptyAlbumCover
            });
        }

        public static ArtistViewModel ToArtistViewModel(this FullArtist fullArtist)
        {
            return new ArtistViewModel(new Artist
            {
                Name = fullArtist.Name,
                Genre = fullArtist.Genres.FirstOrDefault(),
                SpotifyUri = fullArtist.Uri,
                Popularity = fullArtist.Popularity,
                ImageUrl = fullArtist.Images.FirstOrDefault()?.Url
            });
        }

        public static ArtistViewModel ToArtistViewModel(this SimpleArtist simpleArtist)
        {
            return new ArtistViewModel(simpleArtist);
        }
    }
}
