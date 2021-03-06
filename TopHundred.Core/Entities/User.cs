﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopHundred.Core.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string SpotifyUri { get; set; }
        public bool Completed { get; set; }
        public string ImageUrl { get; set; }

        public IEnumerable<ListEntry> ListEntries { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Firstname} {Lastname} ({SpotifyUri})";
        }
    }
}
