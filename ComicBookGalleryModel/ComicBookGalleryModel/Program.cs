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
                // Intial series
                var series1 = new Series()
                {
                    Title = "Harry Potter in Magic School"
                };
                var series2 = new Series()
                {
                    Title = "John Wick and his dog"
                };

                // Intial artists
                var artist1 = new Artist()
                {
                    Name = "Adam Khov"
                };
                var artist2 = new Artist()
                {
                    Name = "Uzumaki Boruto"
                };
                var artist3 = new Artist()
                {
                    Name = "Ishigami"
                };

                // Initial roles
                var role1 = new Role()
                {
                    Name = "Script"
                };
                var role2 = new Role()
                {
                    Name = "Pencil"
                };

                // Intial comic books
                var comic1 = new ComicBook()
                {
                    Series = series1,
                    IssueNumber = 6,
                    Description = "The 6th part of Harry Potter seri",
                    PublishedOn = DateTime.Today
                };
                var comic2 = new ComicBook()
                {
                    Series = series1,
                    IssueNumber = 7,
                    Description = "The 7th part of Harry Potter seri",
                    PublishedOn = DateTime.Today
                };
                var comic3 = new ComicBook()
                {
                    Series = series2,
                    IssueNumber = 2,
                    Description = "The 2nd part of John Wick seri",
                    PublishedOn = DateTime.Today
                };

                // Associate comic books and artists
                comic1.AddArtist(artist1, role1);
                comic1.AddArtist(artist2, role2);
                comic2.AddArtist(artist1, role1);
                comic2.AddArtist(artist2, role1);
                comic2.AddArtist(artist3, role2);
                comic3.AddArtist(artist1, role1);
                comic3.AddArtist(artist3, role2);

                context.ComicBooks.Add(comic1);
                context.ComicBooks.Add(comic2);
                context.ComicBooks.Add(comic3);

                context.SaveChanges();

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
