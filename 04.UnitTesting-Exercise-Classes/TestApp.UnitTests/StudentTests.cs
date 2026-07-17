using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class StudentTests
{
    private Student _student;

    [SetUp]
    public void SetUp()
    {
        _student = new();
    }

    // TODO: finish test
    [Test]
    public void Test_AddAndGetByCity_ReturnsStudentsInCity_WhenCityExists()
    {
        // Arrange
        string[] students = { "John Doe 25 Sofia", "Jane Smith 22 Varna", "Alice Johnson 20 Sofia", "Pesho Ivanov 20 Plovdiv" };
        string expected = $"John Doe is 25 years old.{Environment.NewLine}Alice Johnson is 20 years old.";
        string wantedTown = "Sofia";

        // Act
        string result = _student.AddAndGetByCity(students, wantedTown);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndGetByCity_ReturnsEmptyString_WhenCityDoesNotExist()
    {
        // Arrange
        string[] students = { "John Doe 25 Sofia", "Jane Smith 22 Varna", "Alice Johnson 20 Sofia", "Pesho Ivanov 20 Plovdiv" };
        string wantedTown = "Burgas";

        // Act
        string result = _student.AddAndGetByCity(students, wantedTown);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_AddAndGetByCity_ReturnsEmptyString_WhenNoStudentsGiven()
    {
        // Arrange
        string[] students = Array.Empty<string>();
        string wantedTown = "Burgas";

        // Act
        string result = _student.AddAndGetByCity(students, wantedTown);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // BOUS TEST - NOT FOR JUDGE
    [Test]
    public void Test_AddAndGetByCity_ReturnsUpdatedStudentsInCity()
    {
        // Arrange
        string[] students = { "John Doe 25 Sofia", "Alice Johnson 20 Sofia", "John Doe 26 Sofia", "Alice Johnson 20 Varna" };
        string expected = $"John Doe is 26 years old.";
        string wantedTown = "Sofia";

        // Act
        string result = _student.AddAndGetByCity(students, wantedTown);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
