using DAL.Models;

namespace BLL.Contracts
{
    public interface IUserService : ICrudService<User>
    {
        public string GetFullName(int userId);
    }
}