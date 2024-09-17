using EFExam.Dtos.Animals;
using EFExam.Entities;

namespace EFExam.Persistence.Animals;

public class AnimalRepository(ApplicationDbContext context)
{
    public void Create(Animal animal)
    {
        context.Set<Animal>().Add(animal);
    }

    public List<AnimalDto> ReadAll()
    {
        return context.Set<Animal>().Select(animal => new AnimalDto
        {
            Id = animal.Id,
            Name = animal.Name
        }).ToList();
    }

    public AnimalDto? Read(int id)
    {
        return context.Set<Animal>().Select(animal => new AnimalDto
        {
            Id = animal.Id,
            Name = animal.Name
        }).FirstOrDefault(animal => animal.Id == id);
    }

    public void Update(Animal newAnimal)
    {
        context.Set<Animal>().Update(newAnimal);
    }

    public void Delete(int id)
    {
        var animal = context.Set<Animal>().FirstOrDefault(animal => animal.Id == id);
        if (animal != null)
        {
            context.Set<Animal>().Remove(animal);
        }
    }
}