using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PlanningOctopus.Data.Entities;
using PlanningOctopus.Static.Config;

namespace PlanningOctopus.Data;

public class OctoDbContext(IOptions<ConnectionStringOptions> conns) : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(conns.Value.Octopus);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ApplyConstraintsOnItemEntity(modelBuilder);
        ApplyConstraintsOnUserEntity(modelBuilder);
    }

    private void ApplyConstraintsOnItemEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>()
            .HasKey(i => i.Id);

        modelBuilder.Entity<Item>()
                    .Property(i => i.Created)
                    .HasDefaultValueSql("NOW()");
    }

    private void ApplyConstraintsOnUserEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
                    .HasKey(u => u.Id);
    }
}