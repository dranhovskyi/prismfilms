using System;
using Autofac;
using Prism;
using Prism.Ioc;
using Prism.Mvvm;
using PrismFilms.Services;
using PrismFilms.ViewModels;
using PrismFilms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrismFilms
{
    public partial class App
    {
        public App() : this(null)
        {
        }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MoviesPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMoviesService, MoviesService>();
            
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MoviesPage, MoviesPageViewModel>();
            containerRegistry.RegisterForNavigation<MoviesDetailPage, MoviesDetailPageViewModel>();

        }
    }
}
