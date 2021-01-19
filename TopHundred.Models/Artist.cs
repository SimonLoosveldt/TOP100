using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopHundred.Models
{
    public class Artist : IArtist
    {

        public Artist()
        {
            Name = string.Empty;
        }

        public Artist (string name)
        {
            this.Name = name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Genre { get; set; }
        public string SpotifyUri { get; set; }
        public int Popularity { get; set; }


        public IEnumerable<Track> Tracks { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
