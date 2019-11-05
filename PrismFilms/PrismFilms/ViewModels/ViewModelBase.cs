using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismFilms.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, INavigatedAwareAsync, IDestructible, IConfirmNavigation, IConfirmNavigationAsync
    {
        protected INavigationService NavigationService { get; private set; }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual async Task OnNavigatedToAsync(INavigationParameters parameters)
        {

        }

        public virtual bool CanNavigate(INavigationParameters parameters)
        {
            return true;
        }

        public virtual async Task<bool> CanNavigateAsync(INavigationParameters parameters)
        {
            return true;
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
