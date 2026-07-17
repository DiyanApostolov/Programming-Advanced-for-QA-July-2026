using NUnit.Framework;

using System;
using System.Text;
using System.Xml.Linq;

namespace TestApp.UnitTests;

public class PlanetTests
{
    [Test]
    public void Test_CalculateGravity_ReturnsCorrectCalculation()
    {
        // Arrange
        Planet earth = new("Earth", 12742, 149600000, 1);
        double mass = 1000;
        double expectedGravity = mass * 6.67430e-11 / Math.Pow(earth.Diameter / 2, 2);

        // Act
        double result = earth.CalculateGravity(mass);

        // Assert
        Assert.That(result, Is.EqualTo(expectedGravity));
    }

    [Test]
    public void Test_GetPlanetInfo_ReturnsCorrectInfo()
    {
        // Arrange
        Planet planet = new("Mars", 6779, 228000000, 2);

        StringBuilder expected = new StringBuilder();
        expected.AppendLine($"Planet: Mars");
        expected.AppendLine($"Diameter: 6779 km");
        expected.AppendLine($"Distance from the Sun: 228000000 km");
        expected.AppendLine($"Number of Moons: 2");

        // Act
        string result = planet.GetPlanetInfo();

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString().Trim()));
    }
}
