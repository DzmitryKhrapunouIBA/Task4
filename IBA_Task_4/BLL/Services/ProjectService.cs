using BLL.Contracts;
using DAL.Context;
using DAL.Models;

namespace BLL.Services
{
    public class ProjectService : CrudService<Project>, IProjectService
    {
        public ProjectService(AppDbContext context) : base(context)
        {
        }
    }
}
