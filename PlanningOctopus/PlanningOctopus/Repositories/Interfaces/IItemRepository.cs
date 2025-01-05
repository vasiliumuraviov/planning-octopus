using PlanningOctopus.Repositories.Dto;

namespace PlanningOctopus.Repositories.Interfaces;

public interface IItemRepository
{
    Task<ItemDto?> GetItemAsync(Guid id);
    Task<IEnumerable<ItemDto>> GetAllItemsAsync();
    Task<ItemDto> CreateItemAsync(CreateItemDto itemDto);
    Task<ItemDto?> UpdateItemAsync(UpdateItemDto itemDto);
    Task DeleteItemAsync(Guid id);
}
