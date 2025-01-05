using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PlanningOctopus.Data.Entities;
using PlanningOctopus.Static.Config;

namespace PlanningOctopus.Data;

public class OctoDbContext(IOptions<ConnectionStringOptions> conns) : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(conns.Value.Octopus);

    public DbSet<Item> Items { get; set; }
    public DbSet<User> Users { get; set; }
}