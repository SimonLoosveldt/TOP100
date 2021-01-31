using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopHundred.Model
{
    public class ReleaseDateInfo
    {      
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
