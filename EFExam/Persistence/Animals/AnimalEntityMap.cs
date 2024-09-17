using EFExam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFExam.Persistence.Animals;

public class AnimalEntityMap : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
        builder.ToTable("Animals");
        builder.HasKey(animal => animal.Id);
        builder.Property(animal => animal.Id).UseIdentityColumn();
        builder.Property(animal => animal.Name).HasMaxLength(100).IsRequired();
        builder.HasMany(animal => animal.Sections).WithOne(section => section.Animal)
            .HasForeignKey(section => section.AnimalId).OnDelete(DeleteBehavior.SetNull);
    }
}