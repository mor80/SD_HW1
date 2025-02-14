using Microsoft.Extensions.DependencyInjection;
using SD_HW1.Animals;
using SD_HW1.Animals.Abstractions;
using SD_HW1.Organizations;
using SD_HW1.Organizations.Abstractions;
using SD_HW1.Things;
using SD_HW1.Things.Abstractions;

namespace SD_HW1;

class Program
{
    static void Main(string[] args)
    {
        // DI-контейнер.
        var serviceCollection = new ServiceCollection();

        // Регистрируем IVetClinic и IZoo.
        serviceCollection.AddSingleton<IVetClinic, VetClinic>();
        serviceCollection.AddSingleton<IZoo, Zoo>();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Получаем объект зоопарка
        var zoo = serviceProvider.GetService<IZoo>();

        // Запускаем главное меню для взаимодействия с пользователем
        RunMenu(zoo);
    }

    private static void RunMenu(IZoo zoo)
    {
        while (true)
        {
            Console.WriteLine("\n--- Меню зоопарка ---");
            Console.WriteLine("1. Добавить животное");
            Console.WriteLine("2. Добавить вещь");
            Console.WriteLine("3. Показать всех животных");
            Console.WriteLine("4. Показать суммарное потребление корма и кол-во животных");
            Console.WriteLine("5. Показать животных для контактного зоопарка");
            Console.WriteLine("6. Показать весь инвентарь (включая животных)");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите пункт: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddAnimal(zoo);
                    break;
                case "2":
                    AddThing(zoo);
                    break;
                case "3":
                    zoo.PrintAllAnimals();
                    break;
                case "4":
                    zoo.PrintFoodConsumptionReport();
                    break;
                case "5":
                    zoo.PrintContactZooCandidates();
                    break;
                case "6":
                    zoo.PrintAllInventory();
                    break;
                case "0":
                    Console.WriteLine("Выход...");
                    return;
                default:
                    Console.WriteLine("Неизвестная команда!");
                    break;
            }
        }
    }

    private static void AddAnimal(IZoo zoo)
    {
        Console.Write("Введите имя животного: ");
        string name = Console.ReadLine();

        Console.Write("Введите потребление еды (кг/сутки): ");
        int foodPerDay;
        while (!int.TryParse(Console.ReadLine(), out foodPerDay))
        {
            Console.Write("Неверный ввод! Введите целое число: ");
        }

        Console.Write("Введите инвентарный номер: ");
        int number;
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Неверный ввод! Введите целое число: ");
        }

        Console.WriteLine("Тип животного:");
        Console.WriteLine("1. Травоядное (Herbo)");
        Console.WriteLine("2. Хищное (Predator)");
        Console.Write("Выберите тип (1 или 2): ");
        var typeChoice = Console.ReadLine();

        switch (typeChoice)
        {
            case "1":
                // Травоядное
                Console.Write("Уровень доброты (0..10): ");
                int kindness;
                while (!int.TryParse(Console.ReadLine(), out kindness))
                {
                    Console.Write("Неверный ввод! Введите целое число: ");
                }

                Console.WriteLine("Варианты травоядных:");
                Console.WriteLine("1. Кролик");
                Console.WriteLine("2. Обезьяна");
                Console.Write("Выберите подтип (1 или 2): ");
                var herboChoice = Console.ReadLine();
                Animal herboAnimal;
                if (herboChoice == "1")
                {
                    herboAnimal = new Rabbit(name, foodPerDay, number, kindness);
                }
                else
                {
                    herboAnimal = new Monkey(name, foodPerDay, number, kindness);
                }

                zoo.AcceptAnimal(herboAnimal);
                break;

            case "2":
                // Хищник
                Console.WriteLine("Варианты хищников:");
                Console.WriteLine("1. Тигр");
                Console.WriteLine("2. Волк");
                Console.Write("Выберите подтип (1 или 2): ");
                var predatorChoice = Console.ReadLine();
                Animal predatorAnimal;
                if (predatorChoice == "1")
                {
                    predatorAnimal = new Tiger(name, foodPerDay, number);
                }
                else
                {
                    predatorAnimal = new Wolf(name, foodPerDay, number);
                }

                zoo.AcceptAnimal(predatorAnimal);
                break;

            default:
                Console.WriteLine("Неверный тип. Животное не добавлено.");
                break;
        }
    }

    private static void AddThing(IZoo zoo)
    {
        Console.Write("Введите название вещи: ");
        string title = Console.ReadLine();

        Console.Write("Введите инвентарный номер: ");
        int number;
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Неверный ввод! Введите целое число: ");
        }

        Console.WriteLine("Варианты вещей:");
        Console.WriteLine("1. Стол");
        Console.WriteLine("2. Компьютер");
        Console.Write("Выберите подтип (1 или 2): ");
        var typeChoice = Console.ReadLine();
        Thing thing;
        if (typeChoice == "1")
        {
            thing = new Table(title, number);
        }
        else
        {
            thing = new Computer(title, number);
        }

        zoo.AcceptThing(thing);
    }
}
