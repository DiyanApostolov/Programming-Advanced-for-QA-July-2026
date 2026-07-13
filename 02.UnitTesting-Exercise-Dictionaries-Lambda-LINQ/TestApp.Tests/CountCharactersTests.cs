using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp.Tests;

public class CountCharactersTests
{
    [Test]
    public void Test_Count_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> input = new();

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_Count_WithNoCharacters_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> input = new() { "", "", "" };

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.Empty);
        Assert.That(input.Count, Is.EqualTo(3));
    }

    [Test]
    public void Test_Count_WithSingleCharacter_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new() { "a" };
        string expected = $"a -> 1";

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithMultipleCharacters_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new() { "abc", "Beer", "abba" };

        StringBuilder expected = new StringBuilder();
        expected.AppendLine("a -> 3");
        expected.AppendLine("b -> 3");
        expected.AppendLine("c -> 1");
        expected.AppendLine("B -> 1");
        expected.AppendLine("e -> 2");
        expected.AppendLine("r -> 1");

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString().Trim()));
    }

    [Test]
    public void Test_Count_WithSpecialCharacters_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new() { "abc!", "$ee", "a1" };

        StringBuilder expected = new StringBuilder();
        expected.AppendLine("a -> 2");
        expected.AppendLine("b -> 1");
        expected.AppendLine("c -> 1");
        expected.AppendLine("! -> 1");
        expected.AppendLine("$ -> 1");
        expected.AppendLine("e -> 2");
        expected.AppendLine("1 -> 1");

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString().Trim()));
    }
}
