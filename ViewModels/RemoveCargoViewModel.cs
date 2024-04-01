
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Trendyol.Models;
using Trendyol.Services;
using Trendyol.Services.Classes;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels
{
    public class RemoveCargoViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly CurrentUserService _currentUserService;
        private readonly ApplicationDbContext _context;
        private ObservableCollection<Order> _order;
        private Order _selectedOrder;


        public ObservableCollection<Order> Order
        {
            get => _order;
            set => Set(ref _order, value);
        }

        public Order SelectedOrder
        {
            get => _selectedOrder;
            set => Set(ref _selectedOrder, value);
        }

        public RemoveCargoViewModel(INavigationService navigationService, ApplicationDbContext context, CurrentUserService currentUserService)
        {
            _navigationService = navigationService;
            _context = context;
            _currentUserService = currentUserService;
            Order = new ObservableCollection<Order>(_context.Orders.Where(o => o.UserId == _currentUserService.UserId));
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<TrendyolWindowViewModel>();
                });
        }

        public RelayCommand Gancel
        {
            get => new(
                () =>
                {
                    try
                    {
                        if (SelectedOrder == null)
                        {
                            MessageBox.Show("Выберите заказ");
                        }
                        else
                        {
                            Order order = _context.Orders.FirstOrDefault(o => o.Product == _selectedOrder.Product);
                            if (order != null)
                            {
                                if (_selectedOrder.Status == "Заказ сделан")
                                {
                                    Products products = _context.Products.FirstOrDefault(o => o.Name == _selectedOrder.Product);
                                    if (products != null)
                                    {
                                        _context.Products.Remove(products);
                                        _context.SaveChanges();
                                    }
                                    _context.Orders.Remove(order);
                                    _context.SaveChanges();
                                    Order.Remove(order);
                                    MessageBox.Show("Успешно удалено");
                                    SelectedOrder = null;
                                }
                                else
                                {
                                    MessageBox.Show("Невозможно отменить заказ, т.к он уже выехал и напрявляется к службе доставки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return;
                                }
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
