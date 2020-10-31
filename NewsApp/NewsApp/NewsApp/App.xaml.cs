using NewsApp.DependencyInjection;
using NewsApp.Views;
using Xamarin.Forms;

namespace NewsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Bootstrapper.Initialize();
            MainPage = new HeadlinesView();
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
