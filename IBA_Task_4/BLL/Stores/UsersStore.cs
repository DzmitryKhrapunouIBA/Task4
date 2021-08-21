using System;

namespace BLL.Stores
{
    public class UsersStore
    {
        public event Action<string, string, string, string> UserAdded;

        public void AddUser(string firstName, string lastName, string surName, string login)
        {
            UserAdded?.Invoke(firstName, lastName, surName, login);
        }
    }
}
