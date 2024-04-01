using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Trendyol.Models;
using Trendyol.Services;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels;

public class RemoveOrderViewModel : ViewModelBase, INotifyPropertyChanged
{

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    private readonly INavigationService _navigationService;
    private readonly ApplicationDbContext _context;
    private ObservableCollection<ProductsForOrder> _productsForOrders;
    private ProductsForOrder _selectedProductsForOrders;

    public ObservableCollection<ProductsForOrder> ProductsForOrders
    {
        get => _productsForOrders;
        set
        {
            if (_productsForOrders != value)
            {
                Set(ref _productsForOrders, value);
                OnPropertyChanged(nameof(ProductsForOrders));
            }
        }
    }

    public ProductsForOrder SelectedProductsForOrders
    {
        get => _selectedProductsForOrders;
        set
        {
            if (_selectedProductsForOrders != value)
            {
                Set(ref _selectedProductsForOrders, value);
                OnPropertyChanged(nameof(SelectedProductsForOrders));
            }
        }
    }
    public RemoveOrderViewModel(INavigationService navigationService, ApplicationDbContext context)
    {
        _navigationService = navigationService;
        _context = context;
        ProductsForOrders = new ObservableCollection<ProductsForOrder>(_context.ProductsForOrders.ToList());
    }

    public RelayCommand Back
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<AdminWindowViewModel>();
        });
    }

    public RelayCommand Remove
    {
        get => new(() =>
        {
            if (_selectedProductsForOrders != null)
            {
            var productsForOrder = _context.ProductsForOrders.FirstOrDefault(p => p.Name == _selectedProductsForOrders.Name);
                if (productsForOrder != null)
                {
                    var wareHouseProduct =  _context.WareHouse.FirstOrDefault(w => w.ProductId == _selectedProductsForOrders.Id);
                    if (wareHouseProduct != null)
                    {
                        _context.ProductsForOrders.Remove(productsForOrder);
                        _context.SaveChanges();
                    }
                    _context.WareHouse.Remove(wareHouseProduct);
                    _context.SaveChanges();
                    ProductsForOrders.Remove(productsForOrder);
                    MessageBox.Show("Успешно удалено");
                    SelectedProductsForOrders = null;
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали товар");
                return;
            }
        });
    }
}