using NUnit.Framework;

using System;
using System.Text;

namespace TestApp.Tests;

public class CountRealNumbersTests
{
    // TODO: finish test
    [Test]
    public void Test_Count_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        int[] numbers = Array.Empty<int>();

        // Act
        string result = CountRealNumbers.Count(numbers);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Count_WithSingleNumber_ShouldReturnCountString()
    {
        // Arrange
        int[] numbers = new int[] { 42 };
        string expected = "42 -> 1";

        // Act
        string result = CountRealNumbers.Count(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithMultipleNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] numbers = new int[] { 42, 2, 7, 2, 2, 13, 7 };
        StringBuilder expected = new StringBuilder();
        expected.AppendLine("2 -> 3");
        expected.AppendLine("7 -> 2");
        expected.AppendLine("13 -> 1");
        expected.AppendLine("42 -> 1");

        // Act
        string result = CountRealNumbers.Count(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString().Trim()));
    }

    [Test]
    public void Test_Count_WithNegativeNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] numbers = new int[] { -42, -2, -7, -2, -2, -13, -7 };
        StringBuilder expected = new StringBuilder();
        expected.AppendLine("-42 -> 1");
        expected.AppendLine("-13 -> 1");
        expected.AppendLine("-7 -> 2");
        expected.AppendLine("-2 -> 3");

        // Act
        string result = CountRealNumbers.Count(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString().Trim()));
    }

    [Test]
    public void Test_Count_WithZero_ShouldReturnCountString()
    {
        // Arrange
        int[] numbers = new int[] { 42, 2, 0, 2, 2, 0 };
        StringBuilder expected = new StringBuilder();
        expected.AppendLine("0 -> 2");
        expected.AppendLine("2 -> 3");
        expected.AppendLine("42 -> 1");

        // Act
        string result = CountRealNumbers.Count(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString().Trim()));
    }
}
