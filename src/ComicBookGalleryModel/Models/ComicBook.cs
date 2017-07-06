using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    public class ComicBook
    {
        public int Id { get; set; }

        // Foreign key property that will force this foreign key DB field to be non-nullable
        public int SeriesId { get; set; }
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public decimal? AverageRating { get; set; }

        // Navigation property
        public Series Series { get; set; }

        public ICollection<Artist> Artists { get; set; }

        public string DisplayText
        {
            get
            {
                // Series?.Title tells program to return null if Series is null
                // $"{property0} #{property1}" -- interpolated string
                return $"{Series?.Title} #{IssueNumber}";
            }
        }

        public ComicBook()
        {
            Artists = new List<Artist>();
        }
    }
}
