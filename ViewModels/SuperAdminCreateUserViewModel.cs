using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Trendyol.Services;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels
{
    public class SuperAdminCreateUserViewModel : ViewModelBase, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 

        private readonly INavigationService _navigationService;
        private readonly UsersService _usersservice;
        private readonly ApplicationDbContext _context;
        private string _name;
        private string _surname;
        private string _login;
        private string _email;
        private string _password;
        private string _trypassword;
        private string _FIN;
        private string _phone;

        private bool _enabledUser;

        public bool EnabledUser
        {
            get => _enabledUser;
            set
            {
                if (_enabledUser != value)
                {
                    Set(ref _enabledUser, value);
                    OnPropertyChanged(nameof(EnabledUser));
                }
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (Regex.IsMatch(value, "^[A-Z][a-z]+$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _name, value);
                }
                else
                {
                    MessageBox.Show("Недействительный имя");
                    return;
                }
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                if (Regex.IsMatch(value, "^[A-Z][a-z]+$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _surname, value);
                }
                else
                {
                    MessageBox.Show("Недействительная фамилия");
                    return;
                }
            }
        }

        public string Login
        {
            get => _login;
            set
            {
                if (Regex.IsMatch(value, "^[a-zA-Z0-9_-]{3,16}$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _login, value);
                }
                else
                {
                    MessageBox.Show("Недействительный логин");
                    return;
                }
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (Regex.IsMatch(value, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _email, value);
                }
                else
                {
                    MessageBox.Show("Недействительная почта");
                    return;
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (Regex.IsMatch(value, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*()-_+=])[A-Za-z\d!@#$%^&*()-_+=]{8,}$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _password, value);
                }
                else
                {
                    MessageBox.Show("Пароль должен содержать как минимум 8 символов," +
                        " включая хотя бы одну заглавную букву, одну строчную букву, одну цифру, и один специальный символ");
                    return;
                }
            }
        }

        public string TryPassword
        {
            get => _trypassword;
            set
            {
                if (_trypassword != value)
                {
                    Set(ref _trypassword, value);
                    OnPropertyChanged(nameof(TryPassword));
                    EnabledUser = !string.IsNullOrWhiteSpace(TryPassword) && TryPassword.Length > 7;
                }
            }
        }

        public string FIN
        {
            get => _FIN;
            set
            {

                if (Regex.IsMatch(value, @"^\d{2}[A-Za-z]{2}\d{2}[A-Za-z]{1}$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _FIN, value);
                }
                else
                {
                    MessageBox.Show("Недействительный FIN");
                    return;
                }
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                if (Regex.IsMatch(value, @"^\+\d{3}\d{9}$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _phone, value);
                }
                else
                {
                    MessageBox.Show("Недействительный номер телефона");
                    return;
                }
            }
        }

        public SuperAdminCreateUserViewModel(INavigationService navigationService, ApplicationDbContext context)
        {
            _navigationService = navigationService;
            _context = context;
            _usersservice = new UsersService(_context);
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<SuperAdminViewModel>();
                });
        }

        public RelayCommand Register
        {
            get => new(
                () =>
                {
                    try
                    {
                        using (ApplicationDbContext context = new ApplicationDbContext())
                        {
                            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Surname) || string.IsNullOrWhiteSpace(Login)
                            || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(FIN)
                            || string.IsNullOrWhiteSpace(Phone) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(TryPassword))
                            {
                                MessageBox.Show("Поля не могут быть пустыми");
                                return;
                            }
                            else if (_context.Users.Any(u => u.Login == Login && u.Email == Email && u.FIN == FIN && u.Phone == Phone))
                            {
                                MessageBox.Show("Пользователь с такими данными уже есть в базе данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            else if (TryPassword != Password)
                            {
                                MessageBox.Show("Вы неправильно ввели повторный пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            else
                            {
                                var newuser = _usersservice.UserRegister(Name, Surname, Login, Email, Password, FIN, Phone);
                                _context.Users.Add(newuser);
                                _context.SaveChanges();
                                MessageBox.Show("Пользователь успешно создан", "SuperAdmin", MessageBoxButton.OK, MessageBoxImage.Information);
                                Name = "";
                                Surname = "";
                                Login = "";
                                Email = "";
                                Password = "";
                                FIN = "";
                                Phone = "";
                                _navigationService.NavigateTo<SuperAdminViewModel>();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
        }
    }
}
