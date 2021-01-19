using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TopHundred.Models
{
    public class ListEntry : IListEntry
    {

        public ListEntry()
        {

        }

        public ListEntry(User user, Track track, int points, int year)
        {
            this.User = user;
            this.Track = track;
            this.Points = points;
            this.Year = year;
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
            return $"{User.ToString()} gives {Points} points to {Track.ToString()}.";
        }
    }
}
