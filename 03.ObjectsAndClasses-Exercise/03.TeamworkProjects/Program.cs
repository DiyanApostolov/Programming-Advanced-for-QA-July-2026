
List<Team> league = new List<Team>();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] teamInfo = Console.ReadLine().Split("-");
    string creatorName = teamInfo[0];
    string teamName = teamInfo[1];

    // проверявам дали имам отбор с това име в лигата
    Team currentTeam = league.FirstOrDefault(t => t.Name == teamName);

    if (currentTeam != null) // ако има такъв отбор
    {
        Console.WriteLine($"Team {teamName} was already created!");
    }
    else if(league.Any(t => t.Creator == creatorName)) // ако вече има отбор с този creator
    {
        Console.WriteLine($"{creatorName} cannot create another team!");
    }
    else
    {
        // вдигам нова инстанция на класа Team
        currentTeam = new Team(teamName, creatorName);

        // добавям отбора в лигата
        league.Add(currentTeam);

        Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
    }
}

string input = Console.ReadLine();

while (input != "end of assignment")
{
    string[] addInfo = input.Split("->");
    string user = addInfo[0];
    string teamName = addInfo[1];

    if (!league.Any(t => t.Name == teamName)) // ако няма такъв отбор (false)
    {
        Console.WriteLine($"Team {teamName} does not exist!");
    }
    // проверявам дали user вече участва като member в някой отбор
    // ИЛИ проверявам дали user не е creator на някой от отборите
    else if (league.Any(t => t.Members.Contains(user) ||
        league.Any(t => t.Creator == user)))
    {
        Console.WriteLine($"Member {user} cannot join team {teamName}!");
    }
    else
    {
        // вадя отбора от лигата по референция
        Team teamFromLeague = league.First(t => t.Name == teamName);

        //добавям user в отбора
        teamFromLeague.Members.Add(user);
    }

    input = Console.ReadLine();
}
                            
foreach(Team team in league
                    .Where(t => t.Members.Count > 0) // дай ми само отборите, които имат members
                    .OrderByDescending(t => t.Members.Count) // подреди ги в низходящ ред по броя на members
                    .ThenBy(t => t.Name)) // след това по името в азбучен ред
{
    Console.WriteLine(team.Name);
    Console.WriteLine($"- {team.Creator}");

    foreach (var member in team.Members.OrderBy(m => m)) // сортирам members в азбучен ред
    {
        Console.WriteLine($"-- {member}");
    }
}

Console.WriteLine("Teams to disband:");

foreach (Team team in league
                        .Where(t => t.Members.Count == 0) // дай ми само отборите, които нямат members
                        .OrderBy(t => t.Name)) // сортирай ги по азбучен ред
{
    Console.WriteLine(team.Name);
}



class Team
{
    public Team(string name, string creator)
    {
        Name = name;
        Creator = creator;
        Members = new List<string>(); // new instance of List<string>
    }

    public string Name { get; set; }

    public string Creator { get; set; }

    public List<string> Members { get; set; } 
}
