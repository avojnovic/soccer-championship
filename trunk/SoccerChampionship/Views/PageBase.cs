using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using SoccerChampionship.Web.Services;

namespace SoccerChampionship.Views
{
    public abstract class PageBase : Page
    {
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

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            if (Context.HasChanges)
            {
                var res = MessageBox.Show("Hay cambios sin guardar ¿Desea salir sin guardar?", "Advertencia", MessageBoxButton.OKCancel);

                if (res == MessageBoxResult.OK)
                {
                    return;
                }
                else if (res == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }

            }
        }
    }
}
