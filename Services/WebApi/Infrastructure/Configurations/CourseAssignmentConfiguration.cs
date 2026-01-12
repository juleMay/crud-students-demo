using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Configurations;

public class CourseAssignmentConfiguration : IEntityTypeConfiguration<CourseAssignment>
{
    public void Configure(EntityTypeBuilder<CourseAssignment> builder)
    {
        builder.ToTable("CourseAssignments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.TeacherId).IsRequired();
        builder.Property(x => x.CourseId).IsRequired();
        builder.Property(x => x.AssignedAt).IsRequired();

        builder.HasIndex(x => new { x.TeacherId, x.CourseId, }).IsUnique();

        builder.HasMany(x => x.Enrollments)
            .WithOne(y => y.CourseAssignment)
            .HasForeignKey(y => y.CourseAssignmentId)
            .HasConstraintName("FK_Enrollments_CourseAssignments");
    }
}
