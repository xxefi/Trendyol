using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Xaml.Behaviors.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Trendyol.Services;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels
{
    public class SuperAdminCreateAdminViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly INavigationService _navigationService;
        private readonly ApplicationDbContext _context;
        private readonly AdminService _adminservice;

        private string _login;
        private string _password;
        private string _trypassword;

        private bool _enabledadmin;

        public bool EnabledAdmin
        {
            get => _enabledadmin;
            set
            {
                if (_enabledadmin != value)
                {
                    Set(ref _enabledadmin, value);  
                    OnPropertyChanged(nameof(EnabledAdmin));
                }
            }
        }


        public string Login
        {
            get => _login;
            set => Set(ref _login, value);
        }

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public string TryPassword
        {
            get => _trypassword;
            set
            {
                if (_trypassword != value)
                {
                    Set(ref _trypassword, value);
                    OnPropertyChanged(nameof(TryPassword));
                    EnabledAdmin = !string.IsNullOrWhiteSpace(TryPassword) && TryPassword.Length > 4;
                }
            }
        }

        public SuperAdminCreateAdminViewModel(INavigationService navigationService, ApplicationDbContext context)
        {
            _navigationService = navigationService;
            _context = context; 
            _adminservice = new AdminService(_context);
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<SuperAdminViewModel>();
                });
        }

        public RelayCommand CreateAdmin
        {
            get => new(
                () =>
                {
                    try
                    {
                        using (ApplicationDbContext context = new ApplicationDbContext())
                        {
                            if (string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(TryPassword))
                            {
                                MessageBox.Show("Поля не могут быть пустыми");
                                return;
                            }
                            else if (_context.Admin.Any(a => a.Name == Login))
                            {
                                MessageBox.Show("Админ с такими данными уже есть в базе данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            else if (TryPassword != Password)
                            {
                                MessageBox.Show("Вы неправильно ввели повторный пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            else
                            {
                                var newadmin = _adminservice.AdminRegister(Login, Password);
                                _context.Admin.Add(newadmin);
                                _context.SaveChanges();
                                MessageBox.Show("Админ успешно создан", "Admin", MessageBoxButton.OK, MessageBoxImage.Information);
                                Password = "";
                                TryPassword = "";
                                _navigationService.NavigateTo<SuperAdminViewModel>();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
        }
    }
}
