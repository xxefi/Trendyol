using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Trendyol.Migrations;
using Trendyol.Models;
using Trendyol.Services;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels
{
    public class AdminWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private readonly INavigationService _navigationService;
        private readonly ApplicationDbContext _context;
        private ObservableCollection<Order> _order;
        private Order _selectedOrder;
        private RadioButtons _radioButtons;
        private string _search;
        

       
        public ObservableCollection<Order> Order
        {
            get => _order;
            set
            {
                if (_order != value)
                {
                    Set(ref _order, value);
                    OnPropertyChanged(nameof(Order));
                }
            }
        }
        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                if (_selectedOrder != value)
                {
                    Set(ref _selectedOrder, value);
                    OnPropertyChanged(nameof(SelectedOrder.Status));
                }
            }
        }

        public RadioButtons RadioButton
        {
            get => _radioButtons;
            set
            {
                if (_radioButtons != value)
                {
                    Set(ref _radioButtons, value);
                    OnPropertyChanged(nameof(RadioButton));
                }
            }
        }

        public string Search
        {
            get => _search;
            set
            {
                if (_search != value)
                {
                    Set(ref _search, value);
                    OnPropertyChanged(nameof(Search));
                    Filter();
                }
                
            }
        }

       
        public AdminWindowViewModel(INavigationService navigationService, ApplicationDbContext context)
        {
            _navigationService = navigationService;
            _context = context;
            RadioButton = new RadioButtons();
            Order = new ObservableCollection<Order>(_context.Orders);
            
        }


        public RelayCommand Exit
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<LoginWindowViewModel>();
                });
        }

        public RelayCommand AddOrder
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<AddOrderViewModel>();
                });
        }

        public RelayCommand Check
        {
            get => new(
                () =>
                {
                    try
                    {
                        
                        if (RadioButton.OrderPlaced)
                        {
                            if (SelectedOrder.Status == "Заказ сделан")
                            {
                                SelectedOrder.Status = "Заказ сделан";
                            }
                        }
                        else if (RadioButton.ArrivedAtTheWarehouse)
                        {
                            if (SelectedOrder.Status == "Заказ сделан" || SelectedOrder.Status == "Поступил на склад")
                            {
                                SelectedOrder.Status = "Поступил на склад";
                            }
                        }
                        else if (RadioButton.Sent)
                        {
                            if (SelectedOrder.Status == "Поступил на склад" || SelectedOrder.Status == "Отправлен")
                            {
                                SelectedOrder.Status = "Отправлен";
                            }
                        }
                        else if (RadioButton.SmartCustomsCheck)
                        {
                            if (SelectedOrder.Status == "Отправлен" || SelectedOrder.Status == "На таможенной проверке")
                            {
                                
                                SelectedOrder.Status = "На таможенной проверке";
                            }
                        }
                        else if (RadioButton.InFilial)
                        {
                            if (SelectedOrder.Status == "На таможенной проверке" || SelectedOrder.Status == "На почте")
                            {
                                SelectedOrder.Status = "На почте";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Невозможно перенести заказ на этот этап");
                            return;
                        }
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
        }

        public RelayCommand RemoveOrder
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<RemoveOrderViewModel>();
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

        private void Filter()
        {
            Order = new ObservableCollection<Order>(_context.Orders
                .Where(o => o.Product.Contains(Search)));
        }
    }
}
