using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    public class Series
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<ComicBook> ComicBooks { get; set; }

        public Series()
        {
            ComicBooks = new List<ComicBook>();
        }
    }
}
