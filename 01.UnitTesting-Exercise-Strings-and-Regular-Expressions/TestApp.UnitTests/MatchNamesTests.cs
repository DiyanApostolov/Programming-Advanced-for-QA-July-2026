using NUnit.Framework;

namespace TestApp.UnitTests;

public class MatchNamesTests
{
    [Test]
    public void Test_Match_ValidNames_ReturnsMatchedNames()
    {
        // Arrange
        string text = "John Smith and Alice Johnson are brothers.";
        string expected = "John Smith Alice Johnson";

        // Act
        string result = MatchNames.Match(text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Match_NoValidNames_ReturnsEmptyString()
    {
        // Arrange
        string text = "john Smith and ALICE Johnson are brothers.";

        // Act
        string result = MatchNames.Match(text);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Match_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string text = string.Empty;

        // Act
        string result = MatchNames.Match(text);

        // Assert
        Assert.That(result, Is.Empty);
    }
}
