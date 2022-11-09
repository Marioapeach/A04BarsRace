using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace A04BarsRace
{
    /// <summary>
    /// Represents the number of eliminations a player in the Overwatch league has obtained.
    /// </summary>
    public class Bar : IComparable<Bar>
    {
        public int StartLeft { get; }
        private int CurrentKills { get; set; }
        public int TargetNumberOfKills { get; set; }
        public int KillsPerUpdate { get; set; }
        private Team Team { get; set; }

        public Bar(int startLeft, int length, Team team)
        {
            Team = team;
            StartLeft = startLeft;
            CurrentKills = length;
        }

        /// <summary>
        /// Paints the bar to the console using the bars properties.
        /// </summary>
        public void Paint(int currentTop)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor originalForground = Console.ForegroundColor;

            // Clear Current Line
            Console.SetCursorPosition(StartLeft, currentTop);
            Console.Write(new string(' ', Console.WindowWidth));

            // Paint Name
            Console.BackgroundColor = Team.GetBarColor();
            Console.ForegroundColor = Team.GetTextColor();
            Console.Write($"{Team.Name.PadRight(22)}\t");

            // Paint Bar
            Console.BackgroundColor = Team.GetBarColor();
            Console.Write(new string(' ', CurrentKills / 180));

            // Add Buffer
            Console.BackgroundColor = originalBackground;
            Console.Write("    ");

            // Paint Number Kills
            Console.BackgroundColor = Team.GetBarColor();
            Console.ForegroundColor = Team.GetTextColor();
            Console.WriteLine($"{CurrentKills}".PadRight(6));

            Console.BackgroundColor = originalBackground;
            Console.ForegroundColor = originalForground;
        }

        /// <summary>
        /// Compare the number of kills of each bar/team.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Bar? other)
        {
            if (other == null)
            {
                return 1;
            }
            return this.CurrentKills.CompareTo(other.CurrentKills);
        }

        /// <summary>
        /// Adds the given int to the current number of kills, unless that would put it over the target number,
        /// then the current number of kills = the target number.
        /// </summary>
        /// <param name="newKills"></param>
        public void UpdateKills(int newKills)
        {
            
            if (CurrentKills + newKills >= TargetNumberOfKills)
            {
                CurrentKills = TargetNumberOfKills;
            } else
            {
                CurrentKills += newKills;
            }
            
            //CurrentKills = newKills;
        }

        /// <summary>
        /// Returns the current number of kills.
        /// </summary>
        /// <returns></returns>
        public int GetCurrentKills()
        {
            return CurrentKills;
        }

        /// <summary>
        /// Returns this Bar's team
        /// </summary>
        /// <returns></returns>
        public Team GetTeam()
        {
            return Team;
        }
    }
}
