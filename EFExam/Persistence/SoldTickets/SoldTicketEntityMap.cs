using EFExam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFExam.Persistence.SoldTickets;

public class SoldTicketEntityMap:IEntityTypeConfiguration<SoldTicket>
{
    public void Configure(EntityTypeBuilder<SoldTicket> builder)
    {
        builder.ToTable("SoldTickets");
        builder.HasKey(st => st.Id);
        builder.Property(st => st.Id).UseIdentityColumn();
        builder.Property(st => st.TicketId).IsRequired();
    }
}