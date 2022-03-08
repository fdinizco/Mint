using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Navigation;
using SlotGroups.Common;

namespace SlotGroups.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public ICommand NextCommand => new AsyncCommand(NavigateAsync);

        private async Task NavigateAsync() { await NavigationService.NavigateAsync(NavigateTo.Detail); }

        public HomePageViewModel(INavigationService navigationService)
                    : base(navigationService)
        {
        }
    }
}
