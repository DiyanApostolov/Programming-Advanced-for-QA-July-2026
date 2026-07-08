using NUnit.Framework;

using System;
using System.Xml.Schema;

namespace TestApp.UnitTests;

public class TextFilterTests
{
    // TODO: finish the test
    [Test]
    public void Test_Filter_WhenNoBannedWords_ShouldReturnOriginalText()
    {
        // Arrange
        string[] bannedWords = new string[] {"bad", "cat", "wolf"};
        string input = "The quick brown fox jumps over the lazy dog";

        // Act
        string result = TextFilter.Filter(bannedWords, input);

        // Assert
        Assert.That(result, Is.EqualTo(input));
    }

    [Test]
    public void Test_Filter_WhenBannedWordExists_ShouldReplaceBannedWordWithAsterisks()
    {
        // Arrange
        string[] bannedWords = new string[] { "brown", "dog" };
        string input = "The quick brown fox jumps over the lazy dog";
        string expected = "The quick ***** fox jumps over the lazy ***";

        // Act
        string result = TextFilter.Filter(bannedWords, input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsAreEmpty_ShouldReturnOriginalText()
    {
        // Arrange
        string[] bannedWords = new string[0];
        string input = "The quick brown fox jumps over the lazy dog";

        // Act
        string result = TextFilter.Filter(bannedWords, input);

        // Assert
        Assert.That(result, Is.EqualTo(input));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsContainWhitespace_ShouldReplaceBannedWord()
    {
        // Arrange
        string[] bannedWords = new string[] { "brown fox", "lazy dog" };
        string input = "The quick brown fox jumps over the lazy dog";
        string expected = "The quick ********* jumps over the ********";

        // Act
        string result = TextFilter.Filter(bannedWords, input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // BONUS TEST

    [Test]
    public void Test_Filter_WhenBannedWordExistsMultipleTimes_ShouldReplaceBannedWordWithAsterisks()
    {
        // Arrange
        string[] bannedWords = new string[] { "brown" };
        string input = "The quick brown fox jumps over the brown dog";
        string expected = "The quick ***** fox jumps over the ***** dog";

        // Act
        string result = TextFilter.Filter(bannedWords, input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
