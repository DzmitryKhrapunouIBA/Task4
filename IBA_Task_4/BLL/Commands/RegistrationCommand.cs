using BLL.Contracts;
using BLL.Models;
using BLL.Services;
using BLL.Stores;
using BLL.ViewModels;
using DAL.Models;

namespace BLL.Commands
{
    public class RegistrationCommand : CommandBase
    {
        private readonly RegistrationViewModel _viewModel;
        private readonly AccountStore _accountStore;
        private readonly IUserService _userService;
        private readonly INavigationService _navigationService;

        public RegistrationCommand(AccountStore accountStore, RegistrationViewModel viewModel, IUserService userService, INavigationService navigationService)
        {
            _accountStore = accountStore;
            _viewModel = viewModel;
            _userService = userService;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            var password = AuthService.GetHash(_viewModel.Password);

            var user = new User(_viewModel.FirstName, _viewModel.LastName, _viewModel.SurName, _viewModel.Login, password);

            _userService.Create(user);

            Account account = new Account()
            {
                FirstName = user.FirstName,
                SurName = user.SurName,
                LastName = user.LastName,
                Login = user.Login
            };

            _navigationService.Navigate();
            _accountStore.CurrentAccount = account;

        }
    }
}
