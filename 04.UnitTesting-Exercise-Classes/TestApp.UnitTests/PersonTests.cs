using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.UnitTests;

public class PersonTests
{
    private Person _person;

    [SetUp]
    public void SetUp()
    {
        _person = new Person();
    }

    // TODO: finish test
    [Test]
    public void Test_AddPeople_ReturnsListWithUniquePeople()
    {
        // Arrange
        string[] peopleData = { "Alice A001 25", "Bob B002 30", "Alice A001 35" };
        List<Person> expected = new List<Person>();

        expected.Add(new Person
        {
            Name = "Alice",
            Id = "A001",
            Age = 35
        });

        expected.Add(new Person
        {
            Name = "Bob",
            Id = "B002",
            Age = 30
        });


        // Act
        List<Person> resultPeopleList = _person.AddPeople(peopleData);

        // Assert
        Assert.That(resultPeopleList, Has.Count.EqualTo(2));

        for (int i = 0; i < resultPeopleList.Count; i++)
        {
            Assert.That(resultPeopleList[i].Name, Is.EqualTo(expected[i].Name));
            Assert.That(resultPeopleList[i].Id, Is.EqualTo(expected[i].Id));
            Assert.That(resultPeopleList[i].Age, Is.EqualTo(expected[i].Age));
        }
    }

    [Test]
    public void Test_GetByAgeAscending_SortsPeopleByAge()
    {
        // Arrange
        List<Person> input = new List<Person>();

        input.Add(new Person
        {
            Name = "Alice",
            Id = "A001",
            Age = 35
        });

        input.Add(new Person
        {
            Name = "Michael",
            Id = "M003",
            Age = 18
        });

        input.Add(new Person
        {
            Name = "Bob",
            Id = "B002",
            Age = 30
        });

        input.Add(new Person
        {
            Name = "Dido",
            Id = "D004",
            Age = 32
        });

        StringBuilder expected = new StringBuilder();
        expected.AppendLine($"Michael with ID: M003 is 18 years old.");
        expected.AppendLine($"Bob with ID: B002 is 30 years old.");
        expected.AppendLine($"Dido with ID: D004 is 32 years old.");
        expected.AppendLine($"Alice with ID: A001 is 35 years old.");

        // Act
        string result = _person.GetByAgeAscending( input );

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString().Trim()));
    }
}
