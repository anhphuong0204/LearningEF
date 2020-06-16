using ComicBookGalleryModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                var series = new Series()
                {
                    Title = "Harry Potter"
                };

                context.ComicBooks.Add(new ComicBook()
                {
                    Series = series,
                    IssueNumber = 6,
                    Description = "The 7th part of Harry Potter seri",
                    PublishedOn = DateTime.Today
                });
                context.ComicBooks.Add(new ComicBook()
                {
                    Series = series,
                    IssueNumber = 7,
                    Description = "The 6th part of Harry Potter seri",
                    PublishedOn = DateTime.Today
                });

                context.SaveChanges();

                //retrieve data
                var comicBooks = context.ComicBooks
                    .Include(cb => cb.Series)
                    .ToList();
                foreach (var comicBook in comicBooks)
                    Console.WriteLine(comicBook.DisplayText);
                Console.ReadLine();
            }
        }
    }
}
