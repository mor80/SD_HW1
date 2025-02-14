using System.Runtime.Serialization.Formatters;
using SD_HW1.Things.Abstractions;

namespace SD_HW1.Animals.Abstractions;

/// <summary>
/// Базовый класс для всех животных.
/// </summary>
public abstract class Animal : IAlive, IInventory
{
    public int Food { get; set; } // IAlive
    public int Number { get; set; } // IInventory
    public string Name { get; set; }
    public bool IsHealthy { get; set; }

    protected Animal(string name, int foodPerDay, int inventoryNumber)
    {
        Name = name;
        Food = foodPerDay;
        Number = inventoryNumber;
    }

    public override string ToString()
    {
        return $"[{Number}] {Name}, еда в сутки: {Food} кг, " +
               $"здоров: {(IsHealthy ? "да" : "нет")}";
    }
}