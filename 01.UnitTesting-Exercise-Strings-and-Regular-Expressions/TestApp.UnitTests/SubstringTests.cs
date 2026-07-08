using NUnit.Framework;

namespace TestApp.UnitTests;

public class SubstringTests
{
    // TODO: finish the test
    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromMiddle()
    {
        // Arrange
        string wordToRemove = "fox";
        string input = "The quick brown fox jumps over the lazy dog";
        string expected = "The quick brown jumps over the lazy dog";

        // Act
        string result = Substring.RemoveOccurrences(wordToRemove, input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromStart()
    {
        // Arrange
        string wordToRemove = "The";
        string input = "The quick brown fox.";
        string expected = "quick brown fox.";

        // Act
        string result = Substring.RemoveOccurrences(wordToRemove, input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromEnd()
    {
        // Arrange
        string wordToRemove = "fox.";
        string input = "The quick brown fox.";
        string expected = "The quick brown";

        // Act
        string result = Substring.RemoveOccurrences(wordToRemove, input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesAllOccurrences()
    {
        // Arrange
        string wordToRemove = "fox";
        string input = "The quick brown fox jumps over the lazy dog. Cool fox";
        string expected = "The quick brown jumps over the lazy dog. Cool";

        // Act
        string result = Substring.RemoveOccurrences(wordToRemove, input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    //BOUNS TEST - NOT FO JUDGE

    [Test]
    public void Test_RemoveOccurrences_RemovesAllOccurrences_IgnoreCase()
    {
        // Arrange
        string wordToRemove = "THE";
        string input = "The quick brown fox jumps over the lazy dog. Cool fox";
        string expected = "quick brown fox jumps over lazy dog. Cool fox";

        // Act
        string result = Substring.RemoveOccurrences(wordToRemove, input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
