using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Trendyol.Models;
using Trendyol.Services;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels
{
    public class DocumentOrderViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;
        private readonly ApplicationDbContext _context;
        private ObservableCollection<Order> _orders;
        private ObservableCollection<Products> _products;
        private Order _selectedOrder;
        private Products _selectedProducts;


        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set => Set(ref _orders, value);
        }

        public ObservableCollection<Products> Products
        {
            get => _products;
            set => Set(ref _products, value);
        }

        public Order SelectedOrder
        {
            get => _selectedOrder;
            set => Set(ref _selectedOrder, value);
        }

        public Products SelectedProducts
        {
            get => _selectedProducts;
            set => Set(ref _selectedProducts, value);
        }

        public DocumentOrderViewModel(INavigationService navigationService, IMessenger messenger, ApplicationDbContext context, Order order, Products product)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _context = context;
            order = SelectedOrder;
            _messenger.Register<Order>(this, "SelectedProductForDocument", (orders) =>
            {
                SelectedOrder = orders;
                order = SelectedOrder;
            });
            Orders = new ObservableCollection<Order>(_context.Orders.ToList());
            Products = new ObservableCollection<Products>(_context.Products.ToList());
            
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<HistoryOrderViewModel>();
                });
        }
    }
}
