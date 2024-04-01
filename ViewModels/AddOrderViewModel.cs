using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Identity.Client;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using EnumsNET;
using Trendyol.Models;
using Trendyol.Services;
using Trendyol.Services.Classes;
using Trendyol.Services.Interfaces;
using Trendyol.Views;

namespace Trendyol.ViewModels
{
    public class AddOrderViewModel : ViewModelBase, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly INavigationService _navigationService;
        private readonly ApplicationDbContext _context;
        private readonly AddOrderService _addOrderService;
        private readonly ProductsForOrder _product;
        private ObservableCollection<string> _category;
        private BitmapImage _imagebox;
        private string _name;
        private string _description;
        private decimal _price;
        private int _count;
        private string _selectedCategory;
        private bool _enabledimage;
        private bool _enabledadd;


        public bool EnabledImage
        {
            get => _enabledimage;
            set
            {
                if (_enabledimage != value)
                {
                    Set(ref _enabledimage, value);
                    OnPropertyChanged(nameof(EnabledImage));
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
                    EnabledImage = value != null;
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
         public AddOrderViewModel(INavigationService navigationService, ApplicationDbContext context, CurrentUserService currentUserService)
         {
            _navigationService = navigationService;
            _context = context;
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
                    _navigationService.NavigateTo<AdminWindowViewModel>();
                });
        }

        public RelayCommand Image
        {
            get => new(
                () =>
                {
                    OpenFileDialog file = new();
                    file.Filter = "Фото (*.jpg;*.jpeg;*.png;*.gif) | *.jpg;*jpeg;*.png;*.gif";
                    if (file.ShowDialog() == true)
                    {
                       _product.Image = File.ReadAllBytes(file.FileName);
                       ImageBox = new BitmapImage(new Uri(file.FileName));
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
                            decimal.IsNegative(Price) || int.IsNegative(Count))
                        {
                            MessageBox.Show("Поля не могут быть пустыми");
                            return;
                        }
                        
                        else
                        {
                            var product = _addOrderService.AddProductOrder(Name, Description, Price, Count, SelectedCategory, _product.Image);
                            _context.ProductsForOrders.AddRange(product);
                            _context.SaveChanges();
                            WareHouse wareHouse = new()
                            {
                                ProductId = product.Id,
                                ProductCount = product.Count,
                                Name = product.Name
                            };
                            _context.WareHouse.Add(wareHouse);
                            _context.SaveChanges();
                            Name = "";
                            Description = "";
                            Price = 0;
                            Count = 0; 
                            _product.Image = [0];
                            MessageBox.Show("Товар успешно добавлен на склад");
                            _navigationService.NavigateTo<AdminWindowViewModel>();
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
                    }
                });
        }
    }
}
