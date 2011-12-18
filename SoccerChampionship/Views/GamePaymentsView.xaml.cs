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
    public partial class GamePaymentsView : vw::PageBase
    {
        public GamePaymentsView()
        {
            InitializeComponent();

            Context.Load(Context.GetGamePaymentsQuery());
            Context.Load(Context.GetTeamsQuery());
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
            cboTournaments.SelectedItem = Context.Tournaments.FirstOrDefault();
        }

        // Se ejecuta cuando el usuario navega a esta página.
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
            if (cboGames.SelectedValue != null)
            {

                var teams = Context.Teams.Where(x => x.ID == (cboGames.SelectedItem as Game).Team1ID || x.ID == (cboGames.SelectedItem as Game).Team2ID).ToList();

                List<GamePayment> gamePayments = new List<GamePayment>();
                teams.ForEach(x =>
                {
                    if (!Context.GamePayments.Select(p => p.TeamID).Contains(x.ID))
                    {
                        Context.GamePayments.Add(new GamePayment { TeamID = x.ID, GameID = (int)cboGames.SelectedValue, PaidDate=DateTime.Now });
                    }
                });

                GV.ItemsSource = from gp in Context.GamePayments
                                 where gp.GameID == (int)cboGames.SelectedValue
                                 select gp;
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
