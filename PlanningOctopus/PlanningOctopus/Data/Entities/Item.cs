namespace PlanningOctopus.Data.Entities;

public class Item
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime CreatedUtc { get; set; }
}