using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopHundred.Model
{
    public class User
    {       
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string SpotifyUri { get; set; }
        public bool Completed { get; set; }

        public List<Submission> Submissions { get; } = new List<Submission>();

        public override string ToString()
        {
            return $"{Id} - {Firstname} {Lastname} ({SpotifyUri})";
        }
    }
}
