using SD_HW1.Animals.Abstractions;
using SD_HW1.Things.Abstractions;

namespace SD_HW1.Organizations.Abstractions;

public interface IZoo
{
    /// <summary>
    /// Принять новое животное в зоопарк (с проверкой здоровья).
    /// </summary>
    void AcceptAnimal(Animal animal);

    /// <summary>
    /// Вывести информацию обо всех животных.
    /// </summary>
    void PrintAllAnimals();

    /// <summary>
    /// Вывести общую информацию по количеству животных и суммарному расходу корма.
    /// </summary>
    void PrintFoodConsumptionReport();

    /// <summary>
    /// Вывести список животных, подходящих для контактного зоопарка.
    /// </summary>
    void PrintContactZooCandidates();

    /// <summary>
    /// Добавить новую вещь на баланс.
    /// </summary>
    void AcceptThing(Thing thing);

    /// <summary>
    /// Показать все объекты, стоящие на балансе (включая животных).
    /// </summary>
    void PrintAllInventory();
}
