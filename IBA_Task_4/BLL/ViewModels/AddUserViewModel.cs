using BLL.Commands;
using BLL.Contracts;
using BLL.Stores;
using System.Windows.Input;

namespace BLL.ViewModels
{
    public class AddUserViewModel : ViewModelBase
    {
        private string _firstName;
        private string _surName;
        private string _lastName;
        private string _login;

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

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public AddUserViewModel(UsersStore usersStore, INavigationService closeNavigationService)
        {
            SubmitCommand = new AddNewUserCommand(this, usersStore, closeNavigationService);
            CancelCommand = new NavigateCommand(closeNavigationService);
        }
    }
}