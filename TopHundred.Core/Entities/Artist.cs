using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopHundred.Core.Entities
{
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Genre { get; set; }
        public string SpotifyUri { get; set; }
        public int Popularity { get; set; }
        public string ImageUrl { get; set; }

        public IEnumerable<Track> Tracks { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
