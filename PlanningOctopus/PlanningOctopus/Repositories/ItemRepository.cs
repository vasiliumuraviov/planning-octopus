using Microsoft.EntityFrameworkCore;
using PlanningOctopus.Data;
using PlanningOctopus.Data.Entities;
using PlanningOctopus.Repositories.Dto;
using PlanningOctopus.Repositories.Interfaces;

namespace PlanningOctopus.Repositories;

public class ItemRepository(OctoDbContext dbContext) : IItemRepository
{
    public async Task<ItemDto?> GetItemAsync(Guid id)
    {
        var item = await dbContext.Items.FindAsync(id);
        return item is null ? null : MapToDto(item);
    }

    public async Task<IEnumerable<ItemDto>> GetAllItemsAsync()
        => await dbContext.Items.Select(item => MapToDto(item))
                                .ToListAsync();

    public async Task<ItemDto> CreateItemAsync(CreateItemDto itemDto)
    {
        var item = new Item
        {
            Id = Guid.NewGuid(),
            Title = itemDto.Title,
            Content = itemDto.Content
        };

        dbContext.Items.Add(item);
        await dbContext.SaveChangesAsync();

        return MapToDto(item);
    }

    public async Task<ItemDto?> UpdateItemAsync(UpdateItemDto itemDto)
    {
        var item = await dbContext.Items.FindAsync(itemDto.Id);
        if (item is null)
            return null;

        item.Title = itemDto.Title;
        item.Content = itemDto.Content;

        await dbContext.SaveChangesAsync();

        return MapToDto(item);
    }

    public async Task DeleteItemAsync(Guid id)
    {
        var item = await dbContext.Items.FindAsync(id);
        if (item != null)
        {
            dbContext.Items.Remove(item);
            await dbContext.SaveChangesAsync();
        }
    }

    private static ItemDto MapToDto(Item item) => new(item.Id, item.Title, item.Content, item.Created);
}