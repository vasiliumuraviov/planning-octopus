namespace PlanningOctopus.Repositories.Dto;

public record ItemDto(Guid Id, string Title, string Content, DateTime Created);
public record CreateItemDto(string Title, string Content);
public record UpdateItemDto(Guid Id, string Title, string Content);