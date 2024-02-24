using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.ViewModels
{
    public class AddressWindowViewModel : ViewModelBase
    {
        private readonly Services.Interfaces.INavigationService _navigationService;

        public AddressWindowViewModel(Services.Interfaces.INavigationService navigationService)
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
