using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Trendyol.Models;
using Trendyol.Services.Interfaces;
using Trendyol.ViewModels;

namespace Trendyol.Services
{
    public class RemoveAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly INavigationService _navigationService;

        public RemoveAccountService(INavigationService navigationService, ApplicationDbContext context)
        {
            _context = context;
            _navigationService = navigationService;
        }

        public bool RemoveUser(string FIN, string phone, string password)
        {
            User user = _context.Users.SingleOrDefault(u => u.FIN == FIN && u.Phone == phone);
            if (user != null)
            {
                bool passwordCheck = BCrypt.Net.BCrypt.Verify(password, user.Password);
                if (passwordCheck)
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить аккаунт?",
                        "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        MessageBoxResult result1 = MessageBox.Show("Вы уверены? ",
                            "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result1 == MessageBoxResult.Yes)
                        {
                            MessageBoxResult result2 = MessageBox.Show(
                                "Примечание: История заказов, включая заказы, которые не дошли до вас, ваш баланс," +
                                " и все данные будут удалены безвозвратно. Вы действительно хотите удалить аккаунт?",
                                "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            if (result2 == MessageBoxResult.Yes)
                            {
                                _context.Users.Remove(user);
                                _context.SaveChanges();
                                MessageBox.Show("Аккаунт успешно удалён из базы данных", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                FIN = "";
                                phone = "";
                                password = "";
                                _navigationService.NavigateTo<LoginWindowViewModel>();
                                return true;
                            }
                            else
                            {
                                _navigationService.NavigateTo<PrivateInfoViewModel>();
                            }
                        }
                        else
                        {
                            _navigationService.NavigateTo<PrivateInfoViewModel>();
                        }
                    }
                    else
                    {
                        _navigationService.NavigateTo<PrivateInfoViewModel>();
                    }
                }
                else
                {
                    MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            return false;
        }
    }
}
