using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TopHundred.Views.ViewModels
{
    public class ListEntryViewModel : BaseNotifyPropertyChanged
    {
        private string _artist, _title;
        
        public ListEntryViewModel()
        {
            _artist = string.Empty;
            _title = string.Empty;
        }

        public ListEntryViewModel(int points, string artist, string title)
        {
            Points = points;
            _artist = artist;
            _title = title;
        }

        public int Points { get; set; }
        public string Artist 
        {
            get => _artist;
            set => SetProperty(ref _artist, value); 
        }
        public string Title 
        { 
            get => _title; 
            set => SetProperty(ref _title, value); 
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch(propertyName)
            {
                case nameof(Artist):
                case nameof(Title):
                    Debug.WriteLine(this);
                    break;
            }
            base.OnPropertyChanged(propertyName);
        }

        public override string ToString()
        {
            return $"{Points}: {Artist} - {Title}";
        }


    }
}
