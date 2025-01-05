using PlanningOctopus.Repositories.Dto;

namespace PlanningOctopus.Repositories.Interfaces;

public interface IUserRepository
{
    Task<UserDto?> GetUserAsync(Guid id);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto> CreateUserAsync(CreateUserDto userDto);
    Task<UserDto?> UpdateUserAsync(UpdateUserDto userDto);
    Task DeleteUserAsync(Guid id);
}