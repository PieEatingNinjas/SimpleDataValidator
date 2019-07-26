using Lottie.Forms;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleInputDataValidator.Test
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            AnimationView view = new AnimationView();
            MainPage = new MainPage();
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
