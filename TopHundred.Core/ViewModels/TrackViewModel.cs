using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopHundred.Core.Entities;

namespace TopHundred.Core.ViewModels
{
    public class TrackViewModel
    {
        public Track Track { get; set; }
        
        public TrackViewModel()
        {

        }
        public TrackViewModel(Track track)
        {
            Track = track;
        }
    }
}
