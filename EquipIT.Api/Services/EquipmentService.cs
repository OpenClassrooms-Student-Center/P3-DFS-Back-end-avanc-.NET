using EquipIT.Api.Data;
using EquipIT.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EquipIT.Api.Services;

public class EquipmentService : IEquipmentService
{
    private readonly EquipITDbContext _context;

    public EquipmentService(EquipITDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Equipment>> GetAllEquipmentAsync()
    {
        return await _context.Equipments.ToListAsync();
    }

    public async Task BorrowEquipmentAsync(int id, string firstName, string lastName)
    {
        // TODO: Implement business logic by checking availability and saving via EF Core
    }

    public async Task ReturnEquipmentAsync(int id)
    {
        // TODO: Implement business logic by checking availability and saving via EF Core
    }

    private async Task<Equipment> FindEquipmentAsync(int id)
    {
        var equipment = await _context.Equipments.FindAsync(id);
        if (equipment is null)
        {
            throw new InvalidOperationException($"Equipment with id {id} was not found.");
        }

        return equipment;
    }
}
