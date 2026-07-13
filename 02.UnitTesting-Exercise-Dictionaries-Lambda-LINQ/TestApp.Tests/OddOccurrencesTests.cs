using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class OddOccurrencesTests
{
    [Test]
    public void Test_FindOdd_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        string[] words = Array.Empty<string>();

        // Act
        string result = OddOccurrences.FindOdd(words);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_FindOdd_WithNoOddOccurrences_ShouldReturnEmptyString()
    {
        // Arrange
        string[] words = new string[] { "hello", "hello", "hi", "hi", "hi", "hi" };

        // Act
        string result = OddOccurrences.FindOdd(words);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_FindOdd_WithSingleOddOccurrence_ShouldReturnTheOddWord()
    {
        // Arrange
        string[] words = new string[] { "hello" };
        string expected = "hello";

        // Act
        string result = OddOccurrences.FindOdd(words);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindOdd_WithMultipleOddOccurrences_ShouldReturnAllOddWords()
    {
        // Arrange
        string[] words = new string[] { "hello", "hi", "hi", "dido", "dido", "go", "dido", "go" };
        string expected = "hello dido";

        // Act
        string result = OddOccurrences.FindOdd(words);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindOdd_WithMixedCaseWords_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] words = new string[] { "Hello", "HI", "hi", "Dido", "dido", "Go", "DiDo", "gO" };
        string expected = "hello dido";

        // Act
        string result = OddOccurrences.FindOdd(words);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
