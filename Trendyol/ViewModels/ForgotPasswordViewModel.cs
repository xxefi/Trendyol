using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Trendyol.Models;
using Trendyol.Services;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels
{
    public class ForgotPasswordViewModel : ViewModelBase, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private readonly INavigationService _navigationService;
        private readonly ApplicationDbContext _context;
        private readonly ForgotPasswordService _forgotPasswordService;
        private string _FIN;
        private string _phone;
        private string _password;
        private string _tryPassword;
        private bool _forgotenabled;

        public bool ForgotEnabled
        {
            get => _forgotenabled;
            set
            {
                if (_forgotenabled != value)
                {
                    _forgotenabled = value;
                    OnPropertyChanged(nameof(ForgotEnabled));
                }
            }
        }

        public string FIN
        {
            get => _FIN;
            set
            {
                if (Regex.IsMatch(value, @"^\d{2}[A-Za-z]{2}\d{2}[A-Za-z]{1}$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _FIN, value);
                }
                else
                {
                    MessageBox.Show("Недействительный FIN");
                    return;
                }
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                if (Regex.IsMatch(value, @"^\+\d{3}\d{9}$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _phone, value);
                }
                else
                {
                    MessageBox.Show("Недействительный номер телефона");
                    return;
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (Regex.IsMatch(value, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*()-_+=])[A-Za-z\d!@#$%^&*()-_+=]{8,}$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _password, value);
                }
                else
                {
                    MessageBox.Show("Пароль должен содержать как минимум 8 символов," +
                        " включая хотя бы одну заглавную букву, одну строчную букву, одну цифру, и один специальный символ");
                    return;
                }
            }
        }

        public string TryPassword
        {
            get => _tryPassword;
            set
            {
                if (_tryPassword != value)
                {
                    Set(ref _tryPassword, value);
                    OnPropertyChanged(nameof(TryPassword));
                    ForgotEnabled = !string.IsNullOrWhiteSpace(TryPassword) && TryPassword.Length > 8;
                }
            }
        }
        public ForgotPasswordViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _context = new ApplicationDbContext();
            _forgotPasswordService = new ForgotPasswordService(_context);
        }

        public RelayCommand Login
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<LoginWindowViewModel>();
                });
        }

        public RelayCommand Forgot
        {
            get => new(
                () =>
                {
                    try
                    {
                        if (!_context.Users.Any(u => u.FIN == FIN || u.Phone == Phone))
                        {
                            MessageBox.Show("Мы не нашли такого пользователя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else if (TryPassword != Password)
                        {
                            MessageBox.Show("Вы неправильно ввели повторный пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else
                        {
                            _forgotPasswordService.ForgotPassword(FIN, Phone, Password);
                            _context.SaveChanges();
                            MessageBox.Show("Пароль успешно сброшен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            FIN = "";
                            Phone = "";
                            Password = "";
                            TryPassword = "";
                            _navigationService.NavigateTo<LoginWindowViewModel>();

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
