using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ComicBook> ComicBooks { get; set; }

        public Artist()
        {
            ComicBooks = new List<ComicBook>();
        }
    }
}
