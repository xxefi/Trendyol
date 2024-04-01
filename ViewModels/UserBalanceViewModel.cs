using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Models;
using Trendyol.Services.Classes;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels
{
    public class UserBalanceViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly CurrentUserService _currentUserService;
        private readonly User User = new();
        private decimal _balance;

        public decimal Balance
        {
            get => _balance;
            set => Set(ref _balance, value);
        }
        public UserBalanceViewModel(INavigationService navigationService, CurrentUserService currentUserService)
        {
            _navigationService = navigationService;
            _currentUserService = currentUserService;

            _currentUserService.PropertyChanged += (sender, args) =>
            {
                Balance = _currentUserService.Balance;
            };
            _currentUserService.UpdateUserData(User);
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<TrendyolWindowViewModel>();
                });
        }

        public RelayCommand Pay
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<PayBalanceViewModel>();
                });
        }
    }
}
