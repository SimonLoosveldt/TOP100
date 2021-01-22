using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopHundred.Core.Entities
{
    public class Track
    {
        public Track()
        {
            Title = string.Empty;
            SpotifyUri = string.Empty;
            ReleaseDate = new ReleaseDateInfo();
        }

        public Track (Artist artist, string title)
        {
            Title = title;
            Artist = artist;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [ForeignKey("ReleaseDateInfo")]
        public ReleaseDateInfo ReleaseDate { get; set; }
        public string SpotifyUri { get; set; }
        [Required]
        public bool ManualEntry { get; set; }


        public IEnumerable<ListEntry> ListEntries { get; set; }
        public Artist Artist { get; set; }


        public override string ToString()
        {
            return $"{Title} - {Artist}";
        }

    }
}
