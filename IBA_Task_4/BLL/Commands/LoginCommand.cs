using BLL.Contracts;
using BLL.Models;
using BLL.Services;
using BLL.Stores;
using BLL.ViewModels;

namespace BLL.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _viewModel;
        private readonly AccountStore _accountStore;
        private readonly IUserService _userService;
        private readonly INavigationService _navigationService;

        public LoginCommand(AccountStore accountStore, LoginViewModel viewModel, IUserService userService, INavigationService navigationService)
        {
            _accountStore = accountStore;
            _userService = userService;
            _navigationService = navigationService;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            var user = _userService.Get(u => u.Login == _viewModel.Login);

            Account account = new Account()
            {
                FirstName = user.FirstName,
                SurName = user.SurName,
                LastName = user.LastName,
                Login = _viewModel.Login
            };

            _accountStore.CurrentAccount = account;
            _navigationService.Navigate();
        }
    }
}

