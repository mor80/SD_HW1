using SD_HW1.Animals.Abstractions;

namespace SD_HW1.Animals;

/// <summary>
/// Кролик (травоядный).
/// </summary>
public class Rabbit : Herbo
{
    public Rabbit(string name, int foodPerDay, int inventoryNumber, int kindnessLevel)
        : base(name, foodPerDay, inventoryNumber, kindnessLevel)
    {
    }
}