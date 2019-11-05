using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Navigation;
using PrismFilms.Models;
using PrismFilms.Services;
using Xamarin.Forms;

namespace PrismFilms.ViewModels
{
    public class MoviesPageViewModel : ViewModelBase
    {
        public ObservableCollection<Movie> UpComingMovies { get; set; }

        private Movie moviesSelected;
        public Movie MoviesSelected
        {
            get { return moviesSelected; }
            set
            {
                moviesSelected = value;
                if (moviesSelected != null)
                {
                    NavigateToSelectedMovieDetailPage();                    
                }
            }
        }

        private bool isLoading;
        public bool IsLoading
        {
            get { return isLoading; }
            set { SetProperty(ref isLoading, value); }
        }

        public ICommand GetMoviesCommand { get; set; }

        private readonly INavigationService navigationService;
        private readonly IMoviesService moviesService;

        public MoviesPageViewModel(INavigationService navigationService, IMoviesService moviesService)
            : base(navigationService)
        {
            this.navigationService = navigationService;
            this.moviesService = moviesService;

            Title = "Movies List";
            UpComingMovies = new ObservableCollection<Movie>();
            GetMoviesCommand = new Command(async () => await GetMoviesAsync());
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            await GetMoviesAsync();
        }

        public async Task GetMoviesAsync()
        {
            if (IsLoading)
            {
                return;
            }

            try
            {
                IsLoading = true;

                var items = await moviesService.GetMoviesAsync(Constants.Constants.MOVIES_URL);
                items = items.OrderByDescending(x => x.rating).ToList();

                UpComingMovies.Clear();

                foreach (var item in items)
                {
                    UpComingMovies.Add(item);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: " + e.Message);
            }
            finally
            {
                IsLoading = false;
            }
        }

        private void NavigateToSelectedMovieDetailPage()
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("moviesSelected", moviesSelected);
            navigationService.NavigateAsync("MoviesDetailPage", navigationParams);
        }
    }
}
