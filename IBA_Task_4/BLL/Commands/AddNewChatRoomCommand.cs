using BLL.Contracts;
using BLL.Stores;
using BLL.ViewModels;

namespace BLL.Commands
{
    public class AddNewChatRoomCommand : CommandBase
    {
        private readonly AddChatRoomViewModel _addChatRoomViewModel;
        private readonly ChatRoomsStore _chatRoomsStore;
        private readonly INavigationService _navigationService;

        public AddNewChatRoomCommand(AddChatRoomViewModel addChatRoomViewModel, ChatRoomsStore chatRoomsStore, INavigationService navigationService)
        {
            _addChatRoomViewModel = addChatRoomViewModel;
            _chatRoomsStore = chatRoomsStore;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            string chatRoomName = _addChatRoomViewModel.Name;
            _chatRoomsStore.AddRoom(chatRoomName);
            _navigationService.Navigate();
        }
    }
}