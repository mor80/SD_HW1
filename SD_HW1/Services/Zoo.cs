using SD_HW1.Animals.Abstractions;
using SD_HW1.Organizations.Abstractions;
using SD_HW1.Things.Abstractions;

namespace SD_HW1.Organizations;

public class Zoo : IZoo
{
    private readonly IVetClinic _vetClinic;

    // Храним всех животных, которых приняли
    private readonly List<Animal> _animals = new();

    // Храним все вещи
    private readonly List<Thing> _things = new();

    public Zoo(IVetClinic vetClinic)
    {
        _vetClinic = vetClinic;
    }

    public void AcceptAnimal(Animal animal)
    {
        bool isHealthy = _vetClinic.CheckHealth(animal);
        animal.IsHealthy = isHealthy;
        if (isHealthy)
        {
            _animals.Add(animal);
            Console.WriteLine($"[Zoo] Животное {animal.Name} принято в зоопарк!");
        }
        else
        {
            Console.WriteLine($"[Zoo] Животное {animal.Name} не прошло проверку здоровья.");
        }
    }

    public void PrintAllAnimals()
    {
        if (_animals.Count == 0)
        {
            Console.WriteLine("[Zoo] Пока нет животных в зоопарке.");
            return;
        }

        Console.WriteLine("[Zoo] Список всех животных:");
        foreach (var animal in _animals)
        {
            Console.WriteLine("   " + animal);
        }
    }

    public void PrintFoodConsumptionReport()
    {
        int totalFood = _animals.Sum(a => a.Food);
        Console.WriteLine($"[Zoo] Всего животных: {_animals.Count}, " +
                          $"суммарное потребление корма в день: {totalFood} кг");
    }

    public void PrintContactZooCandidates()
    {
        // Животное подходит в контактный зоопарк, если оно травоядное (Herbo) и KindnessLevel > 5
        var candidates = _animals
            .OfType<Herbo>()
            .Where(a => a.KindnessLevel > 5)
            .ToList();

        if (candidates.Count == 0)
        {
            Console.WriteLine("[Zoo] Нет животных, подходящих для контактного зоопарка.");
            return;
        }

        Console.WriteLine("[Zoo] Животные, подходящие для контактного зоопарка:");
        foreach (var c in candidates)
        {
            Console.WriteLine("   " + c);
        }
    }

    public void AcceptThing(Thing thing)
    {
        _things.Add(thing);
        Console.WriteLine($"[Zoo] Вещь {thing.Title} (инв. №{thing.Number}) добавлена на баланс.");
    }

    public void PrintAllInventory()
    {
        // Для удобства объединим вещи и животных (оба реализуют IInventory) и выведем
        var allInventory = new List<IInventory>();
        allInventory.AddRange(_animals);
        allInventory.AddRange(_things);

        if (allInventory.Count == 0)
        {
            Console.WriteLine("[Zoo] Пока нет инвентаря на балансе.");
            return;
        }

        Console.WriteLine("[Zoo] Все объекты на балансе (включая животных):");
        foreach (var item in allInventory)
        {
            // item может быть Animal или Thing, поэтому делаем простой вывод
            Console.WriteLine("   " + item);
        }
    }
}