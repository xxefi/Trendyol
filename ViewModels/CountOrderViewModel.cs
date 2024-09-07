using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Trendyol.Models;
using Trendyol.Services;
using Trendyol.Services.Classes;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels
{
    public class CountOrderViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;
        private readonly ApplicationDbContext _context;
        private readonly CurrentUserService _currentUserService;
        private readonly AddCargoService _addCargoService;
        private ObservableCollection<ProductsForOrder> _productsForOrders;
        private ProductsForOrder _selectedProduct;
        private string _product;
        private int _count;

        public int Count
        {
            get => _count;
            set => Set(ref _count, value);
        }

        public string Product
        {
            get => _product;
            set => Set(ref _product, value);
        }

        public ObservableCollection<ProductsForOrder> ProductsForOrder
        {
            get => _productsForOrders;
            set => Set(ref _productsForOrders, value);
        }

        public ProductsForOrder SelectedProductsForOrders
        {
            get => _selectedProduct;
            set => Set(ref _selectedProduct, value);
        }
        public CountOrderViewModel(INavigationService navigationService, IMessenger messenger, ApplicationDbContext context, CurrentUserService currentUserService)
        {
            _navigationService = navigationService;
            _context = context;
            _currentUserService = currentUserService;
            _messenger = messenger;
            _selectedProduct = new ProductsForOrder();
            _addCargoService = new AddCargoService(_context);
            _messenger.Register<ProductsForOrder>(this, "SelectedProductForOrder", (product) =>
            {
                SelectedProductsForOrders = product;
            });
            

        }
        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<WareHouseViewModel>();
                });
        }

        public RelayCommand BuyProduct
        {
            get => new(
                () =>
                {
                    try
                    {
                        if (_selectedProduct == null)
                        {
                            MessageBox.Show("Ошибка при покупке товара");
                            return;
                        }
                        var wareHouseProduct = _context.WareHouse.FirstOrDefault
                        (p => p.ProductId == _selectedProduct.Id);

                        if (wareHouseProduct == null)
                        {
                            MessageBox.Show("Товар не найден на складе");
                            return;
                        }
                        switch (Count)
                        {
                            case 0:
                                MessageBox.Show("Укажите количество товара", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            case > 0 when wareHouseProduct.ProductCount < Count:
                                MessageBox.Show("На складе недостаточно товара.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                                Count = 0;
                                _navigationService.NavigateTo<WareHouseViewModel>();
                                return;
                            case > 0 when _currentUserService.Balance < _selectedProduct.Price * Count:
                                MessageBox.Show("Недостаточно средств для покупки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                Count = 0;
                                _navigationService.NavigateTo<WareHouseViewModel>();
                                return;
                            default:
                                var product = _addCargoService.AddProduct(
                                    _currentUserService.UserId,
                                    _selectedProduct.Name,
                                    _selectedProduct.Description,
                                    _selectedProduct.Price,
                                    _selectedProduct.Category,
                                    Count);

                                var order = new Order
                                {
                                    UserId = _currentUserService.UserId,
                                    Product = product.Name,
                                    ProductsCount = Count,
                                    Created = DateTime.Now,
                                };
                                _context.Products.Add(product);
                                _context.Orders.Add(order);
                                wareHouseProduct.ProductCount -= Count;

                                var user = _context.Users.FirstOrDefault(
                                    u => u.UserId == _currentUserService.UserId);
                                if (user != null)
                                    user.Balance -= _selectedProduct.Price * Count;
                                _currentUserService.Balance -= _selectedProduct.Price * Count;
                                _selectedProduct.Count -= Count;

                                _context.SaveChanges();
                                MessageBox.Show("Товар успешно куплен");
                                Count = 0;
                                _navigationService.NavigateTo<WareHouseViewModel>();
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                });
        }
    }
}
