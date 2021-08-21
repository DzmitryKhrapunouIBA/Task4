using BLL.Commands;
using BLL.Contracts;
using BLL.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BLL.ViewModels
{
    public class UsersListingViewModel : ViewModelBase
    {
        private readonly UsersStore _usersStore;
        private readonly ObservableCollection<UserViewModel> _users;
        public IEnumerable<UserViewModel> Users => _users;

        public ICommand AddNewUserCommand { get; }

        public UsersListingViewModel(UsersStore usersStore, INavigationService addUserNavigationService)
        {
            _usersStore = usersStore;

            AddNewUserCommand = new NavigateCommand(addUserNavigationService);

            _users = new ObservableCollection<UserViewModel>();

            _usersStore.UserAdded += OnUserAdded;
        }

        private void OnUserAdded(string firstName, string lastName, string surName, string login)
        {
            _users.Add(new UserViewModel(firstName, lastName, surName, login));
        }
    }
}

