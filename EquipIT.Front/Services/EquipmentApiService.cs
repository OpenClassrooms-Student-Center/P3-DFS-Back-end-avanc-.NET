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
        // TODO: Replace with HttpClient calls to the API and send FirstName/LastName during PUT.
        return Task.CompletedTask;
    }

    public Task ReturnAsync(int id)
    {
        // TODO: Replace with HttpClient calls to the API and send FirstName/LastName during PUT.
        return Task.CompletedTask;
    }
}
