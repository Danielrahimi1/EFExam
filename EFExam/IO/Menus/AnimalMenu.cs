using EFExam.Entities;
using EFExam.IO.Interfaces;
using EFExam.Persistence;
using EFExam.Persistence.Animals;

namespace EFExam.IO.Menus;

public class AnimalMenu(IUi ui, ApplicationDbContext context) : MenuStructure(ui)
{
    private readonly AnimalRepository _animalRepository = new(context);
    protected override string ExitMessageMenu { get; } = "Back";

    protected override void AddMenuItems()
    {
        MenuItems.Add("Create", Create);
        MenuItems.Add("Read All", ReadAll);
        MenuItems.Add("Read", Read);
        MenuItems.Add("Edit", Update);
        MenuItems.Add("Delete", Delete);
    }

    private void Create()
    {
        var animal = new Animal
        {
            Name = ui.GetStringFromUser("Enter animal name: "),
        };
        _animalRepository.Create(animal);
        context.SaveChanges();
    }

    public void ReadAll()
    {
        var animals = _animalRepository.ReadAll();

        animals.ForEach(a =>
        {
            ui.ShowMessage(
                $"Id: {a.Id}, Name: {a.Name}");
        });
    }

    public void Read()
    {
        var animalId = ui.GetIntegerFromUser("Enter animal id:");
        var animal = _animalRepository.Read(animalId);
        ui.ShowMessage($"Id: {animal.Id}, Name: {animal.Name}");
    }


    private void Update()
    {
        ReadAll();
        var animalId = ui.GetIntegerFromUser("Enter animal id:");
        var animal = _animalRepository.Read(animalId);
        animal.Name = ui.GetStringFromUser("Enter Animal name:");
        context.SaveChanges();
    }

    private void Delete()
    {
        ReadAll();
        var animalId = ui.GetIntegerFromUser("Enter animal id:");
        var animal = _animalRepository.Read(animalId);
        _animalRepository.Delete(animalId);
        context.SaveChanges();
    }
}