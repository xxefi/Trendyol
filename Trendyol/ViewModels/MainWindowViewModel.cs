using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Services;
using Trendyol.Views;
using Trendyol.Messages;
using System.Windows;
using System.IO;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;
        private ViewModelBase currentView;

        public ViewModelBase CurrentView
        {
            get => currentView;
            set => Set(ref currentView, value);
        }

        

        public MainWindowViewModel(INavigationService navigationService, IMessenger messenger)
        {
            CurrentView = App.Container.GetInstance<LoginWindowViewModel>();
            _navigationService = navigationService;
            _messenger = messenger;

            _messenger.Register<NavigationMessage>(this, message =>
            {
                CurrentView = message.ViewModelType;
            });        
            
            
        }


        public RelayCommand Quit
        {
            get => new(
                () =>
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите выйти?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        App.Current.Shutdown();
                    }
                });
        }

        
    }
}
