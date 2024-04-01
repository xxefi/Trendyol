using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Trendyol.ViewModels;

namespace Trendyol.ViewModels
{
    public class TrendyolWindowViewModel : ViewModelBase
    {
        private readonly Services.Interfaces.INavigationService _navigationService;

        public TrendyolWindowViewModel(Services.Interfaces.INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand Quit
        {
            get => new(
                () =>
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите выйти из аккаунта?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        _navigationService.NavigateTo<LoginWindowViewModel>();
                    }
                });
        }

        public RelayCommand Account
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<PrivateInfoViewModel>();
                });
        }

        public RelayCommand Address
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<AddressWindowViewModel>();
                });
        }

        public RelayCommand AddCargo
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<AddCargoViewModel>();
                });
        }

        public RelayCommand RemoveCargo
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<RemoveCargoViewModel>();
                });
        }

        public RelayCommand Order
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<HistoryOrderViewModel>();
                });
        }

        public RelayCommand Buy
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<WareHouseViewModel>();
                });
        }

        public RelayCommand Balance
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<UserBalanceViewModel>();
                });
        }

        public RelayCommand Contact
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<DeveloperContactViewModel>();
                });
        }


    }
}
