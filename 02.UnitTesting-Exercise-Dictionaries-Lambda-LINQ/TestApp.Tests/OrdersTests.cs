using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class OrdersTests
{
    [Test]
    public void Test_Order_WithEmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string[] products = Array.Empty<string>();

        // Act
        string result = Orders.Order(products);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_Order_WithMultipleOrders_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] products = { "apple 1.99 3", "banana 1.50 2", "banana 1.25 1", "orange 0.99 2"};

        string expected = $"apple -> 5.97{Environment.NewLine}" +
                          $"banana -> 3.75{Environment.NewLine}" +
                          $"orange -> 1.98";

        // Act
        string result = Orders.Order(products);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Order_WithRoundedPrices_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] products = { "apple 1.9999 3", "banana 1.251232 3", "orange 0.5093 2" };

        string expected = $"apple -> 6.00{Environment.NewLine}" +
                          $"banana -> 3.75{Environment.NewLine}" +
                          $"orange -> 1.02";

        // Act
        string result = Orders.Order(products);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Order_WithDecimalQuantities_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] products = { "apple 1.5 3.5", "banana 1.50 2.85", "orange 0.99 2.18" };

        string expected = $"apple -> 5.25{Environment.NewLine}" +
                          $"banana -> 4.28{Environment.NewLine}" +
                          $"orange -> 2.16";

        // Act
        string result = Orders.Order(products);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
