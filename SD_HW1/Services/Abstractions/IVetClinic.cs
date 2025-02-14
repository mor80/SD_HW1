using SD_HW1.Animals.Abstractions;

namespace SD_HW1.Organizations.Abstractions;

public interface IVetClinic
{
    /// <summary>
    /// Проверка здоровья животного.
    /// Возвращает true, если животное здорово.
    /// </summary>
    bool CheckHealth(Animal animal);
}