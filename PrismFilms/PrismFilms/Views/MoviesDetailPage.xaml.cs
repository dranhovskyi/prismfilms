using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismFilms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesDetailPage : ContentPage
    {
        public MoviesDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
