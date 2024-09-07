using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using Trendyol.Models;
using Trendyol.Services;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels;

public class RemoveAccountViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly ApplicationDbContext _context;
    private readonly RemoveAccountService _removeAccountService;

    private string _FIN;
    private string _phone;
    private string _password;

   

    public string FIN
    {
        get => _FIN;
        set
        {
            if (Regex.IsMatch(value, @"^\d{2}[A-Za-z]{2}\d{2}[A-Za-z]{1}$") || string.IsNullOrEmpty(value))
                Set(ref _FIN, value);
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
                Set(ref _phone, value);
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
        set => Set(ref _password, value);
    }

    public RemoveAccountViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        _context = new ApplicationDbContext();
        _removeAccountService = new RemoveAccountService(_navigationService, _context);
        
    }

    public RelayCommand Login
    {
        get => new(
            () => _navigationService.NavigateTo<LoginWindowViewModel>());
    }

    public RelayCommand Delete
    {
        get => new(
            () =>
            {
                try
                {
                    if (!_context.Users.Any(u => u.FIN == FIN && u.Phone == Phone))
                    {
                        MessageBox.Show("Пользователь с такими данными не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        FIN = "";
                        Phone = "";
                        Password = "";
                        return;
                    }
                    else
                    {
                        _removeAccountService.RemoveUser(FIN, Phone, Password);
                        FIN = "";
                        Phone = "";
                        Password = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
    }

    public RelayCommand Back
    {
        get => new(
            () => _navigationService.NavigateTo<PrivateInfoViewModel>());
    }
    
    
}
