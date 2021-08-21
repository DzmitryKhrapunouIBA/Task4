using BLL.Commands;
using BLL.Contracts;
using BLL.Stores;
using System.Windows.Input;

namespace BLL.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;
        public ICommand NavigateHomeCommand { get; }

        public string FirstName => _accountStore.CurrentAccount?.FirstName;
        public string SurName => _accountStore.CurrentAccount?.SurName;
        public string LastName => _accountStore.CurrentAccount?.LastName;
        public string Login => _accountStore.CurrentAccount?.Login;

        public AccountViewModel(AccountStore accountStore, INavigationService homeNavigationService)
        {
            _accountStore = accountStore;
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            _accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
        }
        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(SurName));
            OnPropertyChanged(nameof(LastName));
            OnPropertyChanged(nameof(Login));
        }

        public override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;

            base.Dispose();
        }
    }
}