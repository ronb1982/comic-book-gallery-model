using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    // This is an "explicit" bridge entity for the ArtistComicBooks table. We define this
    // in order to add additional properties to the bridge entity table.
    public class ComicBookArtist
    {
        public int Id { get; set; }
        public int ComicBookId { get; set; }
        public int ArtistId { get; set; }
        public int RoleId { get; set; }

        // Navigation properties
        public virtual ComicBook ComicBook { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Role Role { get; set; }
    }
}
