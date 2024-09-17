using EFExam.Dtos.Sections;
using EFExam.Entities;

namespace EFExam.Persistence.Sections;

public class SectionRepository(ApplicationDbContext context)
{
    public void Create(Section section)
    {
        context.Set<Section>().Add(section);
    }

    public List<SectionDto> ReadAll()
    {
        return context.Set<Section>().Select(section => new SectionDto
        {
            Id = section.Id,
            Area = section.Area,
            AnimalCount = section.AnimalCount,
            Description = section.Description,
            TicketPrice = section.Ticket.Price,
            AnimalName = section.Animal.Name,
            ZooName = section.Zoo.Name
        }).ToList();
    }

    public SectionDto? Read(int id)
    {
        return context.Set<Section>().Select(section => new SectionDto
        {
            Id = section.Id,
            Area = section.Area,
            AnimalCount = section.AnimalCount,
            Description = section.Description,
            TicketPrice = section.Ticket.Price,
            AnimalName = section.Animal.Name,
            ZooName = section.Zoo.Name
        }).FirstOrDefault(section => section.Id == id);
    }

    public void Update(Section newSection)
    {
        context.Set<Section>().Update(newSection);
    }

    public void Delete(int id)
    {
        var section = context.Set<Section>().FirstOrDefault(section => section.Id == id);
        if (section != null)
        {
            context.Set<Section>().Remove(section);
        }
    }
}