using System;

namespace BLL.Stores
{
    public class ProjectsStore
    {
        public event Action<string> ProjectAdded;

        public void AddProject(string projectName)
        {
            ProjectAdded?.Invoke(projectName);
        }
    }
}
