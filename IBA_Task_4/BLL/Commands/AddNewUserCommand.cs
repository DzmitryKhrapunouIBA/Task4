using BLL.Contracts;
using BLL.Stores;
using BLL.ViewModels;

namespace BLL.Commands
{
    public class AddNewUserCommand : CommandBase
    {
        private readonly AddUserViewModel _addUserViewModel;
        private readonly UsersStore _usersStore;
        private readonly INavigationService _navigationService;

        public AddNewUserCommand(AddUserViewModel addUserViewModel, UsersStore usersStore, INavigationService navigationService)
        {
            _addUserViewModel = addUserViewModel;
            _usersStore = usersStore;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            string firstname = _addUserViewModel.FirstName;
            string surName = _addUserViewModel.SurName;
            string lastName = _addUserViewModel.LastName;
            string login = _addUserViewModel.Login;

            _usersStore.AddUser(firstname, lastName, surName, login);

            _navigationService.Navigate();
        }
    }
}