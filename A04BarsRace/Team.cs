using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace A04BarsRace
{   
    /// <summary>
    /// Represents information on the team
    /// </summary>
    public class Team
    {   
        public Team(string name)
        {
            Name = name;
            SetColors(name);
            SetKillsArray(name);
        }

        string Name { get; }
        ConsoleColor BarColor { get; set; }
        ConsoleColor TextColor { get; set; }
        int[] KillsPerMonth { get; set; }

        /// <summary>
        /// Sums this teams kill totals into an array
        /// over 5 months of data
        /// </summary>
        /// <param name="name">of the OWL team</param>
        private void SetKillsArray(string name){
            String file = "resources//OWLStatsModified.csv";
            KillsPerMonth = new int[6];
            int totalKills = 0;

            for (int i = 5; i < 11; i++)
            {
                using (TextFieldParser csvParser = new TextFieldParser(file)){
                    csvParser.SetDelimiters(new string[] { "," });
                    while (!csvParser.EndOfData){
                        string[] fields = csvParser.ReadFields(); // Read current line fields, pointer moves to the next line.
                        string currentMonth = fields[0].Substring(5, 2);
                        //if team is this team and date is the month
                        if ((fields[6].CompareTo(name) == 0) && (String.Format("{0:00}", i).CompareTo(currentMonth)) == 0){
                            totalKills += Convert.ToInt32(fields[9]); //add to monthly kill total
                        }
                    }
                    KillsPerMonth[i - 5] = totalKills; //kill total is updated at this index
                }
            }
        }
        public void PrintKillsArray() {
            int month = 5;
            Console.ForegroundColor = BarColor;
            Console.WriteLine("{0}'s monthly elims in 2022:", Name);
            foreach (int kill in KillsPerMonth) {
                Console.Write("Month {0:00} Kills: {1}\n", (month++), kill);
            }
            Console.WriteLine();
            Console.ResetColor();
        }
        /// <summary>
        /// Sets the teams colors appropratly base on the teams name.
        /// Colors from: https://overwatchleague.com/en-us/teams
        /// </summary>
        /// <param name="name"> of the team</param>
        private void SetColors(string name) {
            switch (name.ToUpper()) {
                case "ATLANTA REIGN":
                    BarColor = ConsoleColor.DarkRed;
                    TextColor = ConsoleColor.Gray;
                    break;
                case "BOSTON UPRISING":
                    BarColor = ConsoleColor.Blue;
                    TextColor = ConsoleColor.White;
                    break;
                case "CHENGDU HUNTERS":
                    BarColor = ConsoleColor.Yellow;
                    TextColor = ConsoleColor.DarkGray;
                    break;
                case "DALLAS FUEL":
                    BarColor = ConsoleColor.DarkBlue;
                    TextColor = ConsoleColor.White;
                    break;
                case "FLORIDA MAYHEM":
                    BarColor = ConsoleColor.DarkMagenta;
                    TextColor = ConsoleColor.Black;
                    break;
                case "GUANGZHOU CHARGE":
                    BarColor = ConsoleColor.DarkBlue;
                    TextColor = ConsoleColor.Cyan;
                    break;
                case "HANGZHOU SPARK":
                    BarColor = ConsoleColor.Magenta;
                    TextColor = ConsoleColor.White;
                    break;
                case "HOUSTON OUTLAWS":
                    BarColor = ConsoleColor.Green;
                    TextColor = ConsoleColor.Black;
                    break;

                case "LONDON SPITFIRE":
                    BarColor = ConsoleColor.DarkBlue;
                    TextColor = ConsoleColor.Yellow;
                    break;
                case "LOS ANGELES GLADIATORS":
                    BarColor = ConsoleColor.Magenta;
                    TextColor = ConsoleColor.White;
                    break;
                case "LOS ANGELES VALIANT":
                    BarColor = ConsoleColor.Cyan;
                    TextColor = ConsoleColor.Yellow;
                    break;
                case "NEW YORK EXCELSIOR":
                    BarColor = ConsoleColor.Blue;
                    TextColor = ConsoleColor.White;
                    break;
                case "PARIS ETERNAL":
                    BarColor = ConsoleColor.DarkBlue;
                    TextColor = ConsoleColor.DarkRed;
                    break;
                case "PHILADELPHIA FUSION":
                    BarColor = ConsoleColor.Yellow;
                    TextColor = ConsoleColor.Black;
                    break;
                case "SAN FRANCISCO SHOCK":
                    BarColor = ConsoleColor.Gray;
                    TextColor = ConsoleColor.Black;
                    break;
                case "SEOUL DYNASTY":
                    BarColor = ConsoleColor.DarkYellow;
                    TextColor = ConsoleColor.Black;
                    break;
                case "TORONTO DEFIANT":
                    BarColor = ConsoleColor.DarkGray;
                    TextColor = ConsoleColor.White;
                    break;
                case "VANCOUVER TITANS":
                    BarColor = ConsoleColor.DarkBlue;
                    TextColor = ConsoleColor.DarkGreen;
                    break;
                default: Console.Error.WriteLine("No such team found. Check your spelling and try again!");
                    break;
            }
        }
    }
}
