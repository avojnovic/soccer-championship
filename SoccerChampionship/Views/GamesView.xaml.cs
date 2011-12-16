﻿using System;
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
using Telerik.Windows.Controls;

namespace SoccerChampionship.Views
{
    public partial class GamesView : PageBase
    {

        public GamesView()
        {
            InitializeComponent();

            Context.Load(Context.GetTeamsQuery());
            LoadOperation GameDayLoad = Context.Load(Context.GetGameDaysQuery());
            LoadOperation tournamentLoad = Context.Load(Context.GetTournamentsQuery());


            Tournaments = Context.Tournaments;
            GameDays = Context.GameDays;


            tournamentLoad.Completed += new EventHandler(tournamentLoad_Completed);

            cboTournaments.ItemsSource = Tournaments;
            cboTournaments.DisplayMemberPath = "Name";
            cboTournaments.SelectedValuePath = "Id";

            GameDayGV.ItemsSource = GameDays;
            GameDayGV.CellValidating += new EventHandler<Telerik.Windows.Controls.GridViewCellValidatingEventArgs>(GameDayGV_CellValidating);
        }


        public EntitySet<GameDay> GameDays { get; set; }

        public EntitySet<Tournament> Tournaments { get; set; }

        public GameDay EditingGameDay { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Context.RejectChanges();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("¿Esta seguro que desea eliminarlo?", "Advertencia", MessageBoxButton.OKCancel);

            if (res == MessageBoxResult.OK)
            {
                Button b = (Button)sender;
                GameDay t = (GameDay)b.Tag;

                if (Context.GameDays.Contains(t))
                {
                    Context.GameDays.Remove(t);
                    Context.SubmitChanges();
                }
            }
        }

        private void Save()
        {
            foreach (GameDay p in Context.GameDays)
            {
                if(p.ID == 0)
                {
                    if (!Context.GameDays.Contains(p))
                        Context.GameDays.Add(p);
                }

                foreach (Game g in p.Games.Where(x => x.ID == 0))
                {
                }
            }

            Context.SubmitChanges();
        }

        private void cboTournaments_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangedEventArgs e)
        {
            GameDayGV.ItemsSource = GameDays.Where(x => x.TournamentID == (cboTournaments.SelectedItem as Tournament).ID);
            GameDayGV.Rebind();
        }

        private void GameDayGV_AddingNewDataItem(object sender, Telerik.Windows.Controls.GridView.GridViewAddingNewEventArgs e)
        {
            e.Cancel = true;

            GameDay gameDay = new GameDay() { GameDate = DateTime.Today, TournamentID = (int)this.cboTournaments.SelectedValue };
            GameDays.Add(gameDay);

            GameDayGV.ItemsSource = GameDays.Where(x => x.TournamentID == (cboTournaments.SelectedItem as Tournament).ID);

            GameDayGV.CurrentCellInfo = new GridViewCellInfo(GameDayGV.Items[GameDayGV.Items.ItemCount - 1], GameDayGV.Columns[0]);
            GameDayGV.Focus();
            GameDayGV.BeginEdit();
        }

        void GameDayGV_CellValidating(object sender, Telerik.Windows.Controls.GridViewCellValidatingEventArgs e)
        {
            e.IsValid = e.NewValue != null && !string.IsNullOrWhiteSpace(e.NewValue.ToString());
            e.ErrorMessage = "Falta completar el campo.";
        }

        void tournamentLoad_Completed(object sender, EventArgs e)
        {
            cboTournaments.SelectedItem = Tournaments.FirstOrDefault();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void GameGV_AddingNewDataItem(object sender, Telerik.Windows.Controls.GridView.GridViewAddingNewEventArgs e)
        {
            e.Cancel = true;

            var GameGV = e.OwnerGridViewItemsControl as RadGridView;

            Game game = new Game() { StartTime = DateTime.Now, GameDayID = EditingGameDay.ID };
            EditingGameDay.Games.Add(game);
            
            GameGV.ItemsSource = EditingGameDay.Games;
            GameGV.CurrentCellInfo = new GridViewCellInfo(GameGV.Items[GameGV.Items.ItemCount - 1], GameGV.Columns[0]);
            GameGV.Focus();
            GameGV.BeginEdit();
        }
        
        private void GameDayGV_RowDetailsVisibilityChanged(object sender, Telerik.Windows.Controls.GridView.GridViewRowDetailsEventArgs e)
        {
            if (e.Visibility.HasValue && e.Visibility.Value == System.Windows.Visibility.Visible)
            {
                RadGridView gv = e.DetailsElement as RadGridView;

                EditingGameDay = e.Row.DataContext as GameDay;

                if (gv != null)
                {
                    gv.PreparingCellForEdit += new EventHandler<GridViewPreparingCellForEditEventArgs>(gv_PreparingCellForEdit);
                }
            }
        }

        void gv_PreparingCellForEdit(object sender, GridViewPreparingCellForEditEventArgs e)
        {
            if (e.Column.UniqueName == "Team2" || e.Column.UniqueName == "Team1")
            {
                (e.EditingElement as RadComboBox).ItemsSource = Context.Teams.Where(x=>  x.CategoryID==(cboTournaments.SelectedItem as Tournament).CategoryID);
            }
        }
    }
}
