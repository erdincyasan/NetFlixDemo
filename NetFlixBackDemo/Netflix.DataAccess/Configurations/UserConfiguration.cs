using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netflix.Entities;

namespace Netflix.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.UserMail).HasMaxLength(50);
            builder.HasKey(x => x.UserID);
            builder.Property(x => x.UserPhone).HasMaxLength(11);
        }
    }
}
