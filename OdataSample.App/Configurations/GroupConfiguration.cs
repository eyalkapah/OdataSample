using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OdataSample.App.Models;

namespace OdataSample.App.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            // Table
            builder.ToTable("Groups");

            // Id
            builder.HasKey(c => c.Id);

            // Properties
            builder.Property(p => p.Name).IsRequired();

            // Relations
            builder.HasMany(c => c.Teams).WithOne(team => team.Group).HasForeignKey(team => team.GroupId);
        }
    }
}