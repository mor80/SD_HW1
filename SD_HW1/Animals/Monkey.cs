using SD_HW1.Animals.Abstractions;

namespace SD_HW1.Animals;

/// <summary>
/// Обезьяна (травоядная).
/// </summary>
public class Monkey : Herbo
{
    public Monkey(string name, int foodPerDay, int inventoryNumber, int kindnessLevel)
        : base(name, foodPerDay, inventoryNumber, kindnessLevel)
    {
    }
}