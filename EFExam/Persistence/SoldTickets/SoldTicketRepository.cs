using EFExam.Dtos.SoldTickets;
using EFExam.Entities;

namespace EFExam.Persistence.SoldTickets;

public class SoldSoldTicketRepository(ApplicationDbContext context)
{
    
    public List<SoldTicketByCountSoldDto> GetSoldTicketByCountSoldDto()
    {
        return (from soldTicket in context.Set<SoldTicket>()
                join ticket in context.Set<Ticket>()
                    on soldTicket.TicketId equals ticket.Id
                    into soldsTickets
                group soldsTickets by soldTicket.Id into groupedSoldTickets
                select new SoldTicketByCountSoldDto()
                {
                    Id = groupedSoldTickets.Key,
                    CountSold = groupedSoldTickets.Count()
                }
            ).OrderByDescending(g => g.CountSold).ToList();
    }
    
    // public List<Section> GetAllSectionsSortedByTotalIncome(int id)
    // {
    //     var zoo = context.Set<Zoo>().FirstOrDefault(z => z.Id == id);
    //     var sections =
    //     (
    //         from section in context.Set<Section>()
    //         where section.ZooId == zoo.Id
    //         select section).ToList();
    //     return sections.OrderBy(_ => _.TotalIncome = _.TicketPrice * _.TicketSalesCount).ToList();
    // }
    
    public void Create(SoldTicket st)
    {
        context.Set<SoldTicket>().Add(st);
    }

    // public List<SoldTicketDto> ReadAll()
    // {
    //     
    //     var sectionTicket = (from t in context.Set<Ticket>()
    //             join s in context.Set<Section>()
    //                 on t.Id equals s.TicketId
    //             select new
    //             {
    //                 Id = t.Id,
    //                 Price = t.Price,
    //                 SectionId = s.Id
    //             }
    //         ).ToList();
    //
    //     return (from soldticket in context.Set<SoldTicket>()
    //         join st in sectionTicket
    //             on soldticket.TicketId equals st.Id
    //         select new SoldTicketDto
    //         {
    //             Id = soldticket.Id,
    //             SectionId = st.SectionId,
    //             Price = st.Price
    //         }).GroupBy(_=>_.SectionId).Select(dto => new SoldTicketDto
    //     {
    //         Id = dto.Id,
    //         SectionId = dto.SectionId,
    //         Price = dto.Price
    //     }).ToList();

        
        // return context.Set<SoldTicket>().Select(st => new SoldTicketDto
        // {
        //     Id = st.Id,
        //     SectionId = st.,
        //     Price = 0,
        //     AnimalName = null
        // }).ToList();
    //}

    // public SoldTicketDto? Read(int id)
    // {
        // return context.Set<SoldTicket>().Include(st=>st.T).Select(t => new SoldTicketDto
        // {
        //     Id = t.Id,
        //     Price = t.Price
        //     AnimalName = t.Section.Animal!.Name
        // }).FirstOrDefault(t => t.Id == id);
    // }

    public void Update(SoldTicket newSoldTicket)
    {
        context.Set<SoldTicket>().Update(newSoldTicket);
    }

    public void Delete(int id)
    {
        var st = context.Set<SoldTicket>().FirstOrDefault(t => t.Id == id);
        if (st != null)
        {
            context.Set<SoldTicket>().Remove(st);
        }
    }
}