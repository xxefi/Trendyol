
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Trendyol.Models;
using Trendyol.Services;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels
{
    public class SuperAdminViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;
        private readonly ApplicationDbContext _context;
        private ObservableCollection<User> _user;
        private ObservableCollection<Order> _order;
        private ObservableCollection<Admin> _admin;
        private ObservableCollection<SuperAdmin> _superAdmin;
        private ObservableCollection<ProductsForOrder> _productsForOrders;
        private RadioButtons _radioButtons;
        private User _selectedUser;
        private Order _selectedOrder;
        private Admin _selectedAdmin;
        private SuperAdmin _selectedSuperAdmin;
        private ProductsForOrder _selectedProductsForOrders;

        public ObservableCollection<User> User
        {
            get => _user;
            set => Set(ref _user, value);
        }

        public User SelectedUser
        {
            get => _selectedUser;
            set => Set(ref _selectedUser, value);
        }

        public ObservableCollection<Order> Order
        {
            get => _order;
            set => Set(ref _order, value);
        }

        public Order SelectedOrder
        {
            get => _selectedOrder;
            set => Set(ref _selectedOrder, value);
        }

        public ObservableCollection<Admin> Admin
        {
            get => _admin;
            set => Set(ref _admin, value);
        }

        public Admin SelectedAdmin
        {
            get => _selectedAdmin;
            set => Set(ref _selectedAdmin, value);
        }

        public ObservableCollection<SuperAdmin> SuperAdmin
        {
            get => _superAdmin;
            set => Set(ref _superAdmin, value);
        }

        public SuperAdmin SelectedSuperAdmin
        {
            get => _selectedSuperAdmin;
            set => Set(ref _selectedSuperAdmin, value);
        }

        public RadioButtons RadioButton
        {
            get => _radioButtons;
            set => Set(ref _radioButtons, value);
        }

        public ObservableCollection<ProductsForOrder> ProductsForOrders
        {
            get => _productsForOrders;
            set => Set(ref _productsForOrders, value);
        }

        public ProductsForOrder SelectedProductsForOrders
        {
            get => _selectedProductsForOrders;
            set => Set(ref _selectedProductsForOrders, value);
        }
        public SuperAdminViewModel(INavigationService navigationService, ApplicationDbContext context)
        {
            _navigationService = navigationService;
            _context = context;
            RadioButton = new RadioButtons();
            User = new ObservableCollection<User>(_context.Users);
            Order = new ObservableCollection<Order>(_context.Orders.Include(o => o.Users));
            Admin = new ObservableCollection<Admin>(_context.Admin);
            SuperAdmin = new ObservableCollection<SuperAdmin>(_context.SuperAdmin);
            ProductsForOrders = new ObservableCollection<ProductsForOrder>(_context.ProductsForOrders);
        }

        public RelayCommand Exit
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<LoginWindowViewModel>();
                });
        }

        public RelayCommand CreateUser
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<SuperAdminCreateUserViewModel>();
                });
        }

        public RelayCommand CreateAdmin
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<SuperAdminCreateAdminViewModel>();
                });
        }

        public RelayCommand DeleteAdmin
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<SuperAdminDeleteAdminViewModel>();
                });
        }

        public RelayCommand DeleteUser
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<SuperAdminDeleteUserViewModel>();
                });
        }

        public RelayCommand AddOrder
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<SuperAdminAddOrderViewModel>();
                });
        }

        public RelayCommand RemoveOrder
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<SuperAdminRemoveOrderViewModel>();
                });
        }

        public RelayCommand DeleteCargo
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<SuperAdminDeleteCargoViewModel>();
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
                            else
                            {
                                MessageBox.Show("Невозможно перенести заказ на этот этап");
                                return;
                            }
                        }
                        else if (RadioButton.ArrivedAtTheWarehouse)
                        {
                            if (SelectedOrder.Status == "Заказ сделан" || SelectedOrder.Status == "Поступил на склад")
                            {
                                SelectedOrder.Status = "Поступил на склад";
                            }
                            else
                            {
                                MessageBox.Show("Невозможно перенести заказ на этот этап");
                                return;
                            }
                        }
                        else if (RadioButton.Sent)
                        {
                            if (SelectedOrder.Status == "Поступил на склад" || SelectedOrder.Status == "Отправлен")
                            {
                                SelectedOrder.Status = "Отправлен";
                            }
                            else
                            {
                                MessageBox.Show("Невозможно перенести заказ на этот этап");
                                return;
                            }
                        }
                        else if (RadioButton.SmartCustomsCheck)
                        {
                            if (SelectedOrder.Status == "Отправлен" || SelectedOrder.Status == "На таможенной проверке")
                            {
                                SelectedOrder.Status = "На таможенной проверке";
                            }
                            else
                            {
                                MessageBox.Show("Невозможно перенести заказ на этот этап");
                                return;
                            }
                        }
                        else if (RadioButton.InFilial)
                        {
                            if (SelectedOrder.Status == "На таможенной проверке" || SelectedOrder.Status == "На почте")
                            {
                                SelectedOrder.Status = "На почте";
                            }
                            else
                            {
                                MessageBox.Show("Невозможно перенести заказ на этот этап");
                                return;
                            }
                        }
                        _context.SaveChanges();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
