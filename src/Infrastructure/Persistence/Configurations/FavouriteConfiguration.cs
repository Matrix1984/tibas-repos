using Tibas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tibas.Infrastructure.Persistence.Configurations;

public class FavouriteConfiguration : IEntityTypeConfiguration<Favourite>
{
    public void Configure(EntityTypeBuilder<Favourite> builder)
    { 
        builder.Property(t => t.GitHubId) 
        .IsRequired();

        builder.Property(t => t.GitHubName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.GitOwnerName)
         .HasMaxLength(200)
         .IsRequired();

        builder.Property(t => t.Description) 
         .IsRequired();

        builder.Property(t => t.UserId) 
         .IsRequired();
    }
} 