namespace SD_HW1.Things.Abstractions;

/// <summary>
/// Базовый класс "вещь" (подлежит инвентаризации).
/// </summary>
public abstract class Thing : IInventory
{
    public int Number { get; set; }
    public string Title { get; set; }

    protected Thing(string title, int inventoryNumber)
    {
        Title = title;
        Number = inventoryNumber;
    }

    public override string ToString()
    {
        return $"Вещь [{Number}]: {Title}";
    }
}