

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels
{
    public class DeveloperContactViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public DeveloperContactViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<TrendyolWindowViewModel>();
                });
        }
    }
}
