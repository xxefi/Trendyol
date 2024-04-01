using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using Trendyol.Models;
using Trendyol.Services.Classes;
using Trendyol.Services;
using Trendyol.Services.Interfaces;
using System.IO;
using System.ComponentModel;
using System.Runtime.InteropServices.Marshalling;
using System.Net.WebSockets;

namespace Trendyol.ViewModels
{
    public class SuperAdminAddOrderViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private readonly INavigationService _navigationService;
        private readonly ApplicationDbContext _context;
        private readonly CurrentUserService _currentUserService;
        private readonly AddOrderService _addOrderService;
        private readonly ProductsForOrder _product;
        private BitmapImage _imagebox;

        private string _name;
        private string _description;
        private decimal _price;
        private int _count;
        private ObservableCollection<string> _category;
        private string _selectedCategory;

        private bool _enabledphoto;
        private bool _enabledadd;

        public bool EnabledPhoto
        {
            get => _enabledphoto;
            set
            {
                if (_enabledphoto != value)
                {
                    Set(ref _enabledphoto, value);
                    OnPropertyChanged(nameof(EnabledPhoto));
                }
            }
        }

        public bool EnabledAdd
        {
            get => _enabledadd;
            set
            {
                if (_enabledadd != value)
                {
                    Set(ref _enabledadd, value);
                    OnPropertyChanged(nameof(EnabledAdd));
                }
            }
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Description
        {
            get => _description;
            set => Set(ref _description, value);
        }

        public decimal Price
        {
            get => _price;
            set => Set(ref _price, value);
        }

        public int Count
        {
            get => _count;
            set => Set(ref _count, value);
        }

        public ObservableCollection<string> Category
        {
            get => _category;
            set => Set(ref _category, value);
        }

        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                if (_selectedCategory != value)
                {
                    Set(ref _selectedCategory, value);
                    OnPropertyChanged(nameof(SelectedCategory));
                    EnabledPhoto = value != null;
                }
            }
        }

        public BitmapImage ImageBox
        {
            get => _imagebox;
            set
            {
                if (_imagebox != value)
                {
                    Set(ref _imagebox, value);
                    OnPropertyChanged(nameof(ImageBox));
                    EnabledAdd = value != null;
                }
            }
        }
        public SuperAdminAddOrderViewModel(INavigationService navigationService, ApplicationDbContext context, CurrentUserService currentUserService)
        {
            _navigationService = navigationService;
            _context = context;
            _currentUserService = currentUserService;
            _addOrderService = new AddOrderService(_context);
            _product = new ProductsForOrder();  
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
                    _navigationService.NavigateTo<SuperAdminViewModel>();
                });
        }

        public RelayCommand Image
        {
            get => new(
                () =>
                {
                    try
                    {
                        OpenFileDialog file = new();
                        file.Filter = "Фото (*.jpg;*.jpeg;*.png;*.gif) | *.jpg;*jpeg;*.png;*.gif |Все файлы (*.*) | *.*";

                        if (file.ShowDialog() == true)
                        {
                            _product.Image = File.ReadAllBytes(file.FileName);
                            ImageBox = new BitmapImage(new Uri(file.FileName));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                });
        }

        public RelayCommand Add
        {
            get => new(
                () =>
                {
                    try
                    {
                        if (_product.Image == null)
                        {
                            MessageBox.Show("Выберите изображение");
                            return;
                        }
                        else if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Description) ||
                            decimal.IsNegative(Price) || int.IsNegative(Count) ||
                            string.IsNullOrEmpty(SelectedCategory))
                        {
                            MessageBox.Show("Поля не могут быть пустыми");
                            return;
                        }
                        else
                        {
                            var product = _addOrderService.AddProductOrder(Name, Description, Price, Count, SelectedCategory, _product.Image);
                            if (product != null)
                            {
                                _context.ProductsForOrders.AddRange(product);
                                _context.SaveChanges();
                                WareHouse wareHouse = new WareHouse()
                                {
                                    ProductId = product.Id,
                                    ProductCount = product.Count,
                                    Name = product.Name
                                };
                                _context.WareHouse.Add(wareHouse);
                                _context.SaveChanges();
                                
                                MessageBox.Show("Товар успешно добавлен в склад");
                                _navigationService.NavigateTo<SuperAdminViewModel>();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка при добавлений продукта", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            Name = "";
                            Description = "";
                            Price = 0;
                            Count = 0;
                            SelectedCategory = "";
                            _product.Image = null;
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
