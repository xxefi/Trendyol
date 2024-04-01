using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Trendyol.CustomMessageBox;
using Trendyol.Messages;
using Trendyol.Models;
using Trendyol.Services;
using Trendyol.Services.Classes;
using Trendyol.Services.Interfaces;
using Trendyol.Views;

namespace Trendyol.ViewModels
{

    public class LoginWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  
        }
        private readonly INavigationService _navigationService;
        private readonly ErrorView _error;
        private readonly UsersService _usersService;
        private readonly AdminService _adminService;
        private readonly SuperAdminService _superAdminService;
        private readonly ApplicationDbContext _context;
        private readonly CurrentUserService _currentUserService;
        private string _email;
        private string _password;

        private bool _loginenabled;

        public bool LoginEnabled
        {
            get => _loginenabled;
            set
            {
                if (_loginenabled != value)
                {
                    _loginenabled = value;
                    OnPropertyChanged(nameof(LoginEnabled));
                }
            }
        }

        public string Email
        {
            get => _email;
            set => Set(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set
            {
                if (value != _password)
                {
                    Set(ref _password, value);
                    OnPropertyChanged(nameof(Password));
                    LoginEnabled = !string.IsNullOrWhiteSpace(Password) && Password.Length > 4;
                }
            }
        }

        public LoginWindowViewModel(INavigationService navigationService, CurrentUserService currentUserService)
        {
            _context = new ApplicationDbContext();
            _usersService = new UsersService(_context);
            _adminService = new AdminService(_context);
            _superAdminService = new SuperAdminService(_context);
            _navigationService = navigationService;
            _currentUserService = currentUserService;
            _error = new ErrorView();
        }

        public RelayCommand Create
        {
            get => new(
            () =>
            {
                _navigationService.NavigateTo<RegisterWindowViewModel>();
            }
        );
    }
        public RelayCommand Login => new(async () =>
        {
            try
            {
                if (_superAdminService.SuperAdminLogin(Email, Password))
                {
                    _navigationService.NavigateTo<SuperAdminViewModel>();
                }
                else if (_adminService.AdminLogin(Email, Password))
                {
                    _navigationService.NavigateTo<AdminWindowViewModel>();
                }
                else if (_usersService.UserLogin(Email, Password))
                {
                    var user = _usersService.GetUser(Email);
                    _currentUserService.UpdateUserData(user);
                    _navigationService.NavigateTo<TrendyolWindowViewModel>();
                }
                else
                {
                    ErrorView error = new ErrorView();
                    error.Show();
                    Password = "";
                    return;
                }
                Email = "";
                Password = "";
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        });

        public RelayCommand Forgot
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<ForgotPasswordViewModel>();
                });
        }

        public RelayCommand Guest
        {
            get => new(
                () =>
                {
                    MessageBoxResult result = MessageBox.Show("Вы входите как гость. Вам не будут доступны функции, которые доступны обычному пользователю, продолжить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        _navigationService.NavigateTo<TrendyolGuestViewModel>();
                    }
                });
        }

       
    }
}
