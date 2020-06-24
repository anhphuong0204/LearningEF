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
                //retrieve data
                var comicBooks = context.ComicBooks
                    .Include(cb => cb.Series)
                    .Include(cb => cb.Artists.Select(a => a.Artist))
                    .Include(cb => cb.Artists.Select(a => a.Role))
                    .ToList();
                foreach (var comicBook in comicBooks)
                {
                    var _artistNames = comicBook.Artists.Select(a => $"{ a.Artist.Name } - { a.Role.Name }");
                    var artistNames = string.Join(" ,", _artistNames);
                    Console.WriteLine(comicBook.DisplayText);
                    Console.WriteLine(artistNames + Environment.NewLine);
                }

                // The program auto stops when those above terminated
            }
        }
    }
}
