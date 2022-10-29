using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A04BarsRace
{
    /// <summary>
    /// Contains all of the bars in the bar race.
    /// </summary>
    public class Graph
    {
        /// <summary>
        /// Displays the bar graphs
        /// </summary>
        public void Start()
        {
            Console.WriteLine("\n\tKilla-delphia Fusion: DPS Eliminations in OWL 2022");
            Bar bar1 = new Bar(8, 3, 21, ConsoleColor.Red);
            bar1.Paint();
        }
    }
}
