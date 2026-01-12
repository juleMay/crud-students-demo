using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.Credits)
            .IsRequired();

        builder.HasMany(x => x.Assignments)
            .WithOne(y => y.Course)
            .HasForeignKey(y => y.CourseId)
            .HasConstraintName("FK_CourseAssignments_Courses");
    }
}
