using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class SongTests
{
    private Song _song;

    [SetUp]
    public void Setup()
    {
        this._song = new();
    }

    // TODO: finish test
    [Test]
    public void Test_AddAndListSongs_ReturnsAllSongs_WhenWantedListIsAll()
    {
        // Arrange
        string[] songs = { "Pop_Song1_3:30", "Rock_Song2_4:15", "Pop_Song3_3:00" };

        string expected = $"Song1{Environment.NewLine}" +
                          $"Song2{Environment.NewLine}" +
                          $"Song3";

        string wantedList = "all";

        // Act
        string result = _song.AddAndListSongs(songs, wantedList);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndListSongs_ReturnsFilteredSongs_WhenWantedListIsSpecific()
    {
        // Arrange
        string[] songs = { "Pop_Song1_3:30", "Rock_Song2_4:15", "Pop_Song3_3:00", "Rock_Song4_5:40", "Jazz_Song5_7:40", "Funk_Song6_3:50" };

        string expected = $"Song2{Environment.NewLine}" +
                          $"Song4";

        string wantedList = "Rock";

        // Act
        string result = _song.AddAndListSongs(songs, wantedList);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndListSongs_ReturnsEmptyString_WhenNoSongsMatchWantedList()
    {
        // Arrange
        string[] songs = { "Pop_Song1_3:30", "Rock_Song2_4:15", "Pop_Song3_3:00", "Rock_Song4_5:40", "Jazz_Song5_7:40", "Funk_Song6_3:50" };

        string wantedList = "R&B";

        // Act
        string result = _song.AddAndListSongs(songs, wantedList);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // BONUS TEST - NOT FOR JUDGE
    [Test]
    public void Test_AddAndListSongs_ReturnsEmptyString_WhenNoSongs()
    {
        // Arrange
        string[] songs = Array.Empty<string>();

        string wantedList = "R&B";

        // Act
        string result = _song.AddAndListSongs(songs, wantedList);

        // Assert
        Assert.That(result, Is.Empty);
    }
}
