using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels
{
    public class AddressWindowViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public AddressWindowViewModel(INavigationService navigationService)
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
