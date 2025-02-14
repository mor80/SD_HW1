using SD_HW1.Animals;
using SD_HW1.Animals.Abstractions;
using SD_HW1.Organizations;
using SD_HW1.Organizations.Abstractions;
using SD_HW1.Things;

namespace ZooTests;

public class ZooTests
{
    /// <summary>
    /// Фейковая ветклиника для контроля результата проверки здоровья.
    /// </summary>
    private class FakeVetClinic : IVetClinic
    {
        private readonly bool _healthResult;

        public FakeVetClinic(bool healthResult)
        {
            _healthResult = healthResult;
        }

        public bool CheckHealth(Animal animal) => _healthResult;
    }

    [Fact]
    public void AcceptAnimal_HealthyAnimal_IsAddedToZoo()
    {
        // Arrange
        var vetClinic = new FakeVetClinic(true);
        var zoo = new Zoo(vetClinic);

        var rabbit = new Rabbit("Тест-кролик", 2, 101, 8);

        // Act
        zoo.AcceptAnimal(rabbit);

        // Assert
        // Животное должно быть здоровым и находиться в "зоопарке".
        Assert.True(rabbit.IsHealthy, "Здоровье должно быть true");
        // Убеждаемся, что в общем списке инвентаря теперь есть этот кролик.
        var allInventory = zoo.GetAllInventoryInternal();
        Assert.Single(allInventory); 
        Assert.Equal(rabbit, allInventory[0]);
    }

    [Fact]
    public void AcceptAnimal_UnhealthyAnimal_IsRejected()
    {
        // Arrange
        var vetClinic = new FakeVetClinic(false);
        var zoo = new Zoo(vetClinic);

        var tiger = new Tiger("Тест-тигр", 10, 202);

        // Act
        zoo.AcceptAnimal(tiger);

        // Assert
        Assert.False(tiger.IsHealthy, "Тигр должен считаться нездоровым");

        // Убеждаемся, что в зоопарке нет этого тигра
        var allInventory = zoo.GetAllInventoryInternal();
        Assert.Empty(allInventory);
    }

    [Fact]
    public void AcceptMultipleAnimals_CheckTotalFoodConsumption()
    {
        // Arrange
        var vetClinic = new FakeVetClinic(true); // Все животные будут приняты
        var zoo = new Zoo(vetClinic);

        var rabbit = new Rabbit("Кролик", 2, 101, 8);
        var monkey = new Monkey("Обезьяна", 3, 102, 5);
        var tiger = new Tiger("Тигр", 10, 103);

        // Act
        zoo.AcceptAnimal(rabbit);
        zoo.AcceptAnimal(monkey);
        zoo.AcceptAnimal(tiger);

        // Assert
        // Проверяем суммарное потребление корма: 2 + 3 + 10 = 15
        int totalFood = zoo.GetTotalFoodConsumption();
        Assert.Equal(15, totalFood);

        // Проверим, что все три животные действительно в списке
        var allInv = zoo.GetAllInventoryInternal();
        Assert.Equal(3, allInv.Count);
    }

    [Fact]
    public void AcceptThing_ThingIsAddedToInventory()
    {
        // Arrange
        var vetClinic = new FakeVetClinic(true);
        var zoo = new Zoo(vetClinic);

        var table = new Table("Стол", 999);

        // Act
        zoo.AcceptThing(table);

        // Assert
        var allInv = zoo.GetAllInventoryInternal();
        Assert.Single(allInv);
        Assert.Equal(table, allInv[0]);
    }

    [Fact]
    public void GetAllInventoryInternal_ShouldCombineAnimalsAndThings()
    {
        // Arrange
        var vetClinic = new FakeVetClinic(true);
        var zoo = new Zoo(vetClinic);

        var rabbit = new Rabbit("Кролик", 1, 100, 7);
        var table = new Table("Стол", 200);

        // Act
        zoo.AcceptAnimal(rabbit);
        zoo.AcceptThing(table);

        // Assert
        var allInv = zoo.GetAllInventoryInternal();
        Assert.Equal(2, allInv.Count);

        // Проверяем, что среди инвентаря есть и кролик, и стол
        Assert.Contains(allInv, x => x is Rabbit);
        Assert.Contains(allInv, x => x is Table);
    }

    [Fact]
    public void GetContactZooCandidatesInternal_OnlyHerboWithKindnessAbove5()
    {
        // Arrange
        var vetClinic = new FakeVetClinic(true);
        var zoo = new Zoo(vetClinic);

        var rabbit = new Rabbit("Добрый кролик", 1, 100, 9);
        var wolf = new Wolf("Злой волк", 8, 101);
        var monkey = new Monkey("Обезьяна", 3, 102, 3);

        // Act
        zoo.AcceptAnimal(rabbit);
        zoo.AcceptAnimal(wolf);
        zoo.AcceptAnimal(monkey);

        var candidates = zoo.GetContactZooCandidatesInternal();

        // Assert
        Assert.Single(candidates);
        Assert.Equal("Добрый кролик", candidates[0].Name);
    }

    [Fact]
    public void GetContactZooCandidatesInternal_KindnessEquals5IsNotIncluded()
    {
        // Arrange
        var vetClinic = new FakeVetClinic(true);
        var zoo = new Zoo(vetClinic);

        // Травоядное с kindness=5 — не должно попасть
        var monkey = new Monkey("Обезьяна-5", 3, 110, 5);
        zoo.AcceptAnimal(monkey);

        // Травоядное с kindness=6 — должно попасть
        var rabbit = new Rabbit("Кролик-6", 1, 120, 6);
        zoo.AcceptAnimal(rabbit);

        // Act
        var candidates = zoo.GetContactZooCandidatesInternal();

        // Assert
        Assert.Single(candidates);
        Assert.Equal("Кролик-6", candidates[0].Name);
    }
}
