using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OdataSample.App.Models;

namespace OdataSample.App.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {

        public void Configure(EntityTypeBuilder<Player> builder)
        {
            // Table
            builder.ToTable("Players");

            // Id
            builder.HasKey(c => c.Id);

            // Properties
            builder.Property(p => p.Name).IsRequired();
        }

    }
}