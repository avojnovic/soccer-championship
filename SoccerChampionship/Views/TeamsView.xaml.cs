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
    public partial class TeamsView : PageBase
    {              

        public TeamsView()
        {
            InitializeComponent();
            
            Context.Load(Context.GetTeamsQuery());
            Context.Load(Context.GetCategoriesQuery());

            Categories = Context.Categories;
            Teams = Context.Teams;
            TeamsGV.ItemsSource = Teams;

            TeamsGV.PreparedCellForEdit += new EventHandler<Telerik.Windows.Controls.GridViewPreparingCellForEditEventArgs>(TeamsGV_PreparedCellForEdit);
            TeamsGV.CellEditEnded += new EventHandler<GridViewCellEditEndedEventArgs>(TeamsGV_CellEditEnded);

            TeamsGV.CellValidating += new EventHandler<GridViewCellValidatingEventArgs>(TeamsGV_CellValidating);
                       
        }



        public EntitySet<Web.Category> Categories { get; set; }

        public Team SelectedTeam { get; set; }

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
                Team t = (Team)b.Tag;

                Context.Teams.Remove(t);
                Context.SubmitChanges();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void Save()
        {
            foreach (Team p in Context.Teams.Where(x => x.ID == 0))
            {
                if( !Context.Teams.Contains(p))
                    Context.Teams.Add(p);
            }

            Context.SubmitChanges();
        }

        private void TeamsGV_AddingNewDataItem(object sender, Telerik.Windows.Controls.GridView.GridViewAddingNewEventArgs e)
        {
            Team team = new Team();
            Teams.Add(team);

            TeamsGV.ItemsSource = Teams;

            TeamsGV.CurrentCellInfo = new GridViewCellInfo(TeamsGV.Items[TeamsGV.Items.ItemCount - 1], TeamsGV.Columns[0]);
            TeamsGV.Focus();
            TeamsGV.BeginEdit();


        }

        void TeamsGV_CellEditEnded(object sender, GridViewCellEditEndedEventArgs e)
        {
            if (e.Cell.Column.UniqueName == "Category")
            {
                var q = (Web.Category)(e.EditingElement as RadComboBox).SelectedItem;
                (e.Cell.ParentRow.Item as Team).Category = q;
            }
        }

        void TeamsGV_CellValidating(object sender, GridViewCellValidatingEventArgs e)
        {
            if (e.Cell.Column.UniqueName == "Name")
            {
                e.IsValid = e.NewValue != null && !string.IsNullOrWhiteSpace(e.NewValue.ToString());
                e.ErrorMessage = "Sin nombre no, papa!";
            }

            if (e.Cell.Column.UniqueName == "Category")
            {
                e.IsValid = (e.EditingElement as RadComboBox).SelectedItem != null;
                e.ErrorMessage = "Y la categoria mostro??!";
            }
        }

        void TeamsGV_PreparedCellForEdit(object sender, Telerik.Windows.Controls.GridViewPreparingCellForEditEventArgs e)
        {
            if (e.Column.UniqueName == "Category")
            {
                RadComboBox combo = e.EditingElement as RadComboBox;
                combo.ItemsSource = Categories;
            }
        }

    }
}
