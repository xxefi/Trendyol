using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Trendyol.Models;
using Trendyol.Services;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels
{
    public class SuperAdminDeleteAdminViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ApplicationDbContext _context;
        private ObservableCollection<Admin> _admin;
        private Admin _selectedAdmin;
        

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
        public SuperAdminDeleteAdminViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _context = new ApplicationDbContext();
            Admin = new ObservableCollection<Admin>(_context.Admin.ToList());
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<SuperAdminViewModel>();
                });
        }

        public RelayCommand DeleteAdmin
        {
            get => new(
                () =>
                {
                    try
                    {
                        if (SelectedAdmin == null)
                        {
                            MessageBox.Show("Вы ничего не выбрали");
                            return;
                        }
                        Admin admin = _context.Admin.SingleOrDefault(a => a.Name == _selectedAdmin.Name);
                        if (admin != null)
                        {
                            _context.Admin.Remove(admin);
                            _context.SaveChanges();
                            Admin.Remove(admin);
                            MessageBox.Show("Успешно удалено");
                            SelectedAdmin = null;
                        }
                        else
                        {
                            MessageBox.Show("Список админа пусто");
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
