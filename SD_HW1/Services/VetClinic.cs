using SD_HW1.Animals.Abstractions;
using SD_HW1.Organizations.Abstractions;

namespace SD_HW1.Organizations;

public class VetClinic : IVetClinic
{
    private readonly Random _random = new();

    /// <summary>
    /// Упрощённая проверка здоровья:
    /// Для примера возвращаем true/false случайным образом (или на основе параметров).
    /// В реальном приложении здесь была бы реальная логика.
    /// </summary>
    public bool CheckHealth(Animal animal)
    {
        // Допустим, 70% шанс, что животное здорово
        bool isHealthy = _random.Next(0, 100) < 70;
        return isHealthy;
    }
}