using NUnit.Framework;

using System;
using System.Text;

namespace TestApp.Tests;

public class PlantsTests
{
    [Test]
    public void Test_GetFastestGrowing_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        string[] plants = Array.Empty<string>();

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_GetFastestGrowing_WithSinglePlant_ShouldReturnPlant()
    {
        // Arrange
        string[] plants = { "rose" };
        StringBuilder expected = new StringBuilder();
        expected.AppendLine("Plants with 4 letters:");
        expected.AppendLine("rose");

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString().Trim()));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMultiplePlants_ShouldReturnGroupedPlants()
    {
        // Arrange
        string[] plants = { "orchid", "rose", "tulip", "camellia", "lily", "iris", "daisy", "violet" };

        StringBuilder expected = new StringBuilder();
        expected.AppendLine("Plants with 4 letters:");
        expected.AppendLine("rose");
        expected.AppendLine("lily");
        expected.AppendLine("iris");
        expected.AppendLine("Plants with 5 letters:");
        expected.AppendLine("tulip");
        expected.AppendLine("daisy");
        expected.AppendLine("Plants with 6 letters:");
        expected.AppendLine("orchid");
        expected.AppendLine("violet");
        expected.AppendLine("Plants with 8 letters:");
        expected.AppendLine("camellia");

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString().Trim()));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMixedCasePlants_ShouldBeCaseSensitive()
    {
        // Arrange
        string[] plants = { "rose", "Rose", "ROSE" };
        StringBuilder expected = new StringBuilder();
        expected.AppendLine("Plants with 4 letters:");
        expected.AppendLine("rose");
        expected.AppendLine("Rose");
        expected.AppendLine("ROSE");

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString().Trim()));
    }
}
