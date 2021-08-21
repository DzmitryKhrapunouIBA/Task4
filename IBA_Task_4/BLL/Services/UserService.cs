using DAL.Models;
using BLL.Contracts;
using DAL.Context;

namespace BLL.Services
{
    public class UserService : CrudService<User>, IUserService
    {
        public UserService(AppDbContext context) : base(context)
        { }

        public string GetFullName(int userId)
        {
            var user = Get(userId);

            var name = $"{user.LastName} {user.FirstName[0]}. {user.SurName[0]}.";

            return name;
        }
    }
}
