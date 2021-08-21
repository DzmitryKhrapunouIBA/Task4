using BLL.Commands;
using BLL.Contracts;
using BLL.Stores;
using System.Windows.Input;

namespace BLL.ViewModels
{
    public class AddChatRoomViewModel : ViewModelBase
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public AddChatRoomViewModel(ChatRoomsStore roomsStore, INavigationService closeNavigationService)
        {
            SubmitCommand = new AddNewChatRoomCommand(this, roomsStore, closeNavigationService);
            CancelCommand = new NavigateCommand(closeNavigationService);
        }
    }
}