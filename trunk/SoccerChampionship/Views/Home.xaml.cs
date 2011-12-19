using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.ServiceModel.DomainServices.Client;
using SoccerChampionship.Web;


namespace SoccerChampionship
{
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using SoccerChampionship.Web.Services;

    /// <summary>
    /// Home page for the application.
    /// </summary>
    public partial class Home : Page
    {
        /// <summary>
        /// Creates a new <see cref="Home"/> instance.
        /// </summary>
        public Home()
        {
            InitializeComponent();
            Context.Load(Context.GetPlayerStaticsQuery());
            Context.Load(Context.GetPlayersQuery());
            Context.Load(Context.GetTeamsQuery());
            LoadOperation tournamentLoad = Context.Load(Context.GetTournamentsQuery());
            tournamentLoad.Completed += new EventHandler(tournamentLoad_Completed);
            

            this.Title = ApplicationStrings.HomePageTitle;
        }

        private SoccerContext context;
        public virtual SoccerContext Context
        {
            get
            {
                if (context == null)
                    context = new SoccerContext();

                return context;
            }
            set
            {
                context = value;
            }

        }


        void tournamentLoad_Completed(object sender, EventArgs e)
        {
            cboTournaments.ItemsSource = Context.Tournaments;
            cboTournamentsRanking.ItemsSource = Context.Tournaments;
            LoadOperation gameDaysLoad = Context.Load(Context.GetGameDaysQuery());
            gameDaysLoad.Completed += new EventHandler(gameDaysLoad_Completed);
        }

        void gameDaysLoad_Completed(object sender, EventArgs e)
        {
             LoadOperation gameLoad = Context.Load(Context.GetGamesQuery());
             gameLoad.Completed += new EventHandler(gameLoad_Completed);
        }

        void gameLoad_Completed(object sender, EventArgs e)
        {
            cboTournaments.SelectedItem = Context.Tournaments.FirstOrDefault();
        }



        /// <summary>
        /// Executes when the user navigates to this page.
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        private void cboTournaments_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cboTournaments.SelectedValue != null)
            {
                cboGameDays.ItemsSource = Context.GameDays.Where(x => x.TournamentID == (int)cboTournaments.SelectedValue);
            }
        }

        private void cboGameDays_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cboGameDays.SelectedValue != null)
            {
                cboGames.ItemsSource = Context.Games.Where(x => x.GameDayID == (int)cboGameDays.SelectedValue);
            }
        }

        private void cboTournamentsRanking_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangedEventArgs e)
        {


            if (cboTournamentsRanking.SelectedItem != null)
            {


                var result =
                    from puntajes in
                    (

                           from p1 in
                               (
                               from i in
                                   (
                                       from st in Context.PlayerStatics
                                       join pl in Context.Players on st.PlayerID equals pl.ID
                                       join gd in Context.GameDays on st.GameDayID equals gd.ID
                                       join tr in Context.Tournaments on gd.TournamentID equals tr.ID
                                       join tm in Context.Teams on pl.TeamID equals tm.ID
                                       join ga in Context.Games on gd.ID equals ga.GameDayID
                                       where tr.ID == (int)cboTournamentsRanking.SelectedValue
                                       select new { Equipo = tm.Name, Goles = st.Goals, Partido = ga.GameDayID }

                                    )
                               group i by new { i.Equipo, i.Partido } into g
                               select new { Equipo = g.Key.Equipo, Partido = g.Key.Partido, Goles = g.Sum(go => go.Goles) }
                               )
                           from p2 in
                               (
                                   from i in
                                       (
                                           from st in Context.PlayerStatics
                                           join pl in Context.Players on st.PlayerID equals pl.ID
                                           join gd in Context.GameDays on st.GameDayID equals gd.ID
                                           join tr in Context.Tournaments on gd.TournamentID equals tr.ID
                                           join tm in Context.Teams on pl.TeamID equals tm.ID
                                           join ga in Context.Games on gd.ID equals ga.GameDayID
                                           where tr.ID == (int)cboTournamentsRanking.SelectedValue
                                           select new { Equipo = tm.Name, Goles = st.Goals, Partido = ga.GameDayID }

                                        )
                                   group i by new { i.Equipo, i.Partido } into g
                                   select new { Equipo = g.Key.Equipo, Partido = g.Key.Partido, Goles = g.Sum(go => go.Goles) }
                                   )
                           where p1.Partido == p2.Partido && p1.Equipo!=p2.Equipo
                           select new {Equipo=p1.Equipo,Puntos= 
                                                    (
                                                        p1.Goles>p2.Goles? 3:
                                                         p1.Goles<p2.Goles? 0:
                                                          p1.Goles==p2.Goles? 1:
                                                          0
                                                    )
                                            }
                   )
                   group puntajes by puntajes.Equipo into g
                    select new Result { Name = g.Key, Value = g.Sum(go => go.Puntos)};



                       ;


                List<Result> r = new List<Result>();
                foreach (Result item in result)
                {
                    r.Add(item);
                }
                GVRanking.ItemsSource = result;

            }
        }

        private void cboGames_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cboGames.SelectedItem != null)
            {

                var result =
                    from i in
                        (
                            from st in Context.PlayerStatics
                            join pl in Context.Players on st.PlayerID equals pl.ID
                            join gd in Context.GameDays on st.GameDayID equals gd.ID
                            join ga in Context.Games on  st.GameDayID equals ga.GameDayID
                            join tm in ( from t in Context.Teams where t.ID==((cboGames.SelectedItem)as Game).Team1ID || t.ID==((cboGames.SelectedItem)as Game).Team2ID select t)
                             on pl.TeamID equals tm.ID
                            where gd.ID == (int)cboGameDays.SelectedValue && ga.ID==(int)cboGames.SelectedValue
                            select new { Equipo = tm.Name, Jugador = pl.Name, Goles = st.Goals, Amarillas=st.YellowCards,Rojas=st.RedCard })
                    group i by i.Equipo into g
                    select new Result { Name = g.Key, Value = g.Sum(go => go.Goles), Value2 = g.Sum(go => go.Amarillas), Value3 = g.Sum(go => go.Rojas) };


                List<Result> r = new List<Result>();
                foreach (Result item in result)
                {
                    r.Add(item);
                }
                GV.ItemsSource = result;

            }
        }

        public class Result
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            private int value;

            public int Value
            {
                get { return this.value; }
                set { this.value = value; }
            }

            private int value2;


            public int Value2
            {
                get { return value2; }
                set { value2 = value; }
            }
            private int value3;

            public int Value3
            {
                get { return value3; }
                set { value3 = value; }
            }
        }


    }
}