using NUnit.Framework;

using System;
using System.Text;

namespace TestApp.UnitTests;

public class ArticleTests
{
    private Article _article;

    [SetUp]
    public void SetUp()
    {
        _article = new Article();
    }

    // TODO: finish test
    [Test]
    public void Test_AddArticles_ReturnsArticleWithCorrectData()
    {
        // Arrange
        //"{title} {content} {author}"
        string[] input = { "Article1 Content1 Author1", "Article2 Content2 Author2", "Article3 Content3 Author3" };

        Article expected = new Article();

        expected.ArticleList.Add(new Article
        {
            Title = "Article1",
            Content = "Content1",
            Author = "Author1"
        });

        expected.ArticleList.Add(new Article
        {
            Title = "Article2",
            Content = "Content2",
            Author = "Author2"
        });

        expected.ArticleList.Add(new Article
        {
            Title = "Article3",
            Content = "Content3",
            Author = "Author3"
        });

        // Act
        Article result = _article.AddArticles(input);

        // Assert
        Assert.That(result.ArticleList, Has.Count.EqualTo(3));

        for (int i = 0; i < 3; i++)
        {
            Assert.That(result.ArticleList[i].Title, Is.EqualTo(expected.ArticleList[i].Title));
            Assert.That(result.ArticleList[i].Content, Is.EqualTo(expected.ArticleList[i].Content));
            Assert.That(result.ArticleList[i].Author, Is.EqualTo(expected.ArticleList[i].Author));
        }
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByTitle()
    {
        // Arrange
        string printCriteria = "title";

        Article input = new Article();

        input.ArticleList.Add(new Article
        {
            Title = "B article",
            Content = "B content",
            Author = "B author"
        });

        input.ArticleList.Add(new Article
        {
            Title = "C article",
            Content = "C content",
            Author = "C author"
        });

        input.ArticleList.Add(new Article
        {
            Title = "A article",
            Content = "A content",
            Author = "A author"
        });

        StringBuilder expected = new StringBuilder();
        expected.AppendLine("A article - A content: A author");
        expected.AppendLine("B article - B content: B author");
        expected.AppendLine("C article - C content: C author");

        // Act
        string result = _article.GetArticleList(input, printCriteria);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString().Trim()));
    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
    {
        // Arrange
        string printCriteria = "invalid criteria";

        Article input = new Article();

        input.ArticleList.Add(new Article
        {
            Title = "B article",
            Content = "B content",
            Author = "B author"
        });

        input.ArticleList.Add(new Article
        {
            Title = "C article",
            Content = "C content",
            Author = "C author"
        });

        input.ArticleList.Add(new Article
        {
            Title = "A article",
            Content = "A content",
            Author = "A author"
        });

        // Act
        string result = _article.GetArticleList(input, printCriteria);

        // Assert
        Assert.That(result, Is.Empty);
    }
}
