namespace EFExam.Dtos.Sections;

public class SectionDto
{
    public int Id { get; set; }
    public double Area { get; set; }
    public int AnimalCount { get; set; }
    public string? Description { get; set; }
    public decimal? TicketPrice { get; set; }
    public string? AnimalName { get; set; }
    public string? ZooName { get; set; }
}