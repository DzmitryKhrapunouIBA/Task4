namespace BLL.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string Login { get; set; }

        public UserViewModel(string firstName, string lastName, string surName, string login)
        {
            FirstName = firstName;
            LastName = lastName;
            SurName = surName;
            Login = login;
        }
    }
}
