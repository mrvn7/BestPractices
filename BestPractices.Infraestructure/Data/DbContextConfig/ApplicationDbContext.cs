using BestPractices.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace BestPractices.Infraestructure.Data.DbContextConfig;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Client> Clients { get; set; }
}