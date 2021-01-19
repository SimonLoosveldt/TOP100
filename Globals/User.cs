using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class User : IUser
    {
        public User(/*string firstname, string lastname, string uri*/)
        {
            //this.Firstname = firstname;
            //this.Lastname = lastname;
            //this.SpotifyUri = uri;
        }
        public User(string firstname, string lastname, string uri)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.SpotifyUri = uri;
        }

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


        public IEnumerable<ListEntry> ListEntries { get; set; }


        public override string ToString()
        {
            return $"{Id} - {Firstname} {Lastname} ({SpotifyUri})";
        }
    }
}
