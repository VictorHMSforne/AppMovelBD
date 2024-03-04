using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovelBD
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());//pesquisar dps o que é NavigationPage
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
