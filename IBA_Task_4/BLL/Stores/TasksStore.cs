using BLL.Contracts;
using System;

namespace BLL.Stores
{
    public class TasksStore
    {
        public event Action<string, int, string, string> TaskAdded;

        public void AddTask(string taskName, int assigneeId, string status, string description)
        {
            TaskAdded?.Invoke(taskName, assigneeId, status, description);
        }
    }
}
