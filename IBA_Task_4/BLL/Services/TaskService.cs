using BLL.Contracts;
using BLL.ViewModels;
using DAL.Context;
using DAL.Models;

namespace BLL.Services
{
    public class TaskService : CrudService<Task>, ITaskService
    {
        public TaskService(AppDbContext context) : base(context)
        {
        }
    }
}
