using EFExam.Dtos.Tickets;
using EFExam.Entities;

namespace EFExam.Persistence.Tickets;

public class TicketRepository(ApplicationDbContext context)
{
    public void Create(Ticket ticket)
    {
        context.Set<Ticket>().Add(ticket);
    }

    public List<TicketDto> ReadAll()
    {
        return context.Set<Ticket>().Select(t => new TicketDto
        {
            Id = t.Id,
            Price = t.Price,
            AnimalName = t.Section.Animal!.Name
        }).ToList();
    }

    public TicketDto? Read(int id)
    {
        return context.Set<Ticket>().Select(t => new TicketDto
        {
            Id = t.Id,
            Price = t.Price,
            AnimalName = t.Section.Animal!.Name
        }).FirstOrDefault(t => t.Id == id);
    }

    public void Update(Ticket newTicket)
    {
        context.Set<Ticket>().Update(newTicket);
    }

    public void Delete(int id)
    {
        var ticket = context.Set<Ticket>().FirstOrDefault(t => t.Id == id);
        if (ticket != null)
        {
            context.Set<Ticket>().Remove(ticket);
        }
    }
}