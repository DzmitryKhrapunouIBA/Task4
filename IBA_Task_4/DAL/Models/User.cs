using System.Collections.Generic;

namespace DAL.Models
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool SuperUser { get; set; }
        public IEnumerable<Task> Tasks { get; set; }


        public User(string firstName, string lastName, string surName, string login, string password, bool superUser = false) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            SurName = surName;
            Login = login;
            Password = password;
            SuperUser = superUser;
            Tasks = new List<Task>();
        }

        public User() : base() { }
    }
}
