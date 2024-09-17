namespace EFExam.Entities;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Section> Sections { get; set; } = [];
}