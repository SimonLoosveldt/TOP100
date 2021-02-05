using SpotifyAPI.Web;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using TopHundred.Core.Controllers;

namespace TopHundred.Core.ViewModels
{
    public class ListEntryViewModel : BaseNotifyPropertyChanged
    {
        private ArtistViewModel _artist;
        private TrackViewModel _track;
        
        public ListEntryViewModel()
        {
            _artist = null;
            _track = null;
        }
        public ListEntryViewModel(int points) : this(points, null, null)
        {
        }
        public ListEntryViewModel(int points, ArtistViewModel artist, TrackViewModel track)
        {
            Points = points;
            _artist = artist;
            _track = track;
        }

        public int Points { get; set; }
        public ArtistViewModel ArtistViewModel 
        {
            get => _artist;
            set => SetProperty(ref _artist, value); 
        }
        public TrackViewModel TrackViewModel 
        { 
            get => _track; 
            set => SetProperty(ref _track, value); 
        }

        public override string ToString()
        {
            return $"{Points}: {ArtistViewModel.Artist.Name} - {TrackViewModel.Track.Title}";
        }

        public bool IsEmpty()
        {
            return ArtistViewModel == null && TrackViewModel == null;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch(propertyName)
            {
                case nameof(ArtistViewModel):
                case nameof(TrackViewModel):
                    if(TrackViewModel == null)
                    {
                        if (ArtistViewModel == null || ArtistViewModel.Artist.Name != TrackViewModel.Track.Artist.Name)
                        {
                            ArtistViewModel = new ArtistViewModel(TrackViewModel.Track.Artist);
                        }
                    }                        
                    Debug.WriteLine(this);
                    break;
            }

            base.OnPropertyChanged(propertyName);
        }
    }
}