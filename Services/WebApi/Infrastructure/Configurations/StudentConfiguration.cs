using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");

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

        builder.HasMany(x => x.Enrollments)
            .WithOne(y => y.Student)
            .HasForeignKey(y => y.StudentId)
            .HasConstraintName("FK_Enrollments_Students");
    }
}
