namespace PlanningOctopus.Repositories.Dto;

public record UserDto(Guid Id, string Name);
public record CreateUserDto(string Name);
public record UpdateUserDto(Guid Id, string Name);