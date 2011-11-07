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
using Telerik.Windows.Controls;
using SoccerChampionship.Web;
using System.ServiceModel.DomainServices.Client;

namespace SoccerChampionship.Views
{
    public partial class TournamentView : PageBase
    {
        public TournamentView()
        {
            
            InitializeComponent();
            Context.Load(Context.GetTournamentsQuery());
            Context.Load(Context.GetCategoriesQuery());

            Categories = Context.Categories;
            Tournament = Context.Tournaments;
            TournamentGV.ItemsSource = Tournament;

            TournamentGV.PreparedCellForEdit += new EventHandler<Telerik.Windows.Controls.GridViewPreparingCellForEditEventArgs>(GV_PreparedCellForEdit);
            TournamentGV.CellEditEnded += new EventHandler<GridViewCellEditEndedEventArgs>(GV_CellEditEnded);

            TournamentGV.CellValidating += new EventHandler<GridViewCellValidatingEventArgs>(GV_CellValidating);
                       
        }

        public EntitySet<Web.Category> Categories { get; set; }

        public Tournament SelectedTournament { get; set; }

        public EntitySet<Tournament> Tournament { get; set; }




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
                Tournament t = (Tournament)b.Tag;

                if (Context.Tournaments.Contains(t))
                {
                    Context.Tournaments.Remove(t);
                    Context.SubmitChanges();
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void Save()
        {
            foreach (Tournament p in Context.Tournaments.Where(x => x.ID == 0))
            {
                if (!Context.Tournaments.Contains(p))
                    Context.Tournaments.Add(p);
            }

            Context.SubmitChanges();
        }

        private void GV_AddingNewDataItem(object sender, Telerik.Windows.Controls.GridView.GridViewAddingNewEventArgs e)
        {

            Tournament tournament = new Tournament() { ID = 0, StartDate=DateTime.Now };
            tournament.StartDate = DateTime.Now;

            Tournament.Add(tournament);

            TournamentGV.ItemsSource = Tournament;

            TournamentGV.CurrentCellInfo = new GridViewCellInfo(TournamentGV.Items[TournamentGV.Items.ItemCount - 1], TournamentGV.Columns[0]);
            TournamentGV.Focus();
            TournamentGV.BeginEdit();


        }

        void GV_CellEditEnded(object sender, GridViewCellEditEndedEventArgs e)
        {
            if (e.Cell.Column.UniqueName == "Category")
            {
                var q = (Web.Category)(e.EditingElement as RadComboBox).SelectedItem;
                (e.Cell.ParentRow.Item as Tournament).Category = q;
            }
        }

        void GV_CellValidating(object sender, GridViewCellValidatingEventArgs e)
        {
            if (e.Cell.Column.UniqueName != "Category")
            {
                e.IsValid = e.NewValue != null && !string.IsNullOrWhiteSpace(e.NewValue.ToString());
                e.ErrorMessage = "Falta completar el campo.";
            }
            else
            {
                e.IsValid = (e.EditingElement as RadComboBox).SelectedItem != null;
                e.ErrorMessage = "Debe seleccionar una Categoria.";
            }

           
        }

        void GV_PreparedCellForEdit(object sender, Telerik.Windows.Controls.GridViewPreparingCellForEditEventArgs e)
        {
            if (e.Column.UniqueName == "Category")
            {
                RadComboBox combo = e.EditingElement as RadComboBox;
                combo.ItemsSource = Categories;
            }
        }
    }
}
