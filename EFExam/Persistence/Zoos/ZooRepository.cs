using EFExam.Dtos.Zoos;
using EFExam.Entities;

namespace EFExam.Persistence.Zoos;

public class ZooRepository(ApplicationDbContext context)
{
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