using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopHundred.Core.Entities
{
    public class ReleaseDateInfo : IReleaseDateInfo
    {

        public ReleaseDateInfo()
        {
            ReleaseDate = string.Empty;
            ReleaseDatePrecision = string.Empty;
        }

        public ReleaseDateInfo(string releaseDate, string releaseDatePrecision, Track track)
        {
            ReleaseDate = releaseDate;
            ReleaseDatePrecision = releaseDatePrecision;
            Track = track;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ReleaseDate { get; set; }
        [Required]
        public string ReleaseDatePrecision { get; set; }


        public Track Track { get; set; }

        public override string ToString()
        {
            return ReleaseDate;
        }

    }
}
