using BLL.Commands;
using BLL.Contracts;
using BLL.Stores;
using System.Windows.Input;

namespace BLL.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private string _firstName;
        private string _surName;
        private string _lastName;
        private string _login;
        private string _password;
        private string _conformedPassword;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string SurName
        {
            get
            {
                return _surName;
            }
            set
            {
                _surName = value;
                OnPropertyChanged(nameof(SurName));
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

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

        public string ConformedPassword
        {
            get
            {
                return _conformedPassword;
            }
            set
            {
                _conformedPassword = value;
                OnPropertyChanged(nameof(ConformedPassword));
            }
        }

        public ICommand RegistrationCommand { get; }

        public RegistrationViewModel(AccountStore accountStore, INavigationService registrationNavigationService, IUserService userService)
        {
            RegistrationCommand = new RegistrationCommand(accountStore, this, userService, registrationNavigationService);
        }
    }
}
