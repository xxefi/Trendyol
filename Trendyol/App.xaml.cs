using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using Trendyol.Models;
using Trendyol.Services;
using Trendyol.Services.Classes;
using Trendyol.Services.Interfaces;
using Trendyol.ViewModels;
using Trendyol.Views;

namespace Trendyol
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; set; }
        void Register()
        {
            Container = new Container();
            
            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<IDataService, DataService>();
            Container.RegisterSingleton<INavigationService, Services.NavigationService>();
            Container.RegisterSingleton<MainWindowViewModel>();
            Container.RegisterSingleton<LoginWindowViewModel>();
            Container.RegisterSingleton<RegisterWindowViewModel>();
            Container.RegisterSingleton<TrendyolWindowViewModel>();
            Container.RegisterSingleton<AdminWindowViewModel>();
            Container.RegisterSingleton<ForgotPasswordViewModel>();
            Container.RegisterSingleton<SuperAdminViewModel>();
            Container.RegisterSingleton<PrivateInfoViewModel>();
            Container.RegisterSingleton<AddressWindowViewModel>();
            Container.RegisterSingleton<RemoveAccountViewModel>();
            Container.RegisterSingleton<RemoveCargoViewModel>();
            Container.RegisterSingleton<SuperAdminCreateUserViewModel>();
            Container.RegisterSingleton<SuperAdminCreateAdminViewModel>();
            Container.RegisterSingleton<SuperAdminDeleteAdminViewModel>();
            Container.RegisterSingleton<SuperAdminDeleteUserViewModel>();
            Container.RegisterSingleton<SuperAdminAddOrderViewModel>();
            Container.RegisterSingleton<SuperAdminRemoveOrderViewModel>();
            Container.RegisterSingleton<SuperAdminDeleteCargoViewModel>();            
            Container.RegisterSingleton<RemoveOrderViewModel>();
            Container.RegisterSingleton<HistoryOrderViewModel>();
            Container.RegisterSingleton<WareHouseViewModel>();
            Container.RegisterSingleton<AddOrderViewModel>();
            Container.RegisterSingleton<UserBalanceViewModel>();
            Container.RegisterSingleton<AddCargoViewModel>();
            Container.RegisterSingleton<ApplicationDbContext>();
            Container.RegisterSingleton<CurrentUserService>();
            Container.RegisterSingleton<PayBalanceViewModel>();
            Container.RegisterSingleton<ExampleCVVViewModel>();
            Container.RegisterSingleton<CountOrderViewModel>();
            Container.RegisterSingleton<TrendyolGuestViewModel>();
            Container.RegisterSingleton<User>();
            Container.RegisterSingleton<Products>();
            Container.Verify();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();
            var window = new MainWindow();
            window.DataContext = Container.GetInstance<MainWindowViewModel>();
            window.Show();
        }
    }

}
