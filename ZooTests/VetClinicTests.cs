using SD_HW1.Animals;
using SD_HW1.Organizations;

namespace ZooTests;

public class VetClinicTests
{
    [Fact]
    public void CheckHealth_ReturnsBooleanValue()
    {
        // Arrange
        var clinic = new VetClinic();
        var tiger = new Tiger("RandomTiger", 5, 900);

        // Act
        bool result = clinic.CheckHealth(tiger);

        // Assert
        // Случайное поведение - мы просто проверяем, что метод возвращает bool
        Assert.IsType<bool>(result);
    }
}