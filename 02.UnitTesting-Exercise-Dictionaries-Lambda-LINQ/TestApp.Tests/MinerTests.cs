using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class MinerTests
{
    [Test]
    public void Test_Mine_WithEmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string[] elements = Array.Empty<string>();

        // Act
        string result = Miner.Mine(elements);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_Mine_WithMixedCaseResources_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] elements = new string[] { "GOLD 2", "Silver 10", "Gold 6", "SILVER 5", "SilVer 15" };
        string expected = $"gold -> 8{Environment.NewLine}" +
                          $"silver -> 30";

        // Act
        string result = Miner.Mine(elements);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Mine_WithDifferentResources_ShouldReturnResourceCounts()
    {
        // Arrange
        string[] elements = new string[] { "gold 2", "silver 10", "gold 6", "silver 20", "copper 15" };
        string expected = $"gold -> 8{Environment.NewLine}" +
                          $"silver -> 30{Environment.NewLine}" +
                          "copper -> 15";

        // Act
        string result = Miner.Mine(elements);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
