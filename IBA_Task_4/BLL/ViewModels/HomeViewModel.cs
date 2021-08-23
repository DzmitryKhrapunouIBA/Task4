using BLL.Commands;
using BLL.Contracts;
using System.Windows.Input;

namespace BLL.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Welcome to the task scheduler.";

        public ICommand NavigateLoginCommand { get; }
        public ICommand NavigateRegistrationCommand { get; }

        public HomeViewModel(INavigationService loginNavigationService, INavigationService registrationNavigationService)
        {
            NavigateLoginCommand = new NavigateCommand(loginNavigationService);
            NavigateRegistrationCommand = new NavigateCommand(registrationNavigationService);
        }
    }
}
