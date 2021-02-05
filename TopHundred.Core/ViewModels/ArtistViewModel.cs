using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopHundred.Core.Entities;

namespace TopHundred.Core.ViewModels
{
    public class ArtistViewModel : BaseNotifyPropertyChanged
    {
        public Artist Artist { get; set; }

        public ArtistViewModel()
        {

        }
        public ArtistViewModel(Artist artist)
        {
            Artist = artist;
        }
    }
}
