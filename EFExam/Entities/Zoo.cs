namespace EFExam.Entities;

public class Zoo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Section> Sections { get; set; } = [];
}