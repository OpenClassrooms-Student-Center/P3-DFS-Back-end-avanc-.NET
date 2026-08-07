using EquipIT.Front.Models;

namespace EquipIT.Front.Services;

public class EquipmentApiService
{
    // TODO: Pour l'exercice 2, remplacez ces données mockées par un appel HTTP réel vers votre API Backend.
    // En attendant, le front fonctionne hors-ligne avec cette liste simulée en mémoire.
    private readonly List<Equipment> _mockEquipments =
    [
        new Equipment { Id = 1, Name = "Monitor", Category = "Display", IsAvailable = true },
        new Equipment { Id = 2, Name = "Keyboard", Category = "Input", IsAvailable = true },
        new Equipment { Id = 3, Name = "Mouse", Category = "Input", IsAvailable = true },
    ];

    public Task<List<Equipment>> GetEquipmentAsync()
    {
        return Task.FromResult(_mockEquipments.ToList());
    }

    public Task BorrowAsync(int id, string firstName, string lastName)
    {
        var equipment = _mockEquipments.FirstOrDefault(e => e.Id == id);
        if (equipment is null || !equipment.IsAvailable)
        {
            throw new HttpRequestException("Equipment not found or already borrowed.");
        }

        equipment.IsAvailable = false;
        equipment.BorrowerFirstName = firstName;
        equipment.BorrowerLastName = lastName;
        equipment.BorrowDate = DateTime.UtcNow;
        return Task.CompletedTask;
    }

    public Task ReturnAsync(int id)
    {
        var equipment = _mockEquipments.FirstOrDefault(e => e.Id == id);
        if (equipment is null || equipment.IsAvailable)
        {
            throw new HttpRequestException("Equipment not found or not currently borrowed.");
        }

        equipment.IsAvailable = true;
        equipment.LastReturnDate = DateTime.UtcNow;
        equipment.BorrowerFirstName = null;
        equipment.BorrowerLastName = null;
        equipment.BorrowDate = null;
        return Task.CompletedTask;
    }
}
