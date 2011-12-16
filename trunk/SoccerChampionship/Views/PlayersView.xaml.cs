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
using SoccerChampionship.Web.Services;
using SoccerChampionship.Web;
using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;
using Telerik.Windows.Controls;

namespace SoccerChampionship.Views
{
    public partial class PlayersView : PageBase
    {

        public PlayersView()
        {
            InitializeComponent();

            Context.Load(Context.GetTeamsQuery());
            Context.Load(Context.GetPlayersQuery());

            Teams = Context.Teams;
            Players = Context.Players;            
            PlayersGV.ItemsSource = Players;

            PlayersGV.PreparedCellForEdit += new EventHandler<Telerik.Windows.Controls.GridViewPreparingCellForEditEventArgs>(PlayersGV_PreparedCellForEdit);
            PlayersGV.CellEditEnded += new EventHandler<GridViewCellEditEndedEventArgs>(PlayersGV_CellEditEnded);
            PlayersGV.CellValidating += new EventHandler<GridViewCellValidatingEventArgs>(PlayersGV_CellValidating);
        }
        

        public EntitySet<Player> Players { get; set; }

        public Player SelectedPlayers { get; set; }

        public EntitySet<Team> Teams { get; set; }




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
                Player p = (Player)b.Tag;

                if (Context.Players.Contains(p))
                {
                    Context.Players.Remove(p);
                    Context.SubmitChanges();
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (Player p in Context.Players.Where(x => x.ID == 0))
            {
                if (!Context.Players.Contains(p))
                    Context.Players.Add(p);
            }
            
            Context.SubmitChanges();
        }

        private void PlayersGV_AddingNewDataItem(object sender, Telerik.Windows.Controls.GridView.GridViewAddingNewEventArgs e)
        {
            e.Cancel = true;

            Player p = new Player() { ID = 0, Team = Teams.First() };
            Players.Add(p);

            PlayersGV.ItemsSource = Players;

            
            PlayersGV.CurrentCellInfo = new GridViewCellInfo(PlayersGV.Items[PlayersGV.Items.ItemCount-1], PlayersGV.Columns[0]);
            PlayersGV.Focus();  
            PlayersGV.BeginEdit();

                        
        }

        void PlayersGV_CellEditEnded(object sender, GridViewCellEditEndedEventArgs e)
        {
            if (e.Cell.Column.UniqueName == "Team")
            {
                var q = (Team)(e.EditingElement as RadComboBox).SelectedItem;
                (e.Cell.ParentRow.Item as Player).Team = q;
            }
        }

        void PlayersGV_CellValidating(object sender, GridViewCellValidatingEventArgs e)
        {
            if (e.Cell.Column.UniqueName != "Team")
            {
                e.IsValid = e.NewValue != null && !string.IsNullOrWhiteSpace(e.NewValue.ToString());
                e.ErrorMessage = "Falta completar el campo.";
            }
            else
            {
                e.IsValid = (e.EditingElement as RadComboBox).SelectedItem != null;
                e.ErrorMessage = "Debe seleccionar un Equipo.";
            }
                
        }

        void PlayersGV_PreparedCellForEdit(object sender, Telerik.Windows.Controls.GridViewPreparingCellForEditEventArgs e)
        {
            if (e.Column.UniqueName == "Team")
            {
                RadComboBox combo = e.EditingElement as RadComboBox;
                combo.ItemsSource = Teams;
            }
        }
    }
}
