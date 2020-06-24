using ComicBookGalleryModel.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel
{
    public class Context : DbContext
    {
        public Context()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
        }
        public DbSet<ComicBook> ComicBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Default: decimal(18, 2) for AverageRating -> Refine: decimal(5, 2) for ARating
            modelBuilder.Entity<ComicBook>()
                .Property(cb => cb.AverageRating)
                .HasPrecision(5, 2);

            // Refine Description Property to [Required, MaxLength(200)]
            modelBuilder.Entity<ComicBook>()
                .Property(cb => cb.Description)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
