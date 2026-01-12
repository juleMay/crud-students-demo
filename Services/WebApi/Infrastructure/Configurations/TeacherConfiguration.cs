using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("Teachers");

        builder.HasKey(x => x.Id);

        builder.OwnsOne(p => p.Name, name =>
        {
            name.Property(r => r.FirstName)
                .HasColumnName("FirstName")
                .IsRequired()
                .HasMaxLength(100);

            name.Property(r => r.FirstSurname)
                .HasColumnName("FirstSurname")
                .IsRequired()
                .HasMaxLength(100);

            name.Property(r => r.MiddleName)
                .HasColumnName("MiddleName")
                .HasMaxLength(100);

            name.Property(r => r.SecondSurname)
                .HasColumnName("SecondSurname")
                .HasMaxLength(100);
        });

        builder.OwnsOne(x => x.Email, email =>
        {
            email.Property(e => e.Address)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(255);
        });

        builder.HasMany(x => x.CourseAssignments)
            .WithOne(y => y.Teacher)
            .HasForeignKey(y => y.TeacherId)
            .HasConstraintName("FK_CourseAssignments_Teachers");
    }
}
