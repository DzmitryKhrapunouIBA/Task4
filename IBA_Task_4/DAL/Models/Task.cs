using System.Collections.Generic;

namespace DAL.Models
{
    public class Task : Entity
    {
        public string TaskName { get; set; }
        public int AssigneeId { get; set; }
        public int ProjectId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public User Assignee { get; set; }
        public Project Project { get; set; }


        public Task(string taskName, int assigneeId, int projectId, string status, string description) : this()
        {
            TaskName = taskName;
            AssigneeId = assigneeId;
            ProjectId = projectId;
            Status = status;
            Description = description;
        }

        public Task() : base() { }
    }
}
