using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trendyol.Services;
using Trendyol.Views;
using Trendyol.Messages;
using System.Windows;
using System.Timers;
using System.IO;
using Trendyol.Services.Interfaces;
using Timer = System.Timers.Timer;
using MaterialDesignColors.Recommended;

namespace Trendyol.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly INavigationService _navigationService;
        private ViewModelBase currentView;


        public ViewModelBase CurrentView
        {
            get => currentView;
            set => Set(ref currentView, value);
        }

        

        public MainWindowViewModel(INavigationService navigationService, IMessenger messenger)
        {
            CurrentView = App.Container.GetInstance<LoginWindowViewModel>();
            _messenger = messenger;
            _navigationService = navigationService;

            _messenger.Register<NavigationMessage>(this, message =>
            {
                CurrentView = message.ViewModelType;
            });
            UtcValue = DateTime.Now;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UtcValue)));            

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

        public DateTime UtcValue { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        
    }
}
