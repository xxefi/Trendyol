using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using Trendyol.Models;
using Trendyol.Services;
using Trendyol.Services.Interfaces;
using Trendyol.Services.Classes;
using System.Collections.ObjectModel;
using Vonage.ProactiveConnect.Lists;

namespace Trendyol.ViewModels
{
    public class AddCargoViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ApplicationDbContext _context;
        private readonly AddCargoService _addCargoService;
        private readonly CurrentUserService _currentUserService;
        private string _nameProduct;
        private string _descriptionProduct;
        private decimal _priceProduct;
        private int _count;
        private string _selectedCategory;
        private ObservableCollection<string> _category;
        public string NameProduct
        {
            get => _nameProduct;
            set => Set(ref _nameProduct, value);
        }

        public string DescriptionProduct
        {
            get => _descriptionProduct;
            set => Set(ref _descriptionProduct, value);
        }

        public decimal PriceProduct
        {
            get => _priceProduct;
            set => Set(ref _priceProduct, value);
        }

        public ObservableCollection<string> Category
        {
            get => _category;
            set => Set(ref _category, value);
        }
        public string SelectedCategory
        {
            get => _selectedCategory;
            set => Set(ref _selectedCategory, value);
        }

        public int CountProduct
        {
            get => _count;
            set => Set(ref _count, value);
        }
        
        public AddCargoViewModel(INavigationService navigationService, ApplicationDbContext context, CurrentUserService currentUserService)
        {
            _navigationService = navigationService;
            _context = context;
            _currentUserService = currentUserService;
            _addCargoService = new AddCargoService(_context);
            Category = new ObservableCollection<string>
            {
                "Смартфоны",
                "Смарт гаджеты",
                "Ноутбуки, ПК, планшеты",
                "ТВ, аудио и фото",
                "Техника для кухни",
                "Техника для дома",
                "Посуда",
                "Техника для красоты и здоровья",
                "Хобби и развлечения",
                "Строительство и ремонт",
                "Авто товары",
                "Детский мир",
                "Другое"
            };

        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<TrendyolWindowViewModel>();
                });
        }

        public RelayCommand Add
        {
            get => new(
                () =>
                {
                    try
                    {
                        if (string.IsNullOrWhiteSpace(NameProduct) || string.IsNullOrWhiteSpace(DescriptionProduct)
                         || decimal.IsNegative(PriceProduct))
                        {
                            MessageBox.Show("Поля не могут быть пустыми");
                            return;
                        }
                        else
                        {
                            var product = _addCargoService.AddProduct(_currentUserService.UserId, NameProduct, DescriptionProduct, PriceProduct, SelectedCategory, CountProduct);
                            _context.Products.Add(product); 
                            _context.SaveChanges();
                            Order order = new Order
                            {
                                Created = DateTime.Now,
                                ProductsCount = product.Count,
                                UserId = product.UserId,
                                Product = product.Name,
                            };
                            _context.Orders.Add(order);
                            _context.SaveChanges();
                            MessageBox.Show("Товар успешно добавлен в заказ", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            _navigationService.NavigateTo<TrendyolWindowViewModel>();
                            NameProduct = "";
                            DescriptionProduct = "";
                            PriceProduct = 0;
                            CountProduct = 0;
                            SelectedCategory = null;
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