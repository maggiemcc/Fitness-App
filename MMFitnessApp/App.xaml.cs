using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

/// <summary>
/// Create navigation page
/// </summary>
namespace MMFitnessApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Turn into a navigation page instead of a single page
            MainPage = new NavigationPage(new MainPage());
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
