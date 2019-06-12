using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Winsibo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            var createConnectionToSensibo = new sensibo.Api("EOKJtzZmbgKQe3ZXOMu9MlCjkorbTc");
            var pods = createConnectionToSensibo.GetPods();
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
