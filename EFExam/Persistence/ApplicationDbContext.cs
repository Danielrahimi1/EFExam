using EFExam.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFExam.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<Animal> Animals { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Zoo> Zoos { get; set; }
    public DbSet<SoldTicket> SoldTickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(
        "Data Source=.;Initial Catalog=ZooManagement;Integrated Security=true;TrustServerCertificate=true;");


    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Zoo).Assembly);
}