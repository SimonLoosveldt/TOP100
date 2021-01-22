using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TopHundred.Core.ViewModels
{
    public class ListEntryViewModel : BaseNotifyPropertyChanged
    {
        private string _artist, _title;
        
        public ListEntryViewModel()
        {
            _artist = string.Empty;
            _title = string.Empty;
        }
        public ListEntryViewModel(int points) : this(points, string.Empty, string.Empty)
        {
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

        public override string ToString()
        {
            return $"{Points}: {Artist} - {Title}";
        }
        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(_artist) && string.IsNullOrEmpty(_title);
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
    }
}