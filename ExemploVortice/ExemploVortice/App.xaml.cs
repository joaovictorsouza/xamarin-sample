using ExemploVortice.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ExemploVortice
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var holdingPage = new NavigationPage();
            holdingPage.PushAsync(new MainPage());
            MainPage = holdingPage;
        }

        protected override void OnStart()
        {
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
