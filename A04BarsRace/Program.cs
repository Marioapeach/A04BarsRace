// See https://aka.ms/new-console-template for more information

using A04BarsRace;
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
    new Team("Toronto Defiant"),
    new Team("Vancouver Titans")
};

foreach (Team team in teams) {
    team.PrintKillsArray();
}
//Graph graph = new Graph();
//graph.Start();