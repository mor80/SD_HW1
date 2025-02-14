using System.ComponentModel;

namespace SD_HW1.Animals.Abstractions;

/// <summary>
/// Хищное животное.
/// </summary>
public abstract class Predator : Animal
{
    protected Predator(string name, int foodPerDay, int inventoryNumber)
        : base(name, foodPerDay, inventoryNumber)
    {
    }
}