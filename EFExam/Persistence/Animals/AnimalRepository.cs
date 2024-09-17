using EFExam.Entities;

namespace EFExam.Persistence.Animals;

public class AnimalRepository(ApplicationDbContext context)
{
    public void Create(Animal animal)
    {
        context.Set<Animal>().Add(animal);
    }
}