namespace SoccerChampionship
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using SoccerChampionship.LoginUI;
using SoccerChampionship.Web.Services;
    using System.ServiceModel.DomainServices.Client;
    using SoccerChampionship.Web;

    /// <summary>
    /// <see cref="UserControl"/> class providing the main UI for the application.
    /// </summary>
    public partial class MainPage : UserControl
    {
        private SoccerModelContext context = new SoccerModelContext();

        /// <summary>
        /// Creates a new <see cref="MainPage"/> instance.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            this.loginContainer.Child = new LoginStatus();

            LoadOperation<Category> categories = this.context.Load(this.context.GetCategoryQuery());
            categories.Completed += new System.EventHandler(categories_Completed);
            //SoccerModelService context = new SoccerModelContext();
            //var categories = context.GetCategoryQuery();
            
        }

        void categories_Completed(object sender, System.EventArgs e)
        {
            var categories = (sender as LoadOperation<Category>).AllEntities;
        }

        /// <summary>
        /// After the Frame navigates, ensure the <see cref="HyperlinkButton"/> representing the current page is selected
        /// </summary>
        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            foreach (UIElement child in LinksStackPanel.Children)
            {
                HyperlinkButton hb = child as HyperlinkButton;
                if (hb != null && hb.NavigateUri != null)
                {
                    if (hb.NavigateUri.ToString().Equals(e.Uri.ToString()))
                    {
                        VisualStateManager.GoToState(hb, "ActiveLink", true);
                    }
                    else
                    {
                        VisualStateManager.GoToState(hb, "InactiveLink", true);
                    }
                }
            }
        }

        /// <summary>
        /// If an error occurs during navigation, show an error window
        /// </summary>
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            e.Handled = true;
            ErrorWindow.CreateNew(e.Exception);
        }
    }
}