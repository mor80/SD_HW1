using SD_HW1.Animals.Abstractions;

namespace SD_HW1.Animals;

/// <summary>
/// Волк (хищник).
/// </summary>
public class Wolf : Predator
{
    public Wolf(string name, int foodPerDay, int inventoryNumber)
        : base(name, foodPerDay, inventoryNumber)
    {
    }
}