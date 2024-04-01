using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;
using Trendyol.Models;
using Trendyol.Services;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels;

public class SuperAdminDeleteUserViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly ApplicationDbContext _context;
    private ObservableCollection<User> _user;
    private User _selecteduser;

    public ObservableCollection<User> User
    {
        get => _user;
        set => Set(ref  _user, value);
    }

    public User SelectedUser
    {
        get => _selecteduser;
        set => Set(ref _selecteduser, value);
    }


    public SuperAdminDeleteUserViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        _context = new ApplicationDbContext();
        User = new ObservableCollection<User>(_context.Users);
    }

    public RelayCommand Back
    {
        get => new(
            () =>
            {
                _navigationService.NavigateTo<SuperAdminViewModel>();
            });
    }

    public RelayCommand DeleteUser
    {
        get => new(
            () =>
            {
                try
                {
                    if (SelectedUser == null)
                    {
                        MessageBox.Show("Вы ничего не выбрали");
                        return;
                    }
                    var user = _context.Users.SingleOrDefault(u => u.FIN == _selecteduser.FIN && u.Phone == _selecteduser.Phone);
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    User.Remove(user);
                    MessageBox.Show("Успешно удалено");
                    SelectedUser = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Ошибка");
                }
            });
    }
}