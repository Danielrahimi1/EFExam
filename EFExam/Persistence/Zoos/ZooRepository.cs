using EFExam.Dtos.Animals;
using EFExam.Dtos.Zoos;
using EFExam.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFExam.Persistence.Zoos;

public class ZooRepository(ApplicationDbContext context)
{
    // مشاهده هر باغ وحش به همراه نام و آدرس و حیوانات درون آن
    public List<AnimalZooDto> ReadAnimalZoo()
    {
        return context.Set<Section>().Include(s => s.Zoo).Include(s => s.Animal).Select(s => new AnimalZooDto
        {
            ZooName = s.Zoo.Name != null ? s.Zoo.Name : "no zoo",
            Address = s.Zoo.Address,
            AnimalName = s.Animal.Name != null ? s.Animal.Name : "no zoo",
        }).ToList();
    }

    //مشاهده یک باغ وحش و تعداد بخش هایی که تشکیل شده به همراه قیمت بلیط و مساحت هر بخش

    public List<CountSectionPriceAreaDto> CountSectionPriceArea(int id)
    {
        var zoo = context.Set<Zoo>().FirstOrDefault(z => z.Id == id);
        var sections = context.Set<Section>().Where(s => s.Zoo == zoo).Include(s => s.Ticket);
        return sections.Select(s => new CountSectionPriceAreaDto
        {
            CountSection = sections.Count(),
            Price = s.Ticket != null ? s.Ticket.Price : 0M,
            Area = s.Area
        }).ToList();
    }


    public void Create(Zoo zoo)
    {
        context.Set<Zoo>().Add(zoo);
    }

    public List<ZooDto> ReadAll()
    {
        return context.Set<Zoo>().Select(z => new ZooDto
        {
            Id = z.Id,
            Name = z.Name
        }).ToList();
    }

    public ZooDto? Read(int id)
    {
        return context.Set<Zoo>().Select(z => new ZooDto
        {
            Id = z.Id,
            Name = z.Name
        }).FirstOrDefault(z => z.Id == id);
    }

    public void Update(Zoo newZoo)
    {
        context.Set<Zoo>().Update(newZoo);
    }

    public void Delete(int id)
    {
        var zoo = context.Set<Zoo>().FirstOrDefault(z => z.Id == id);
        if (zoo != null)
        {
            context.Set<Zoo>().Remove(zoo);
        }
    }
}