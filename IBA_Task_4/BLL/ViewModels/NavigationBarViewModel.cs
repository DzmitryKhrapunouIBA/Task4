using BLL.Commands;
using BLL.Contracts;
using BLL.Stores;
using System.Windows.Input;

namespace BLL.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;
        public bool IsLoggedIn => _accountStore.IsLoggedIn;

        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateAccountCommand { get; }
        public ICommand NavigateLoginCommand { get; }
        public ICommand NavigateRegistrationCommand { get; }
        public ICommand NavigateProjectsListingCommand { get; }
        public ICommand NavigateTasksListingCommand { get; }
        public ICommand NavigateUsersListingCommand { get; }
        public ICommand NavigateChatRoomsListingCommand { get; }
        public ICommand LogoutCommand { get; }

        public NavigationBarViewModel(AccountStore accountStore,
        INavigationService homeNavigationService,
        INavigationService accountNavigationService,
        INavigationService loginNavigationService,
        INavigationService registrationNavigationService,
        INavigationService projectsListingNavigationService,
        INavigationService tasksListingNavigationService,
        INavigationService usersListingNavigationService,
        INavigationService chatRoomsListingNavigationService)
        {
            _accountStore = accountStore;
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            NavigateAccountCommand = new NavigateCommand(accountNavigationService);
            NavigateLoginCommand = new NavigateCommand(loginNavigationService);
            NavigateRegistrationCommand = new NavigateCommand(registrationNavigationService);
            NavigateProjectsListingCommand = new NavigateCommand(projectsListingNavigationService);
            NavigateTasksListingCommand = new NavigateCommand(tasksListingNavigationService);
            NavigateUsersListingCommand = new NavigateCommand(usersListingNavigationService);
            NavigateChatRoomsListingCommand = new NavigateCommand(chatRoomsListingNavigationService);

            LogoutCommand = new LogoutCommand(_accountStore);

            _accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
        }
        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        public override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;

            base.Dispose();
        }
    }
}