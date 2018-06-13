using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OdataSample.App.Models;

namespace OdataSample.App.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {

        public void Configure(EntityTypeBuilder<Team> builder)
        {
            // Table
            builder.ToTable("Teams");

            // Id
            builder.HasKey(c => c.Id);

            // Properties
            builder.Property(p => p.Name).IsRequired();

            // Relations
            builder.HasMany(c => c.Players).WithOne(player => player.Team).HasForeignKey(player => player.TeamId);
            //builder.HasOne(c => c.Group).WithMany(g => g.Teams).HasForeignKey(team => new { team.Id, team.GroupId});
        }

    }
}