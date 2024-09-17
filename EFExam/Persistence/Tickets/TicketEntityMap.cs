using EFExam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFExam.Persistence.Tickets;

public class TicketEntityMap : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Tickets");
        builder.HasKey(ticket =>ticket.Id);
        builder.Property(ticket =>ticket.Id).UseIdentityColumn();
        builder.Property(ticket =>ticket.Price).HasColumnType("decimal(7, 2)").IsRequired();
        builder.HasOne(ticket =>ticket.Section).WithOne(section => section.Ticket).HasForeignKey<Section>(section => section.TicketId);
    }
}