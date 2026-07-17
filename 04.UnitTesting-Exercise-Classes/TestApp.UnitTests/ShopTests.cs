using NUnit.Framework;

using System;

using TestApp.Store;

namespace TestApp.UnitTests;

public class ShopTests
{
    private Shop _shop;

    [SetUp]
    public void SetUp()
    {
        _shop = new Shop();
    }

    // TODO: finish test
    [Test]
    public void Test_AddAndGetBoxes_ReturnsSortedBoxes()
    {
        // Arrange
                            //"{serial_number} {name} {quantity} {price}"
        string[] products = { "54321 Keyboard 3 15", "98765 MousePad 2 3", "12345 Mouse 5 10" };

        string expected = $"12345{Environment.NewLine}" +
                          $"-- Mouse - $10.00: 5{Environment.NewLine}" +
                          $"-- $50.00{Environment.NewLine}" +
                          $"54321{Environment.NewLine}" +
                          $"-- Keyboard - $15.00: 3{Environment.NewLine}" +
                          $"-- $45.00{Environment.NewLine}" +
                          $"98765{Environment.NewLine}" +
                          $"-- MousePad - $3.00: 2{Environment.NewLine}" +
                          $"-- $6.00";

        // Act
        string result = this._shop.AddAndGetBoxes(products);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndGetBoxes_ReturnsEmptyString_WhenNoProductsGiven()
    {
        // Arrange
        string[] products = Array.Empty<string>();

        // Act
        string result = this._shop.AddAndGetBoxes(products);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // BONUS TEST
    [Test]
    public void Test_AddAndGetBoxes_ReturnsRoudedPriceToSecondDecimalPlaces()
    {
        // Arrange
        //"{serial_number} {name} {quantity} {price}"
        string[] products = { "98765 MousePad 2 3.4245", "12345 Mouse 5 9.8572" };

        string expected = $"12345{Environment.NewLine}" +
                          $"-- Mouse - $9.86: 5{Environment.NewLine}" +
                          $"-- $49.29{Environment.NewLine}" +
                          $"98765{Environment.NewLine}" +
                          $"-- MousePad - $3.42: 2{Environment.NewLine}" +
                          $"-- $6.85";

        // Act
        string result = this._shop.AddAndGetBoxes(products);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
