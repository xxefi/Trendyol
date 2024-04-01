using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Trendyol.Models;
using Trendyol.Services;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels
{
    public class WareHouseViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ApplicationDbContext _context;
        private readonly IMessenger _messenger;
        private ObservableCollection<ProductsForOrder> _productsForOrders;
        private ProductsForOrder _selectedProductsForOrders;

        public ObservableCollection<ProductsForOrder> ProductsForOrders
        {
            get => _productsForOrders;
            set => Set(ref _productsForOrders, value);
        }

        public ProductsForOrder SelectedProductsForOrders
        {
            get => _selectedProductsForOrders;
            set
            {
                if (Set(ref _selectedProductsForOrders, value))
                {
                    _messenger.Send(value, "SelectedProductForOrder");
                }

            }
        }

        public WareHouseViewModel(INavigationService navigationService, IMessenger messenger, ApplicationDbContext context)
        {
            _navigationService = navigationService;
            _context = context;
            _messenger = messenger;
            ProductsForOrders = new ObservableCollection<ProductsForOrder>(_context.ProductsForOrders);
            _messenger.Send(SelectedProductsForOrders);
        }


        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<TrendyolWindowViewModel>();
                });
        }

        public RelayCommand Buy
        {
            get => new(
                () =>
                {
                    try
                    {
                        if (SelectedProductsForOrders != null)
                        {
                            _messenger.Send(SelectedProductsForOrders, "SelectedProductForOrder");
                            _navigationService.NavigateTo<CountOrderViewModel>();
                        }
                        else
                        {
                            MessageBox.Show("Вы не выбрали товар", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
