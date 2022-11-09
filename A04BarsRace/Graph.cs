﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A04BarsRace
{
    /// <summary>
    /// Contains all of the bars in the bar race!
    /// </summary>
    public class Graph
    {
        private Team[] Teams { get; }
        private Bar[] Bars { get; }
        private int[] NewKills { get; set; }
        private int[] KillsPerUpdate { get; set; }


        public Graph (Team[] teams)
        {
            Teams = teams;
            Bars = CreateBarsArray();
            NewKills = new int[Bars.Length];
            KillsPerUpdate = new int[Bars.Length];
        }

        /// <summary>
        /// Displays the bar graphs
        /// </summary>
        public void Start(int currentMonth)
        {
            for (int i = 0; i < Bars.Length; i++)
            {
                Bars[i].Paint(Bars.Length - i);
                NewKills[i] = Teams[i].GetKillsPerMonth()[currentMonth];
                Bars[i].TargetNumberOfKills = NewKills[i];
                // KillsPerUpdate[i] = (NewKills[i] - Bars[i].GetCurrentKills()) / 50;
            }
            
            while (!MonthFinished())
            {
                foreach (Bar bar in Bars)
                {
                    bar.UpdateKills(bar.TargetNumberOfKills);
                }
                Array.Sort(Bars);
                int topPosition = Bars.Length;
                foreach (Bar bar in Bars)
                {
                    bar.Paint(topPosition--);
                }
                Array.Sort(Bars);
                Thread.Sleep(500);
            }
            
        }

        private bool MonthFinished()
        {
            bool IsFinsished = true;
            for(int i = 0; i < NewKills.Length; i++)
            {
                if (Bars[i].TargetNumberOfKills != Bars[i].GetCurrentKills())
                {
                    IsFinsished = false;
                } 
            }
            return IsFinsished;
        }

        private Bar[] CreateBarsArray()
        {
            Bar[] bars = new Bar[Teams.Length];
            for (int i = 0; i < Teams.Length; i++)
            {
                Team currentTeam = Teams[i];
                bars[i] = new Bar(8, 0, currentTeam);
            }
            return bars;
        }
    }
}
