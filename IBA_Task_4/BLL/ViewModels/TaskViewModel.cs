namespace BLL.ViewModels
{
    public class TaskViewModel : ViewModelBase
    {
        public string TaskName { get; set; }
        public string  Assignee { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string UserFullName { get; set; }

        public TaskViewModel(string taskName, string userFullName, string status, string description)
        {
            TaskName = taskName;
            Status = status;
            Description = description;
            UserFullName = userFullName;
            Assignee = userFullName;
        }
    }
}  