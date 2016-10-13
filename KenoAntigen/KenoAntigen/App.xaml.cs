using Acr.UserDialogs;
using Akavache;
using FreshMvvm;
using KenoAntigen.Interfaces;
using KenoAntigen.Messages;
using KenoAntigen.PageModels;
using KenoAntigen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace KenoAntigen
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            RegisterServices();
            SubScribe();
            LoadLaunchPage();                   
        }

        private void SubScribe()
        {
            MessagingCenter.Subscribe<ConfirmRegistrationMessage>(this, nameof(ConfirmRegistrationMessage), (sender) => { LoadConfirmRegistration(); });
            MessagingCenter.Subscribe<LoginSuccessMessage>(this, nameof(LoginSuccessMessage), (sender) => { LoadMainPage(); });
            MessagingCenter.Subscribe<StartRegistrationMessage>(this, nameof(StartRegistrationMessage), (sender) => { LoadStartRegistration(); });
            MessagingCenter.Subscribe<LoadLoginMessage>(this, nameof(LoadLoginMessage), (sender) => { LoadStartRegistration(); });
        }

        private void LoadStartRegistration()
        {
            MainPage = FreshPageModelResolver.ResolvePageModel<CreateAccountPageModel>();
        }

        private void LoadMainPage()
        {
            MainPage = FreshPageModelResolver.ResolvePageModel<HomePageModel>();
        }

        private void LoadConfirmRegistration()
        {
            MainPage = FreshPageModelResolver.ResolvePageModel<RegistrationVerificationPageModel>();
        }

        private void LoadLaunchPage()
        {
            MainPage = FreshPageModelResolver.ResolvePageModel<LaunchPageModel>();
        }

        private void LoadRegistrationPage()
        {
            MainPage = new FreshNavigationContainer( FreshPageModelResolver.ResolvePageModel<CreateAccountPageModel>());
        }

        private void RegisterServices()
        {
            FreshIOC.Container.Register<ISocketService>(new SocketService());
            FreshIOC.Container.Register<IUserDialogs>(UserDialogs.Instance);
            FreshIOC.Container.Register<ILoginCache, LoginCache>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            BlobCache.ApplicationName = "KenoAntigen";
            BlobCache.EnsureInitialized();
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
