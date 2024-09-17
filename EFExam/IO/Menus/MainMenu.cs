using EFExam.Entities;
using EFExam.IO.Interfaces;
using EFExam.Persistence;

namespace EFExam.IO.Menus;

public class MainMenu(ApplicationDbContext context, IUi ui) : MenuStructure(ui)
{
    protected override void AddMenuItems()
    {
        MenuItems.Add("Animal Menu", ShowAnimalMenu);
        MenuItems.Add("Section Menu", ShowSectionMenu);
        MenuItems.Add("SoldTicket Menu", ShowSoldTicketMenu);
        MenuItems.Add("Ticket Menu", ShowTicketMenu);
        MenuItems.Add("Zoo Menu", ShowZooMenu);
    }

    private void ShowZooMenu()
    {
        //new ZooMenu(ui, context).Show();
    }

    private void ShowTicketMenu()
    {
        // new TicketMenu(ui, context).Show();
    }

    private void ShowSoldTicketMenu()
    {
        // new SoldTicket(ui, context).Show();
    }

    private void ShowSectionMenu()
    {
        new SectionMenu(ui, context).Show();
    }

    private void ShowAnimalMenu()
    {
        new AnimalMenu(ui, context).Show();
    }

    
}