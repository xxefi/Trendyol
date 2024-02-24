using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels
{
    public class ExampleCVVViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ExampleCVVViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<PayBalanceViewModel>();
                });
        }
    }
}
