namespace EFExam.Entities;

public class Ticket
{
    public int Id { get; set; }
    // public int SectionId { get; set; }
    public Section Section { get; set; }
    public decimal Price { get; set; }
}