using EFExam.Persistence;

namespace EFExam.Dtos.SoldTickets;

public class SoldTicketDto
{
    public int Id { get; set; }
    public int SectionId { get; set; }
    public decimal Price { get; set; }
}