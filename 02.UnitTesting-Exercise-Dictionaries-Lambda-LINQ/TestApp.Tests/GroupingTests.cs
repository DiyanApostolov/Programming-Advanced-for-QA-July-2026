using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.Tests;

public class GroupingTests
{
    // TODO: finish test
    [Test]
    public void Test_GroupNumbers_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<int> numbers = new List<int>();

        // Act
        string result = Grouping.GroupNumbers(numbers);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_GroupNumbers_WithEvenAndOddNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> numbers = new List<int>() { 42, 1, 3, 8, 7, 12, 5 };
        string expected = "Even numbers: 42, 8, 12" + Environment.NewLine +
                          "Odd numbers: 1, 3, 7, 5";

        // Act
        string result = Grouping.GroupNumbers(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GroupNumbers_WithOnlyEvenNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> numbers = new List<int>() { 2, 4, 6, 8, 0 };
        string expected = "Even numbers: 2, 4, 6, 8, 0";

        // Act
        string result = Grouping.GroupNumbers(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Test_GroupNumbers_WithOnlyOddNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> numbers = new List<int>() { 1, 3, 11, 7 };
        string expected = "Odd numbers: 1, 3, 11, 7";

        // Act
        string result = Grouping.GroupNumbers(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GroupNumbers_WithNegativeNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> numbers = new List<int>() { -1, -3, -8, -7, -12, -5 };
        string expected = "Odd numbers: -1, -3, -7, -5" + Environment.NewLine +
                          "Even numbers: -8, -12";

        // Act
        string result = Grouping.GroupNumbers(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
