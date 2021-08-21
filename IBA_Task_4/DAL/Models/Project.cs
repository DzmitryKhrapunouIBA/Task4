using System.Collections.Generic;

namespace DAL.Models
{
    public class Project : Entity
    {
        public string ProjectName { get; set; }
        public IEnumerable<Task> Tasks { get; set; }

        public Project(string projectName) : this()
        {
            ProjectName = projectName;
            Tasks = new List<Task>();
        }

        public Project() : base() { }
    }
}
