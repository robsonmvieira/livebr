using LiveBR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiveBR.Repository.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            
            builder.OwnsOne(x => x.Cpf,
                y =>
                {
                    y.Property(
                        h => h.Value).HasColumnName("Cpf");
                });
            
            builder.OwnsOne(x => x.Email,
                y =>
                {
                    y.Property(h => h.Value).HasColumnName("email");
                });
            
            builder.OwnsOne(p =>
                p.Password, x =>
            {
                x.Property(v => v.Value).HasColumnName("password");
            });
        }
    }
}