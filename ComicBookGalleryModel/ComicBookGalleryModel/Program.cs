using ComicBookGalleryModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                context.ComicBooks.Add(new ComicBook()
                {
                    SeriesTitle = "Harry Potter and Deathly Hallows (Part 1)",
                    IssueNumber = 7,
                    Description = "The 7th part of Harry Potter seri",
                    PublishedOn = DateTime.Today
                });

                context.SaveChanges();

                //retrieve data
                var comicBooks = context.ComicBooks.ToList();
                foreach (var comicBook in comicBooks)
                    Console.WriteLine(comicBook.SeriesTitle + "  ---  " + comicBook.Description);
                Console.ReadLine();
            }
        }
    }
}
