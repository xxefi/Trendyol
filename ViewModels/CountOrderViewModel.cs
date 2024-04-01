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
                        if (_selectedProduct != null)
                        {
                            var wareHouseProduct = _context.WareHouse.FirstOrDefault(p => p.ProductId == _selectedProduct.Id);
                            if (wareHouseProduct != null)
                            {
                                if (wareHouseProduct.ProductCount < Count)
                                {
                                    MessageBox.Show("На складе отсутствует столько количество этого товара.");
                                    Count = 0;
                                    _navigationService.NavigateTo<WareHouseViewModel>();
                                    return;
                                }
                                
                                else if (Count == 0)
                                {
                                    MessageBox.Show("Напишите количество товара", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return;
                                }

                                else if (_currentUserService.Balance < _selectedProduct.Price * Count)
                                {
                                    MessageBox.Show("Недостаточно средств", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                    Count = 0;
                                    _navigationService.NavigateTo<WareHouseViewModel>();
                                    return;
                                }
                                
                            }

                            var product = _addCargoService.AddProduct(_currentUserService.UserId, _selectedProduct.Name, _selectedProduct.Description, _selectedProduct.Price, _selectedProduct.Category, Count);
                            Order order = new Order
                            {
                                UserId = _currentUserService.UserId,
                                Product = product.Name,
                                ProductsCount = Count,
                                Status = "Заказ сделан",
                                Created = DateTime.Now,
                            };
                            
                            _context.Products.Add(product);
                            _context.SaveChanges();

                            _context.Orders.Add(order);
                            _context.SaveChanges();

                            var user = _context.Users.FirstOrDefault(u => u.UserId == _currentUserService.UserId);
                            if (user != null)
                            {
                                user.Balance -= Math.Round(_selectedProduct.Price * Count, 2);
                                _context.SaveChanges();
                            }
                            _currentUserService.Balance -= Math.Round(_selectedProduct.Price * Count, 2);
                            _context.SaveChanges();

                            wareHouseProduct.ProductCount -= Count;
                            _context.SaveChanges();

                            _selectedProduct.Count -= Count;
                            _context.SaveChanges();

                            MessageBox.Show("Товар успешно куплен");
                            Count = 0;
                            _navigationService.NavigateTo<WareHouseViewModel>();
                            
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при покупке товара");
                            return;
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
