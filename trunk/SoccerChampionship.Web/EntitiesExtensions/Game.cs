using System;
using System.Collections.Generic;
using System.Linq;

namespace SoccerChampionship.Web
{
    public partial class Game
    {
        public string DisplayStartTime
        {
            get
            {
                return StartTime.ToString("HH:mm");
            }
        }
    }

    public partial class GameDay
    {
        public string DisplayGameDate
        {
            get
            {
                return GameDate.ToString("dd-MMM-yyyy");
            }
        }
    }
}