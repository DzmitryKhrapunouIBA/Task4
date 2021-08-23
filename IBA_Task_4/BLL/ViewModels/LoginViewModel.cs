using BLL.Commands;
using BLL.Contracts;
using BLL.Stores;
using System.Windows.Input;

namespace BLL.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _login;
        private string _password;

        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public ICommand LoginCommand { get; }

        public LoginViewModel(AccountStore accountStore, INavigationService loginNavigationService, IUserService userService)
        {
            LoginCommand = new LoginCommand(accountStore, this, userService, loginNavigationService);
        }
    }
}