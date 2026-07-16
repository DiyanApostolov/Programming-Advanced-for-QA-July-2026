
string[] articleInfo = Console.ReadLine().Split(", ");

string title = articleInfo[0];
string content = articleInfo[1];
string author = articleInfo[2];

Article article = new Article(title, content, author);

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] cmdArg = Console.ReadLine().Split(": ");
    string command = cmdArg[0];
    string token = cmdArg[1];

    if (command == "Edit")
    {
        article.Edit(token);
    }
    else if (command == "ChangeAuthor")
    {
        article.ChangeAuthor(token);
    }
    else if (command == "Rename")
    {
        article.Rename(token);
    }
}

Console.WriteLine(article.ToString());

class Article
{
    public Article(string title, string content, string author)
    {
        Title = title;
        Content = content;
        Author = author;
    }

    public string Title { get; private set; }

    public string Content { get; private set; }

    public string Author { get; private set; }

    public void Edit(string newContent)
    {
        Content = newContent;
    }

    public void ChangeAuthor(string newAuthor)
    {
        Author = newAuthor;
    }

    public void Rename(string newTitle)
    {
        Title = newTitle;
    }

    public override string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }

}
