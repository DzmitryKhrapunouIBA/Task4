using BLL.Commands;
using BLL.Contracts;
using BLL.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BLL.ViewModels
{
    public class ChatRoomsListingViewModel : ViewModelBase
    {
        private readonly ChatRoomsStore _chatRoomsStore;
        private readonly ObservableCollection<ChatRoomViewModel> _chatRooms;
        public IEnumerable<ChatRoomViewModel> ChatRooms => _chatRooms;

        public ICommand AddChatRoomCommand { get; }

        public ChatRoomsListingViewModel(ChatRoomsStore chatRoomsStore, INavigationService addChatRoomNavigationService)
        {
            _chatRoomsStore = chatRoomsStore;

            AddChatRoomCommand = new NavigateCommand(addChatRoomNavigationService);
            _chatRooms = new ObservableCollection<ChatRoomViewModel>();

            _chatRoomsStore.ChatRoomAdded += OnChatRoomAdded;
        }

        private void OnChatRoomAdded(string chatRoomName)
        {
            _chatRooms.Add(new ChatRoomViewModel(chatRoomName));
        }
    }
}