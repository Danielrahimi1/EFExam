using EFExam.Dtos.Sections;
using EFExam.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFExam.Persistence.Sections;

public class SectionRepository(ApplicationDbContext context)
{
    // مشاهده بخش های باغ وحش و نوع و تعداد حیوانات درون آن به همراه توضیحات 

    public List<SectionWithAnimalDto> SectionWithAnimal(int zooId)
    {
        var zoo = context.Set<Zoo>().FirstOrDefault(z => z.Id == zooId);
        var sections = context.Set<Section>().Where(s => s.Zoo == zoo).Include(s => s.Animal);
        return sections.Select(s => new SectionWithAnimalDto
        {
            AnimalName = s.Animal.Name != null ? s.Animal.Name : "no animal",
            AnimalCount = s.AnimalCount,
            Description = s.Description
        }).ToList();
    }

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