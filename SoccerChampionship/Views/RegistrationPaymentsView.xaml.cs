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
    public partial class RegistrationPaymentsView : PageBase
    {
        public RegistrationPaymentsView()
        {
            
            InitializeComponent();
            Context.Load(Context.GetRegistrationPaymentsQuery());
            LoadOperation tournamentLoad = Context.Load(Context.GetTournamentsQuery());
            Context.Load(Context.GetTeamsQuery());

            Teams = Context.Teams;
            Tournament = Context.Tournaments;

            tournamentLoad.Completed += new EventHandler(tournamentLoad_Completed);

            cboTournaments.ItemsSource = Tournament;
            cboTournaments.DisplayMemberPath = "Name";
            cboTournaments.SelectedValuePath = "Id";
            

            
            RegistrationPayment = Context.RegistrationPayments;
            GV.PreparedCellForEdit += new EventHandler<Telerik.Windows.Controls.GridViewPreparingCellForEditEventArgs>(GV_PreparedCellForEdit);
            GV.CellEditEnded += new EventHandler<Telerik.Windows.Controls.GridViewCellEditEndedEventArgs>(GV_CellEditEnded);
            GV.ItemsSource = RegistrationPayment;
            GV.CellValidating += new EventHandler<GridViewCellValidatingEventArgs>(GV_CellValidating);
                       
        }

        void tournamentLoad_Completed(object sender, EventArgs e)
        {
            cboTournaments.SelectedItem = Tournament.FirstOrDefault();
        }

        public EntitySet<Web.Team> Teams { get; set; }        

        public RegistrationPayment SelectedRegistrationPayment { get; set; }

        public EntitySet<Tournament> Tournament { get; set; }
        public EntitySet<RegistrationPayment> RegistrationPayment { get; set; }
        

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
                RegistrationPayment t = (RegistrationPayment)b.Tag;

                if (Context.RegistrationPayments.Contains(t))
                {
                    Context.RegistrationPayments.Remove(t);
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
            foreach (RegistrationPayment p in Context.RegistrationPayments.Where(x => x.ID == 0))
            {
                if (!Context.RegistrationPayments.Contains(p))
                    Context.RegistrationPayments.Add(p);
            }

            Context.SubmitChanges();
        }

        private void GV_AddingNewDataItem(object sender, Telerik.Windows.Controls.GridView.GridViewAddingNewEventArgs e)
        {
            e.Cancel = true;
            
            RegistrationPayment registrationPayment = new RegistrationPayment() { ID = 0, PaidDate = DateTime.Now, TournamentID = (int)this.cboTournaments.SelectedValue };
            RegistrationPayment.Add(registrationPayment);

            GV.ItemsSource = RegistrationPayment.Where(x => x.TournamentID == (cboTournaments.SelectedItem as Tournament).ID); 

            GV.CurrentCellInfo = new GridViewCellInfo(GV.Items[GV.Items.ItemCount - 1], GV.Columns[0]);
            GV.Focus();
            GV.BeginEdit();
        }

        void GV_CellEditEnded(object sender, GridViewCellEditEndedEventArgs e)
        {
            if (e.Cell.Column.UniqueName == "Tournament")
            {
                var q = (Web.Tournament)(e.EditingElement as RadComboBox).SelectedItem;
                (e.Cell.ParentRow.Item as RegistrationPayment).Tournament = q;
            }

            if (e.Cell.Column.UniqueName == "Team")
            {
                var q = (Web.Team)(e.EditingElement as RadComboBox).SelectedItem;
                (e.Cell.ParentRow.Item as RegistrationPayment).Team = q;
            }
        }

        void GV_CellValidating(object sender, GridViewCellValidatingEventArgs e)
        {
            if (e.Cell.Column.UniqueName == "Tournament")
            {
                e.IsValid = (e.EditingElement as RadComboBox).SelectedItem != null;
                e.ErrorMessage = "Debe seleccionar un Torneo.";
            }

            if (e.Cell.Column.UniqueName == "Team")
            {
                e.IsValid = (e.EditingElement as RadComboBox).SelectedItem != null;
                e.ErrorMessage = "Debe seleccionar un Equipo.";
            }

            if (e.Cell.Column.UniqueName != "Tournament" && e.Cell.Column.UniqueName != "Team")
            {
                e.IsValid = e.NewValue != null && !string.IsNullOrWhiteSpace(e.NewValue.ToString());
                e.ErrorMessage = "Falta completar el campo.";
            }


           
        }

        void GV_PreparedCellForEdit(object sender, Telerik.Windows.Controls.GridViewPreparingCellForEditEventArgs e)
        {
            if (e.Column.UniqueName == "Tournament")
            {
                RadComboBox combo = e.EditingElement as RadComboBox;
                combo.ItemsSource = Tournament;
            }

            if (e.Column.UniqueName == "Team")
            {
                RadComboBox combo = e.EditingElement as RadComboBox;
                combo.ItemsSource = Teams.Where(x => x.CategoryID == (cboTournaments.SelectedItem as Tournament).CategoryID && 
                                                                    !RegistrationPayment.Where(t => t.TournamentID == (cboTournaments.SelectedItem as Tournament).ID)
                                                                                       .Select(y => y.TeamID)
                                                                                       .Contains(x.ID));
            }
        }

        private void cboTournaments_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangedEventArgs e)
        {
            GV.ItemsSource = RegistrationPayment.Where(x => x.TournamentID == (cboTournaments.SelectedItem as Tournament).ID);
            GV.Rebind();
        }
    }
}
