using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public class HistoryOrderViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;
        private readonly ApplicationDbContext _context;
        private readonly CurrentUserService _currentUserService;
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
            set
            {
                if (Set(ref _selectedOrder, value))
                {
                    _messenger.Send("SelectedProductForDocument");
                }
            }
        }


        public HistoryOrderViewModel(INavigationService navigationService, IMessenger messenger, ApplicationDbContext context, CurrentUserService currentUserService)
        {
            _navigationService = navigationService;
            _messenger = messenger;
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

        public RelayCommand Document
        {
            get => new(
                () =>
                {
                    if (SelectedOrder != null)
                    {
                        _messenger.Send(SelectedOrder, "SelectedProductForDocument");
                        _navigationService.NavigateTo<DocumentOrderViewModel>();
                    }
                    
                });
        }
    }
}
