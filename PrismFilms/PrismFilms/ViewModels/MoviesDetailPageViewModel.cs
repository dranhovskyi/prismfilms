using Prism.Commands;
using Prism.Navigation;
using PrismFilms.DependencyServices;
using PrismFilms.Models;

namespace PrismFilms.ViewModels
{
    public class MoviesDetailPageViewModel : ViewModelBase
    {
        private Movie upComingMovies;
        public Movie UpComingMovies
        {
            get { return upComingMovies; }
            set { SetProperty(ref upComingMovies, value); }
        }

        public DelegateCommand SpeakCommand { get; set; }

        private readonly INavigationService navigationService;
        private readonly ITextToSpeech textToSpeech;

        public MoviesDetailPageViewModel(INavigationService navigationService, ITextToSpeech textToSpeech)
            : base(navigationService)
        {
            this.navigationService = navigationService;
            this.textToSpeech = textToSpeech;

            SpeakCommand = new DelegateCommand(Speak);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);

            if (parameters["moviesSelected"] is Movie movie)
            {
                UpComingMovies = movie;
                Title = movie.title;
            }
        }

        private void Speak()
        {
            textToSpeech.Speak(upComingMovies.title);
        }
    }
}
