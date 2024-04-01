using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels
{
    internal class TrendyolGuestViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public TrendyolGuestViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand Quit
        {
            get => new(
                () =>
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите выйти из режима гостя?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        _navigationService.NavigateTo<LoginWindowViewModel>();
                    }
                });
        }

        public RelayCommand Function
        {
            get => new(
                () =>
                {
                    MessageBoxResult result = MessageBox.Show("Для получение доступа к этой функции, вам нужно создать аккаунт. Хотите пройти регистрацию?", "Уведомление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        _navigationService.NavigateTo<RegisterWindowViewModel>();
                        MessageBox.Show("Вы были перенаправлены к окне регистраций пользователя");
                    }
                });
        }

        
    }
}
