using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using Trendyol.Models;
using Trendyol.Services;
using Trendyol.Services.Interfaces;
using System.Windows.Input;

namespace Trendyol.ViewModels
{
    public class SuperAdminDeleteCargoViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ApplicationDbContext _context;
        private ObservableCollection<Order> _order;
        private Order _selectedOrder;
        private string _search;

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

        public string Search
        {
            get => _search;
            set
            {
                if (_search != value)
                {
                    Set(ref _search, value);
                    Filter();
                    
                }
            }
        }


        public SuperAdminDeleteCargoViewModel(INavigationService navigationService, ApplicationDbContext context)
        {
            _navigationService = navigationService;
            _context = context;
            Order = new ObservableCollection<Order>(_context.Orders);
        }

        public RelayCommand Back
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<SuperAdminViewModel>();
            });
        }

        public RelayCommand SearchCommand
        {
            get => new(
                () =>
                {
                    Filter();
                });
        }

        public async Task Filter()
        {
            var filterOrder = await Task.Run(() =>
            {
                return _context.Orders
                        .Where(o => o.Product.Contains(Search));
            });

            Order = new ObservableCollection<Order>(filterOrder);
        } 

        public RelayCommand Delete
        {
            get => new(() =>
            {
                try
                {
                    if (SelectedOrder == null)
                    {
                        MessageBox.Show("Вы не выбрали товар");
                        return;
                    }
                    Order? order = _context.Orders.FirstOrDefault(o => o.Product == _selectedOrder.Product);
                    Products? products = _context.Products.FirstOrDefault(p => p.Name == _selectedOrder.Product);
                        
                    _context.Products.Remove(products);
                    _context.SaveChanges();
                        
                    _context.Orders.Remove(order);
                    _context.SaveChanges();
                    Order.Remove(order);
                    MessageBox.Show("Успешно удалено");
                    SelectedOrder = null;
                    _navigationService.NavigateTo<SuperAdminViewModel>();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            });
        }
    }
}
