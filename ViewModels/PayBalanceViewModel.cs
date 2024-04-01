using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Trendyol.Services;
using Trendyol.Services.Classes;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels
{
    public class PayBalanceViewModel : ViewModelBase
    {

        private readonly INavigationService _navigationService;
        private readonly ApplicationDbContext _context;
        private readonly CurrentUserService _currentUserService;
        private decimal _amount;
        private string _card;
        private string _month;
        private string _year;
        private string _CVV;
        
        public decimal Amount
        {
            get => _amount;
            set => Set(ref _amount, value);
        }

        public string Card
        {
            get => _card;
            set => Set(ref _card, value);
        }

        public string Month
        {
            get => _month;
            set
            {
                if (Regex.IsMatch(value, "^(0[1-9]|1[0-2])$"))
                {
                    Set(ref _month, value);
                }
                else
                {
                    return;
                }
            }
        }

        public string Year
        {
            get => _year;
            set
            {
                if (Regex.IsMatch(value, "^(0[1-9]|[1-9][0-9])|(20[2-9]|209[0-9])$"))
                {
                    Set(ref _year, value);
                }
                else
                {
                    return;
                }
            }
        }

        public string CVV
        {
            get => _CVV;
            set
            {
                if (Regex.IsMatch(value, @"^\d{3}$"))
                {
                    Set(ref _CVV, value);
                    //OnPropertyChanged(nameof(CVV));
                }
                else
                {
                    return;
                }
                    //PayEnabled = !string.IsNullOrWhiteSpace(CVV) && CVV.Length > 2;
            }
        }

        public PayBalanceViewModel(INavigationService navigationService, ApplicationDbContext context, CurrentUserService currentUserService)
        {
            _navigationService = navigationService;
            _context = context;
            _currentUserService = currentUserService;
            
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<UserBalanceViewModel>();
                });
        }

        public RelayCommand QuestionCVV
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<ExampleCVVViewModel>();
                });
        }

        public RelayCommand Pay
        {
            get => new(
                () =>
                {
                    try
                    {
                        var user = _context.Users.FirstOrDefault(u => u.UserId == _currentUserService.UserId);
                        if (user != null)
                        {
                            if (Amount == 0 || string.IsNullOrWhiteSpace(Card) || string.IsNullOrWhiteSpace(Month)
                            || string.IsNullOrWhiteSpace(Year) || string.IsNullOrWhiteSpace(CVV))
                            {
                                MessageBox.Show("Поля не могут быть пустыми");
                                return;
                            }
                            user.Balance += Amount;
                            _context.SaveChanges();
                            MessageBox.Show($"Баланс пополнен на сумму {Amount} AZN");              
                            _currentUserService.Balance = user.Balance;
                            Amount = 0;
                            Card = "";
                            Month = "";
                            Year = "";
                            CVV = "";
                            _navigationService.NavigateTo<UserBalanceViewModel>();
                        }
                        else
                        {
                            MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
