using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netflix.Entities;

namespace Netflix.DataAccess.Configurations
{
    public class MovieCategoryConfiguration : IEntityTypeConfiguration<MovieCategory>
    {
        public void Configure(EntityTypeBuilder<MovieCategory> builder)
        {
            builder.HasKey(x => new
            {
                x.CategoryID,
                x.MovieID
            });

            builder.HasOne(x => x.Category).WithMany(x => x.MovieCategories).HasForeignKey(x => x.CategoryID).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Movie).WithMany(x => x.MovieCategories).HasForeignKey(x => x.MovieID).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
