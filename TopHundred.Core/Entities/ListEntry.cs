using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopHundred.Core.Entities
{
    public class ListEntry
    {
        public ListEntry()
        {
            Track = new Track();
            User = new User();
        }

        public ListEntry(User user, Track track, int points, int year)
        {
            User = user;
            Track = track;
            Points = points;
            Year = year;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Points { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public Track Track { get; set; }
        [Required]
        public User User { get; set; }

        public override string ToString()
        {
            return $"{User} gives {Points} points to {Track}.";
        }
    }
}
