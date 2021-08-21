using System;

namespace BLL.Stores
{
    public class ChatRoomsStore
    {
        public event Action<string> ChatRoomAdded;

        public void AddRoom(string chatRoomName)
        {
            ChatRoomAdded?.Invoke(chatRoomName);
        }
    }
}
