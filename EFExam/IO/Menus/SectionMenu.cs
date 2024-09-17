using EFExam.Entities;
using EFExam.IO.Interfaces;
using EFExam.Persistence;
using EFExam.Persistence.Sections;

namespace EFExam.IO.Menus;

public class SectionMenu(IUi ui, ApplicationDbContext context) : MenuStructure(ui)
{
    private readonly SectionRepository _sectionRepository = new(context);
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
        var section = new Section
        {
            Area = ui.GetIntegerFromUser("Enter section area: "),
            AnimalCount = ui.GetIntegerFromUser("Enter section animal count: "),
            Description = ui.GetStringFromUser("Enter section description: "),
            AnimalId = ui.GetIntegerFromUser("Enter animal Id: "),
            TicketId = ui.GetIntegerFromUser("Enter ticket Id: "),
            ZooId = ui.GetIntegerFromUser("Enter zoo Id: ")
        };
        _sectionRepository.Create(section);
        context.SaveChanges();
    }

    public void ReadAll()
    {
        var sections = _sectionRepository.ReadAll();

        sections.ForEach(a =>
        {
            
        });
    }

    public void Read()
    {
        var animalId = ui.GetIntegerFromUser("Enter animal id:");
        var animal = _sectionRepository.Read(animalId);
        // ui.ShowMessage($"Id: {animal.Id}, Name: {animal.Name}");
    }


    private void Update()
    {
        ReadAll();
        var sectionId = ui.GetIntegerFromUser("Enter section id:");
        var section = _sectionRepository.Read(sectionId);
        section.Area = ui.GetIntegerFromUser("Enter section area");
        section.Description = ui.GetStringFromUser("Enter section description:");
        section.AnimalCount = ui.GetIntegerFromUser("Enter section animal count:");
        context.SaveChanges();
    }

    private void Delete()
    {
        ReadAll();
        var sectionId = ui.GetIntegerFromUser("Enter section id:");
        var section = _sectionRepository.Read(sectionId);
        _sectionRepository.Delete(sectionId);
        context.SaveChanges();
    }
}