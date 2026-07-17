using NUnit.Framework;

using System;
using System.ComponentModel;
using TestApp.Vehicle;

namespace TestApp.UnitTests;

public class VehicleTests
{
    private Vehicles _vehicles;

    [SetUp]
    public void SetUp()
    {
        _vehicles = new Vehicles();
    }

    // TODO: finish test
    [Test]
    public void Test_AddAndGetCatalogue_ReturnsSortedCatalogue()
    {
        // Arrange
                             //"{type}/{brand}/{model}/{power}"
        string[] input = { "Truck/Volvo/VNL/500", "Car/Toyota/Camry/150", "Car/Ford/Focus/120", "Truck/Scania/G-Series/700" };

        string expected = $"Cars:{Environment.NewLine}" +
                            $"Ford: Focus - 120hp{Environment.NewLine}" +
                            $"Toyota: Camry - 150hp{Environment.NewLine}" +
                            $"Trucks:{Environment.NewLine}" +
                            $"Scania: G-Series - 700kg{Environment.NewLine}" +
                            $"Volvo: VNL - 500kg";

        // Act
        string result = this._vehicles.AddAndGetCatalogue(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndGetCatalogue_ReturnsEmptyCatalogue_WhenNoDataGiven()
    {
        // Arrange
        string[] input = { };

        string expected = $"Cars:{Environment.NewLine}" +
                          $"Trucks:";

        // Act
        string result = this._vehicles.AddAndGetCatalogue(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
