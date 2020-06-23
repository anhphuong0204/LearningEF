using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Model
{
    public class Artist
    {
        public Artist()
        {
            ComicBooks = new List<ComicBook>();
        }
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }

        public ICollection<ComicBook> ComicBooks { get; set; }
    }
}
