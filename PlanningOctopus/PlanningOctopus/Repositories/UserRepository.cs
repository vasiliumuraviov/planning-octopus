using Microsoft.EntityFrameworkCore;
using PlanningOctopus.Data;
using PlanningOctopus.Data.Entities;
using PlanningOctopus.Repositories.Dto;
using PlanningOctopus.Repositories.Interfaces;

namespace PlanningOctopus.Repositories;

public class UserRepository(OctoDbContext dbContext) : IUserRepository
{
    public async Task<UserDto?> GetUserAsync(Guid id)
    {
        var user = await dbContext.Users.FindAsync(id);
        return user == null ? null : MapToDto(user);
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        => await dbContext.Users.Select(user => MapToDto(user))
                                .ToListAsync();

    public async Task<UserDto> CreateUserAsync(CreateUserDto userDto)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = userDto.Name
        };

        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();

        return MapToDto(user);
    }

    public async Task<UserDto?> UpdateUserAsync(UpdateUserDto userDto)
    {
        var user = await dbContext.Users.FindAsync(userDto.Id);
        if (user is null)
            return null;

        user.Name = userDto.Name;
        await dbContext.SaveChangesAsync();

        return MapToDto(user);
    }

    public async Task DeleteUserAsync(Guid id)
    {
        var user = await dbContext.Users.FindAsync(id);
        if (user != null)
        {
            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
        }
    }

    private static UserDto MapToDto(User user) => new(user.Id, user.Name);
}