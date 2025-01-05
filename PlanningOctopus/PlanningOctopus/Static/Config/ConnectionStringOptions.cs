namespace PlanningOctopus.Static.Config;

public class ConnectionStringOptions
{
    public const string SectionName = "ConnectionStrings";

    public string Octopus { get; set; } = null!;
}
