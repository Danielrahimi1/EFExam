using EFExam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFExam.Persistence.Zoos;

public class ZooEntityMap : IEntityTypeConfiguration<Zoo>
{
    public void Configure(EntityTypeBuilder<Zoo> builder)
    {
        builder.ToTable("Zoos");
        builder.HasKey(zoo => zoo.Id);
        builder.Property(zoo => zoo.Id).UseIdentityColumn();
        builder.Property(zoo => zoo.Name).HasMaxLength(100).IsRequired();
        builder.HasMany(zoo => zoo.Sections).WithOne(section => section.Zoo)
            .HasForeignKey(section =>section.ZooId);
    }
}