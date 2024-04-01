using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Xps.Serialization;
using Trendyol.Messages;
using Trendyol.Models;
using Trendyol.Services;
using Trendyol.Services.Classes;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels
{
    public class PrivateInfoViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ApplicationDbContext _context;
        private readonly CurrentUserService _currentUserService;
        private readonly User user;

        private string _name;
        private string _surname;
        private string _FIN;
        private string _email;
        private string _phone;
        private string _login;
        private decimal _balance;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Surname
        {
            get => _surname;
            set => Set(ref _surname, value);
        }

        public string FIN
        {
            get => _FIN;
            set => Set(ref _FIN, value);
        }

        public string Email
        {
            get => _email;
            set => Set(ref _email, value);
        }

        public string Phone
        {
            get => _phone;
            set => Set(ref _phone, value);
        }

        public string Login
        {
            get => _login;
            set => Set(ref _login, value);
        }

        public decimal Balance
        {
            get => _balance;
            set => Set(ref _balance, value);
        }
        
       public PrivateInfoViewModel(INavigationService navigationService, ApplicationDbContext context, CurrentUserService currentUserService)
       {
            _navigationService = navigationService;
            _context = context;
            _currentUserService = currentUserService;
            user = new User();

            _currentUserService.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(CurrentUserService.Name))
                {
                    Name = _currentUserService.Name;
                }
                else if (args.PropertyName == nameof(CurrentUserService.Surname))
                {
                    Surname = _currentUserService.Surname;
                }
                else if (args.PropertyName == nameof(CurrentUserService.FIN))
                {
                    FIN = _currentUserService.FIN;
                }
                else if (args.PropertyName == nameof(CurrentUserService.Phone))
                {
                    Phone = _currentUserService.Phone;
                }
                else if (args.PropertyName == nameof(CurrentUserService.Email))
                {
                    Email = _currentUserService.Email;
                }
                else if (args.PropertyName == nameof(CurrentUserService.Login))
                {
                    Login = _currentUserService.Login;
                }
                else if (args.PropertyName == nameof(CurrentUserService.Balance))
                {
                    Balance = _currentUserService.Balance;
                }
            };
            
            _currentUserService.UpdateUserData(user);
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<TrendyolWindowViewModel>();
                });
        }

        public RelayCommand Save
        {
            get => new(
                () =>
                {
                    try
                    {
                        var user = _context.Users.SingleOrDefault(u => u.Email == _currentUserService.Email
                            && u.Phone == _currentUserService.Phone && u.Login == _currentUserService.Login);
                        if (user != null)
                        {
                            user.Email = Email;
                            user.Phone = Phone;
                            user.Login = Login;
                            _currentUserService.Email = Email;
                            _currentUserService.Phone = Phone;
                            _currentUserService.Login = Login;

                            _context.SaveChanges();
                            MessageBox.Show("Изменения сохранены");
                        }
                        else
                        {
                            MessageBox.Show("Не удалось сохранить изменения");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
        }

        public RelayCommand Delete
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<RemoveAccountViewModel>();
            });
        }

        
    }
}
