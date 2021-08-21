namespace BLL.ViewModels
{
    public class ChatRoomViewModel : ViewModelBase
    {
        public string ChatRoomName { get; set; }

        public ChatRoomViewModel(string chatRoomName)
        {
            ChatRoomName = chatRoomName;
        }
    }
}