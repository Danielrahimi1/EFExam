namespace EFExam.Entities;

public class Section
{
    public int Id { get; set; }
    public double Area { get; set; }
    public int AnimalCount { get; set; }
    public string Description { get; set; }
    public int? AnimalId { get; set; }
    public Animal? Animal { get; set; }
    public int? TicketId { get; set; }
    public Ticket? Ticket { get; set; }
    public int? ZooId { get; set; }
    public Zoo? Zoo { get; set; }
}
