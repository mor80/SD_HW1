using SD_HW1.Animals.Abstractions;

namespace SD_HW1.Animals;

/// <summary>
/// Тигр (хищник).
/// </summary>
public class Tiger : Predator
{
    public Tiger(string name, int foodPerDay, int inventoryNumber)
        : base(name, foodPerDay, inventoryNumber)
    {
    }
}