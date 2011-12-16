using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoccerChampionship.Web
{
    public partial class Game
    {
        public string DisplayStartTime
        {
            get
            {
                return StartTime.ToString("HHmm");
            }
        }
    }
}