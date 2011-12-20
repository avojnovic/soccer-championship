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
using vw = SoccerChampionship.Views;
using SoccerChampionship.Web;

namespace SoccerChampionship.Views
{
    public partial class PlayerStaticsView : vw::PageBase
    {
        public PlayerStaticsView()
        {
            InitializeComponent();

            Context.Load(Context.GetPlayerStaticsQuery());
            Context.Load(Context.GetPlayersQuery());
            Context.Load(Context.GetTeamsQuery());
            Context.Load(Context.GetGamesQuery());
            LoadOperation tournamentLoad = Context.Load(Context.GetTournamentsQuery());
            tournamentLoad.Completed += new EventHandler(tournamentLoad_Completed);

            cboTournaments.ItemsSource = Context.Tournaments;
        }

        void tournamentLoad_Completed(object sender, EventArgs e)
        {
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
            LoadOperation teamsLoad = Context.Load(Context.GetTeamsQuery());
            teamsLoad.Completed += new EventHandler(teamsLoad_Completed);
        }

        void teamsLoad_Completed(object sender, EventArgs e)
        {
            cboTournaments.SelectedItem = Context.Tournaments.FirstOrDefault();
        }

        // Executes when the user navigates to this page.
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

        private void cboGames_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cboGames.SelectedItem != null)
            {
                cboTeam.ItemsSource = Context.Teams.Where(x => x.ID == (cboGames.SelectedItem as Game).Team1ID || x.ID == (cboGames.SelectedItem as Game).Team2ID);
            }
        }

        private void cboTeam_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cboTeam.SelectedValue != null)
            {
                var players = Context.Players.Where(x => x.TeamID == (int)cboTeam.SelectedValue).ToList();

                //var r=  from st in Context.PlayerStatics
                        
                //        join pl in Context.Players on st.PlayerID equals pl.ID
                //        join tm in Context.Teams on pl.TeamID equals tm.ID
                //        join gd in Context.GameDays on st.GameDayID equals gd.ID
                //        join tr in Context.Tournaments on gd.TournamentID equals tr.ID
                //        join ga in Context.Games on gd.ID equals ga.GameDayID
                //        where ga.GameDayID==(int)cboGameDays.SelectedValue && ga.ID==(int)cboGames.SelectedValue && (ga.Team1ID==(int)cboTeam.SelectedValue || ga.Team2ID==(int)cboTeam.SelectedValue)
                //            select st;

                        
                List<PlayerStatic> statics = new List<PlayerStatic>();
                players.ForEach(x =>
                    {
                        //if(!r.Select(p=>p.PlayerID).Contains(x.ID))
                        //{
                        if (!Context.PlayerStatics.Where(p => p.GameDayID == (int)cboGameDays.SelectedValue)
                                                        .Select(p => p.PlayerID)
                                                        .Contains(x.ID))
                        {

                            Context.PlayerStatics.Add(new PlayerStatic { PlayerID = x.ID, Player = Context.Players.SingleOrDefault(y => y.ID == x.ID), GameDayID = (int)cboGameDays.SelectedValue });
                        }
                    });

                GV.ItemsSource =  from st in Context.PlayerStatics
                                  join pl in Context.Players on st.PlayerID equals pl.ID
                                  where st.GameDayID == (int)cboGameDays.SelectedValue && pl.TeamID == (int)cboTeam.SelectedValue
                                 select st;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {       
            Context.SubmitChanges();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Context.RejectChanges();
        }

    }
}
