// See https://aka.ms/new-console-template for more information

using A04BarsRace;
using System.Globalization;

Team[] teams = {
    new Team("Atlanta Reign"), 
    new Team("Boston Uprising"),
    new Team("Chengdu Hunters"),
    new Team("Dallas Fuel"),
    new Team("Florida Mayhem"),
    new Team("Guangzhou Charge"),
    new Team("Hangzhou Spark"),
    new Team("Houston Outlaws"),
    new Team("London Spitfire"),
    new Team("Los Angeles Gladiators"),
    new Team("Los Angeles Valiant"),
    new Team("New York Excelsior"),
    new Team("Paris Eternal"),
    new Team("Philadelphia Fusion"),
    new Team("San Francisco Shock"),
    new Team("Seoul Dynasty"),
    new Team("Shanghai Dragons"),
    new Team("Toronto Defiant"),
    new Team("Vancouver Titans"),
    new Team("Washington Justice")
};

Console.CursorTop = teams.Length + 10;
foreach (Team team in teams) {
    team.PrintKillsArray();
}


Graph graph = new Graph(teams);

for (int j = 0; j < 6; j++)
{
    graph.Start(j);
}


// Footer
Console.CursorTop = 22;
Console.ForegroundColor = ConsoleColor.DarkGray;