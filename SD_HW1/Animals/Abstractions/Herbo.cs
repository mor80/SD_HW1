namespace SD_HW1.Animals.Abstractions;

/// <summary>
/// Травоядное животное.
/// </summary>
public abstract class Herbo : Animal
{
    public int KindnessLevel { get; set; }

    protected Herbo(string name, int foodPerDay, int inventoryNumber, int kindnessLevel)
        : base(name, foodPerDay, inventoryNumber)
    {
        KindnessLevel = kindnessLevel;
    }

    public override string ToString()
    {
        return base.ToString() + $", доброта: {KindnessLevel}";
    }
}