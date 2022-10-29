using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A04BarsRace
{
    /// <summary>
    /// Represents the number of elemeninations a player in the Overwatch league has obtained.
    /// </summary>
    public class Bar
    {
        public int StartLeft { get; }
        public int StartTop { get; }
        public int Length { get; }
        public ConsoleColor Color { get; }

        public Bar(int startLeft, int startTop, int length,
                ConsoleColor color = ConsoleColor.DarkGray) // optional argument
        {
            StartLeft = startLeft;
            StartTop = startTop;
            Length = length;
            Color = color;
        }

        /// <summary>
        /// Paints the bar to the console using the bars properties.
        /// </summary>
        public void Paint()
        {
            Console.SetCursorPosition(StartLeft, StartTop);
            Console.Write("Carpe\t");

            ConsoleColor originalBackground = Console.BackgroundColor;
            Console.BackgroundColor = Color;
            Console.Write(new string(' ', Length));

            Console.BackgroundColor = originalBackground;
            Console.WriteLine("    21");
        }
    }
}
