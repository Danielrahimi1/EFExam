using EFExam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFExam.Persistence.Sections;

public class SectionEntityMap : IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
        builder.ToTable("Sections");
        builder.HasKey(section => section.Id);
        builder.Property(section => section.Id).UseIdentityColumn();
        builder.Property(section => section.Area).IsRequired();
        builder.Property(section => section.AnimalCount).IsRequired();
        builder.Property(section => section.Description).HasMaxLength(500).IsRequired();
        builder.Property(section => section.TicketId).HasMaxLength(500).IsRequired(false);
    }
}