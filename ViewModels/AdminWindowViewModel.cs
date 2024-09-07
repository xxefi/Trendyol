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
                () => _navigationService.NavigateTo<LoginWindowViewModel>());
        }

        public RelayCommand AddOrder
        {
            get => new(
                () => _navigationService.NavigateTo<AddOrderViewModel>());
        }

        public RelayCommand Check
        {
            get => new(
                () =>
                {
                    try
                    {
                        if (SelectedOrder == null)
                        {
                            MessageBox.Show("Заказ не выбран.");
                            return;
                        }
                        string newStatus = SelectedOrder.Status;
                        switch (SelectedOrder.Status)
                        {
                            case "Заказ сделан":
                                if (RadioButton.OrderPlaced)
                                    newStatus = "Заказ сделан";
                                else if (RadioButton.ArrivedAtTheWarehouse)
                                    newStatus = "Поступил на склад";
                                break;

                            case "Поступил на склад":
                                if (RadioButton.Sent)
                                    newStatus = "Отправлен";
                                else if (RadioButton.ArrivedAtTheWarehouse)
                                    newStatus = "Поступил на склад";
                                break;

                            case "Отправлен":
                                if (RadioButton.SmartCustomsCheck)
                                    newStatus = "На таможенной проверке";
                                break;

                            case "На таможенной проверке":
                                if (RadioButton.InFilial)
                                    newStatus = "На почте";
                                break;
                            case "На почте":
                                MessageBox.Show("Заказ уже на почте");
                                return;
                            default:
                                MessageBox.Show("Невозможно перенести заказ на этот этап.");
                                break;
                        }
                        if (SelectedOrder.Status != newStatus)
                        {
                            SelectedOrder.Status = newStatus;
                            _context.SaveChanges();
                            MessageBox.Show("Статус заказа успешно обновлен.");
                        }
                        else
                            MessageBox.Show("Не удалось изменить статус заказа");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
        }

        public RelayCommand RemoveOrder
        {
            get => new(
                () => _navigationService.NavigateTo<RemoveOrderViewModel>());
        }

        public RelayCommand SearchCommand
        {
            get => new(
                async() => await Filter());
        }

        private async Task Filter()
        {
            try
            {
                var filteredOrders = await _context.Orders
                    .Where(o => o.Product.Contains(Search))
                    .ToListAsync();
                Order = new ObservableCollection<Order>(filteredOrders);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при фильтрации данных: {ex.Message}");
            }

        }
    }
}
